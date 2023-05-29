using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.SageXml;
using BinaryAssetBuilder.Utility;

namespace BinaryAssetBuilder.Core
{
    public sealed class OutputManager : IDisposable
    {
        private const int _linkedBufferSize = 0x10000;

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(OutputManager), "Provides manifest serialization functionality");
        private static readonly InstanceHandle _breakHandle = new InstanceHandle(0x21E727DAu, 0xAE184C44u);
        private static readonly byte[] _linkedBuffer = new byte[_linkedBufferSize];

        private readonly SortedDictionary<string, OutputAsset> _oldOutputInstances = new();
        private int _assetFileCount;
        private int _customDataFileCount;
        private readonly string _assetDirectory;
        private readonly string _customDataDirectory;
        private readonly TargetPlatform _targetPlatform;
        private readonly bool _isLinked;
        private readonly bool _validOldOutputInstances;
        private readonly string _manifestFile;
        private readonly string _oldManifestFile;
        private readonly string _versionFile;
        private string _basePatchStreamRelativePath = string.Empty;
        private ManifestHeader _header;

        public SortedDictionary<string, BinaryAsset> Assets { get; } = new SortedDictionary<string, BinaryAsset>();
        public DocumentProcessor DocumentProcessor { get; }
        public string IntermediateOutputDirectory { get; }
        public string OutputDirectory { get; }
        public string TargetPlatformCacheRoot { get; }
        public SortedDictionary<string, AssetHeader> BasePatchStreamAssets { get; private set; }
        public Manifest BasePatchStreamManifest { get; }
        public string BasePatchStream { get; private set; }

        public OutputManager(DocumentProcessor documentProcessor,
                             IEnumerable<OutputAsset> lastOutputInstances,
                             string outputDirectory,
                             string intermediateOutputDirectory,
                             string basePatchStream,
                             string baseStreamRelativePath,
                             string[] baseStreamSearchPaths)
        {
            DocumentProcessor = documentProcessor;
            OutputDirectory = outputDirectory;
            IntermediateOutputDirectory = intermediateOutputDirectory;
            _targetPlatform = Settings.Current.TargetPlatform;
            _isLinked = Settings.Current.LinkedStreams;
            _assetDirectory = Path.Combine(IntermediateOutputDirectory, "assets");
            _customDataDirectory = Path.Combine(OutputDirectory, "cdata");
            TargetPlatformCacheRoot = Settings.Current.BuildCache ? Path.Combine(Settings.Current.BuildCacheDirectory, _targetPlatform.ToString()) : null;
            _manifestFile = OutputDirectory + ".manifest";
            _oldManifestFile = OutputDirectory + ".old.manifest";
            int indexOfPostfix = OutputDirectory.LastIndexOf(Settings.Current.CustomPostfix, StringComparison.OrdinalIgnoreCase);
            if (indexOfPostfix < OutputDirectory.Length)
            {
                _versionFile = OutputDirectory.Remove(indexOfPostfix);
            }
            else
            {
                _versionFile = OutputDirectory;
            }
            _versionFile += ".version";
            if (File.Exists(_oldManifestFile))
            {
                File.Delete(_oldManifestFile);
            }
            if (File.Exists(_manifestFile))
            {
                try
                {
                    _header = new ManifestHeader();
                    using (FileStream stream = File.OpenRead(_manifestFile))
                    {
                        _header.LoadFromStream(stream, Settings.Current.BigEndian);
                    }
                    File.Move(_manifestFile, _oldManifestFile);
                }
                catch (Exception ex)
                {
                    throw new BinaryAssetBuilderException(ex,
                                                          ErrorCode.LockedFile,
                                                          "Unable to delete '{0}'. Make sure no other application is writing to or reading from this file while the data build is running.",
                                                          _manifestFile);
                }
            }
            if (Directory.Exists(IntermediateOutputDirectory) && lastOutputInstances is not null)
            {
                _validOldOutputInstances = true;
                foreach (OutputAsset lastOutputInstance in lastOutputInstances)
                {
                    _oldOutputInstances.Add(lastOutputInstance.Handle.FileBase, lastOutputInstance);
                }
            }
            if (basePatchStream is null)
            {
                return;
            }
            ProcessBasePatchStream(basePatchStream, baseStreamRelativePath, baseStreamSearchPaths);
        }

        private static void AppendAsset(Stream source, Stream destination, int length)
        {
            int bytesRead;
            for (; length > 0; length -= bytesRead)
            {
                int chunkSize = length > _linkedBufferSize ? _linkedBufferSize : length;
                bytesRead = source.Read(_linkedBuffer, 0, chunkSize);
                if (bytesRead != chunkSize)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Requested more bytes to read than available.");
                }
                destination.Write(_linkedBuffer, 0, bytesRead);
            }
        }

        private static void MoveLinked(string linkPath, string linkPathExisting, string extension)
        {
            if (File.Exists(linkPathExisting + extension))
            {
                File.Delete(linkPathExisting + extension);
            }
            File.Move(linkPath + extension, linkPathExisting + extension);
        }

        private void ProcessBasePatchStream(string basePatchStream, string baseStreamRelativePath, string[] baseStreamSearchPaths)
        {
            Manifest manifest = new Manifest();
            List<string> patchSearchPaths = new List<string>();
            if (baseStreamSearchPaths is not null)
            {
                patchSearchPaths.AddRange(baseStreamSearchPaths);
            }
            patchSearchPaths.Add(Settings.Current.OutputDirectory);
            string patchStreamPath = basePatchStream;
            if (!File.Exists(patchStreamPath))
            {
                foreach (string path in patchSearchPaths)
                {
                    string searchPath = Path.Combine(path, basePatchStream);
                    if (File.Exists(searchPath))
                    {
                        patchStreamPath = searchPath;
                        break;
                    }
                }
            }
            if (!File.Exists(patchStreamPath))
            {
                throw new BinaryAssetBuilderException(ErrorCode.FileNotFound, "Specified manifest could not be found: {0}", patchStreamPath);
            }
            try
            {
                manifest.Load(patchStreamPath, patchSearchPaths.ToArray());
            }
            catch
            {
                _tracer.TraceError("Could not load {0}.", basePatchStream);
                return;
            }
            BasePatchStream = basePatchStream;
            _basePatchStreamRelativePath = baseStreamRelativePath;
            BasePatchStreamAssets = new SortedDictionary<string, AssetHeader>();
            foreach (Asset asset in manifest.Assets)
            {
                BasePatchStreamAssets.Add(Path.GetFileName(asset.FileBasePath), new AssetHeader
                {
                    TypeId = asset.TypeId,
                    InstanceId = asset.InstanceId,
                    TypeHash = asset.TypeHash,
                    InstanceHash = asset.InstanceHash,
                    InstanceDataSize = asset.InstanceDataSize,
                    RelocationDataSize = asset.RelocationDataSize,
                    ImportsDataSize = asset.ImportsDataSize
                });
            }
        }

        public BinaryAsset GetBinaryAsset(InstanceDeclaration instance, bool isOutputAsset)
        {
            if (instance.Handle.TypeHash == 0u)
            {
                return null;
            }
            string fileBase = instance.Handle.FileBase;
            if (!Assets.TryGetValue(fileBase, out BinaryAsset binaryAsset))
            {
                _oldOutputInstances.TryGetValue(fileBase, out OutputAsset oldAsset);
                binaryAsset = new BinaryAsset(this, oldAsset, instance);
                Assets.Add(fileBase, binaryAsset);
            }
            else
            {
                binaryAsset.Instance = instance;
            }
            if (isOutputAsset && !binaryAsset.IsOutputAsset)
            {
                _oldOutputInstances.Remove(binaryAsset.FileBase);
                binaryAsset.IsOutputAsset = true;
                ++_assetFileCount;
                if (binaryAsset.Instance.HasCustomData)
                {
                    ++_customDataFileCount;
                }
            }
            return binaryAsset;
        }

        public void CreateVersionFile(AssetDeclarationDocument document, string streamPostfix)
        {
            using StreamWriter writer = File.CreateText(_versionFile);
            if (!string.IsNullOrEmpty(streamPostfix))
            {
                writer.Write(streamPostfix);
            }
            else
            {
                writer.Write("  ");
            }
        }

        public void CommitManifest(AssetDeclarationDocument document)
        {
            uint allTypesHash = DocumentProcessor.Plugins.DefaultPlugin.AllTypesHash;
            if (_header != null)
            {
                if (_header.IsLinked == Settings.Current.LinkedStreams
                 && _header.Version == ManifestHeader.LatestVersion
                 && _header.StreamChecksum == document.OutputChecksum
                 && _header.AllTypesHash == allTypesHash)
                {
                    File.Move(_oldManifestFile, _manifestFile);
                    _tracer.TraceInfo("Old manifest is up to date.");
                    return;
                }
                File.Delete(_oldManifestFile);
                _tracer.TraceInfo("Regenerating manifest.");
            }
            else
            {
                string directoryName = Path.GetDirectoryName(_manifestFile);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
            }
            _header = new ManifestHeader();
            using MemoryStream stream = new MemoryStream();
            uint assetsCount = 0;
            uint instanceDataSize = 0;
            uint maxInstanceChunkSize = 0;
            uint maxRelocationChunkSize = 0;
            uint maxImportsChunkSize = 0;
            int assetIndex = -1;
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();
            AssetEntry assetEntry = new AssetEntry();
            NameBuffer nameBuffer = new NameBuffer();
            NameBuffer sourceFileNameBuffer = new NameBuffer();
            ReferencedFileBuffer referencedManifestBuffer = new ReferencedFileBuffer();
            UInt32Buffer assetReferenceBuffer = new UInt32Buffer();
            foreach (InstanceDeclaration outputInstance in document.OutputInstances)
            {
                ExtendedTypeInformation extendedTypeInformation = DocumentProcessor.Plugins.GetExtendedTypeInformation(outputInstance.Handle.TypeId);
                BinaryAsset binaryAsset = GetBinaryAsset(outputInstance, true);
                ++assetsCount;
                int length = assetReferenceBuffer.Length;
                foreach (InstanceHandle referencedInstance in outputInstance.ValidatedReferencedInstances)
                {
                    assetReferenceBuffer.AddValue(referencedInstance.TypeId);
                    assetReferenceBuffer.AddValue(referencedInstance.InstanceId);
                }
                instanceDataSize += (uint)binaryAsset.InstanceFileSize;
                maxInstanceChunkSize = (uint)Math.Max(binaryAsset.InstanceFileSize, maxInstanceChunkSize);
                maxRelocationChunkSize = (uint)Math.Max(binaryAsset.RelocationFileSize, maxRelocationChunkSize);
                maxImportsChunkSize = (uint)Math.Max(binaryAsset.ImportsFileSize, maxImportsChunkSize);
                assetEntry.TypeId = outputInstance.Handle.TypeId;
                assetEntry.InstanceId = outputInstance.Handle.InstanceId;
                assetEntry.TypeHash = outputInstance.Handle.TypeHash;
                assetEntry.InstanceHash = outputInstance.Handle.InstanceHash;
                assetEntry.AssetReferenceOffset = length;
                assetEntry.AssetReferenceCount = outputInstance.ReferencedInstances.Count;
                assetEntry.NameOffset = nameBuffer.AddName(outputInstance.Handle.Name);
                assetEntry.SourceFileNameOffset = sourceFileNameBuffer.AddName(outputInstance.Document.LogicalSourcePath);
#if !VERSION5
                assetEntry.Tokenized = extendedTypeInformation.Tokenized;
#endif
                int index = BasePatchStreamManifest is null ? -1 : BasePatchStreamManifest.GetBaseStreamPosition(assetEntry);
                AssetLocation location = binaryAsset.GetLocation(AssetLocation.BasePatchStream, AssetLocationOption.None);
                if (location == AssetLocation.BasePatchStream && assetIndex >= index && index >= 0 && Settings.Current.LinkedStreams)
                {
                    _tracer.TraceInfo("Duplicating base stream asset {0} in patch stream due to ordering change.", outputInstance.Handle.FullName);
                }
                if (location == AssetLocation.BasePatchStream && assetIndex < index && index >= 0 && Settings.Current.LinkedStreams)
                {
                    assetEntry.InstanceDataSize = 0;
                    assetEntry.RelocationDataSize = 0;
                    assetEntry.ImportsDataSize = 0;
                    assetIndex = index;
                }
                else
                {
                    assetEntry.InstanceDataSize = binaryAsset.InstanceFileSize;
                    assetEntry.RelocationDataSize = binaryAsset.RelocationFileSize;
                    assetEntry.ImportsDataSize = binaryAsset.ImportsFileSize;
                }
                assetEntry.SaveToStream(stream, Settings.Current.BigEndian);
            }
            if (BasePatchStream is not null)
            {
                referencedManifestBuffer.AddReference(_basePatchStreamRelativePath + Path.GetFileName(BasePatchStream), true);
            }
            foreach (InclusionItem inclusionItem in document.InclusionItems)
            {
                if (inclusionItem.Type == InclusionType.Reference)
                {
                    string str = inclusionItem.Document is null ? DocumentProcessor.GetExpectedOutputManifest(inclusionItem.PhysicalPath)
                                                                : inclusionItem.Document.SourcePathFromRoot + ".manifest";
                    if (Path.IsPathRooted(str))
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.UnknownReference, "Reference file paths must be relative in {0}.", inclusionItem.PhysicalPath);
                    }
                    str = str.ToLowerInvariant();
                    str = str.Replace('/', '\\');
                    referencedManifestBuffer.AddReference(str, false);
                }
            }
            byte[] buffer = stream.GetBuffer();
            using Stream fileStream = new FileStream(_manifestFile, FileMode.Create, FileAccess.Write, FileShare.None);
            new ManifestHeader
            {
                StreamChecksum = document.OutputChecksum,
                AllTypesHash = allTypesHash,
                IsLinked = _isLinked,
                AssetCount = assetsCount,
                TotalInstanceDataSize = instanceDataSize,
                MaxInstanceChunkSize = maxInstanceChunkSize,
                MaxRelocationChunkSize = maxRelocationChunkSize,
                MaxImportsChunkSize = maxImportsChunkSize,
                AssetReferenceBufferSize = (uint)assetReferenceBuffer.Length,
                ReferenceManifestNameBufferSize = (uint)referencedManifestBuffer.Length,
                AssetNameBufferSize = (uint)nameBuffer.Length,
                SourceFileNameBufferSize = (uint)sourceFileNameBuffer.Length
            }.SaveToStream(fileStream, Settings.Current.BigEndian);
            fileStream.Write(buffer, 0, (int)stream.Length);
            assetReferenceBuffer.SaveToStream(fileStream, Settings.Current.BigEndian);
            referencedManifestBuffer.SaveToStream(fileStream);
            nameBuffer.SaveToStream(fileStream);
            sourceFileNameBuffer.SaveToStream(fileStream);
        }

        public void LinkStream(AssetDeclarationDocument document)
        {
            string linkPath = OutputDirectory + ".temp";
            string outputDirectory = OutputDirectory;
            uint checksum = document.OutputChecksum;
            if (Settings.Current.BigEndian)
            {
                checksum = (uint)((((int)checksum & 0xFF) << 24) | (((int)checksum & 0xFF00) << 8) | ((int)(checksum >> 8) & 0xFF00) | ((int)(checksum >> 24) & 0xFF));
            }
            using MemoryStream reloStream = new MemoryStream();
            using MemoryStream impStream = new MemoryStream();
            bool dirty = true;
            using (Stream fileStream = new FileStream(outputDirectory + ".bin", FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length >= 4L)
                {
                    dirty = new BinaryReader(fileStream).ReadUInt32() != checksum;
                }
            }
            if (dirty)
            {
                using (Stream binStream = new FileStream(linkPath + ".bin", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    _tracer.Message("{0} Linking binary data", document.SourcePathFromRoot);
                    AssetHeader assetHeader = new AssetHeader();
                    binStream.SetLength(0L);
                    new BinaryWriter(binStream).Write(checksum);
                    foreach (InstanceDeclaration outputInstance in document.OutputInstances)
                    {
                        BinaryAsset asset = Assets[outputInstance.Handle.FileBase];
                        if (asset.GetLocation(AssetLocation.BasePatchStream, AssetLocationOption.None) != AssetLocation.BasePatchStream)
                        {
                            using Stream assetStream = File.OpenRead(Path.Combine(asset.AssetOutputDirectory, asset.AssetFileName));
                            assetHeader.LoadFromStream(assetStream, Settings.Current.BigEndian);
                            AppendAsset(assetStream, binStream, assetHeader.InstanceDataSize);
                            AppendAsset(assetStream, reloStream, assetHeader.RelocationDataSize);
                            AppendAsset(assetStream, impStream, assetHeader.ImportsDataSize);
                        }
                    }
                    binStream.Flush();
                }
                MoveLinked(linkPath, outputDirectory, ".bin");
            }
            else
            {
                _tracer.Message("{0} Linked binary data up to date", document.SourcePathFromRoot);
            }
            dirty = true;
            using (Stream fileStream = new FileStream(outputDirectory + ".relo", FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length >= 4L)
                {
                    dirty = new BinaryReader(fileStream).ReadUInt32() != checksum;
                }
            }
            if (dirty)
            {
                using (Stream reloFStream = new FileStream(linkPath + ".relo", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    _tracer.Message("{0} Linking relocation data", document.SourcePathFromRoot);
                    reloFStream.SetLength(0L);
                    BinaryWriter writer = new BinaryWriter(reloFStream);
                    writer.Write(checksum);
                    writer.Write(reloStream.GetBuffer(), 0, (int)reloStream.Length);
                    reloFStream.Flush();
                }
                MoveLinked(linkPath, outputDirectory, ".relo");
            }
            else
            {
                _tracer.Message("{0} Linked relocation data up to date", document.SourcePathFromRoot);
            }
            dirty = true;
            using (Stream fileStream = new FileStream(outputDirectory + ".imp", FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length >= 4L)
                {
                    dirty = new BinaryReader(fileStream).ReadUInt32() != checksum;
                }
            }
            if (dirty)
            {
                using (Stream impFStream = new FileStream(linkPath + ".imp", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    _tracer.Message("{0} Linking import data", document.SourcePathFromRoot);
                    impFStream.SetLength(0L);
                    BinaryWriter writer = new BinaryWriter(impFStream);
                    writer.Write(checksum);
                    writer.Write(impStream.GetBuffer(), 0, (int)impStream.Length);
                    impFStream.Flush();
                }
                MoveLinked(linkPath, outputDirectory, ".imp");
            }
            else
            {
                _tracer.Message("{0} Linked import data up to date", document.SourcePathFromRoot);
            }
        }

        public void CleanOutput()
        {
            bool intermediateIsOutput = Path.GetFullPath(IntermediateOutputDirectory) == Path.GetFullPath(OutputDirectory);
            DirectoryInfo outputDirectory = new(OutputDirectory);
            if (outputDirectory.Exists)
            {
                foreach (FileSystemInfo file in outputDirectory.GetFiles())
                {
                    file.Delete();
                }
            }
            if (!intermediateIsOutput)
            {
                DirectoryInfo intermediateDirectory = new(IntermediateOutputDirectory);
                if (intermediateDirectory.Exists)
                {
                    foreach (FileSystemInfo file in intermediateDirectory.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
            int assetFileCount = _assetFileCount;
            int customDataFileCount = _customDataFileCount;
            foreach (OutputAsset outputAsset in _oldOutputInstances.Values)
            {
                if (DocumentProcessor.Plugins.GetExtendedTypeInformation(outputAsset.Handle.TypeId).HasCustomData)
                {
                    ++customDataFileCount;
                }
            }
            assetFileCount += _oldOutputInstances.Count;
            string str = _oldOutputInstances.Count.ToString(CultureInfo.InvariantCulture);
            DirectoryInfo assetDirectory = new(_assetDirectory);
            if (assetDirectory.Exists)
            {
                FileInfo[] files = assetDirectory.GetFiles();
                if (_validOldOutputInstances && assetFileCount == files.Length && !Settings.Current.ForceSlowCleanup)
                {
                    if (_oldOutputInstances.Count == 0)
                    {
                        _tracer.TraceInfo("No asset clean-up required.");
                    }
                    else
                    {
                        _tracer.TraceInfo("Fast asset clean-up.");
                    }
                    foreach (OutputAsset outputAsset in _oldOutputInstances.Values)
                    {
                        File.Delete(Path.Combine(_assetDirectory, outputAsset.Handle.FileBase) + ".asset");
                    }
                }
                else
                {
                    _tracer.TraceInfo("Slow asset clean-up (expected: {0}, actual: {1}, old: {2}, current: {3})", assetFileCount, files.Length, str, _assetFileCount);
                    foreach (FileInfo fileInfo in files)
                    {
                        string lower = Path.GetFileNameWithoutExtension(fileInfo.Name).ToLowerInvariant();
                        if (fileInfo.Extension != ".asset")
                        {
                            fileInfo.Delete();
                        }
                        else
                        {
                            if (Assets.TryGetValue(lower, out BinaryAsset binaryAsset) && !binaryAsset.IsOutputAsset)
                            {
                                binaryAsset = null;
                            }
                            if (binaryAsset is null)
                            {
                                fileInfo.Delete();
                            }
                        }
                    }
                }
            }
            DirectoryInfo cdataDirectory = new DirectoryInfo(_customDataDirectory);
            if (!cdataDirectory.Exists)
            {
                return;
            }
            FileInfo[] filesCData = cdataDirectory.GetFiles();
            if (_validOldOutputInstances && customDataFileCount == filesCData.Length && !Settings.Current.ForceSlowCleanup)
            {
                if (_oldOutputInstances.Count == 0)
                {
                    _tracer.TraceInfo("No custom data clean-up required.");
                }
                else
                {
                    _tracer.TraceInfo("Fast custom data clean-up.");
                }
                foreach (OutputAsset outputAsset in _oldOutputInstances.Values)
                {
                    if (DocumentProcessor.Plugins.GetExtendedTypeInformation(outputAsset.Handle.TypeId).HasCustomData)
                    {
                        File.Delete(Path.Combine(_assetDirectory, outputAsset.Handle.FileBase) + ".cdata");
                    }
                }
            }
            else
            {
                _tracer.TraceInfo("Slow custom data clean-up (expected: {0}, actual: {1}, old asset count: {2})", customDataFileCount, filesCData.Length, str, _assetFileCount);
                foreach (FileInfo fileInfo in filesCData)
                {
                    if (!Assets.ContainsKey(Path.GetFileNameWithoutExtension(fileInfo.Name).ToLowerInvariant()) || fileInfo.Extension != ".cdata")
                    {
                        fileInfo.Delete();
                    }
                }
            }
        }

        public void Dispose()
        {
            _header.Dispose();
            _header = null;
        }
    }
}
