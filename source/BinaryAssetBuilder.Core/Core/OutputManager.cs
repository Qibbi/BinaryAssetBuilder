using BinaryAssetBuilder.Utility;
using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryAssetBuilder.Core
{
    public class OutputManager
    {
        private const int _linkedBufferSize = 0x10000;

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(OutputManager), "Provides manifest serialization functionality");
        private static readonly InstanceHandle _breakHandle = new InstanceHandle(0x21E727DAu, 0xAE184C44u);
        private static readonly byte[] _linkedBuffer = new byte[_linkedBufferSize];

        private readonly IDictionary<string, OutputAsset> _oldOutputInstances = new SortedDictionary<string, OutputAsset>();
        private readonly IDictionary<string, BinaryAsset> _assets = new SortedDictionary<string, BinaryAsset>();
        private int _assetFileCount;
        private int _customDataFileCount;
        private string _outputDirectory;
        private string _intermediateOutputDirectory;
        private string _assetDirectory;
        private string _customDataDirectory;
        private TargetPlatform _targetPlatform;
        private bool _isLinked;
        private bool _validOldOutputInstances;
        private string _targetPlatformCacheRoot;
        private string _manifestFile;
        private string _oldManifestFile;
        private string _versionFile;
        private DocumentProcessor _documentProcessor;
        private string _basePatchStream;
        private IDictionary<string, AssetHeader> _basePatchStreamAssets;
        private Manifest _basePatchStreamManifest;
        private ManifestHeader _header;

        public IDictionary<string, BinaryAsset> Assets => _assets;
        public DocumentProcessor DocumentProcessor => _documentProcessor;
        public string IntermediateOutputDirectory => _intermediateOutputDirectory;
        public string OutputDirectory => _outputDirectory;
        public string TargetPlatformCacheRoot => _targetPlatformCacheRoot;
        public IDictionary<string, AssetHeader> BasePatchStreamAssets => _basePatchStreamAssets;
        public Manifest BasePatchStreamManifest => _basePatchStreamManifest;
        public string BasePatchStream => _basePatchStream;

        public OutputManager(DocumentProcessor documentProcessor,
                             IEnumerable<OutputAsset> lastOutputInstances,
                             string outputDirectory,
                             string intermediateOutputDirectory,
                             string basePatchStream)
        {
            _documentProcessor = documentProcessor;
            _outputDirectory = outputDirectory;
            _intermediateOutputDirectory = intermediateOutputDirectory;
            _targetPlatform = Settings.Current.TargetPlatform;
            _isLinked = Settings.Current.LinkedStreams;
            _assetDirectory = Path.Combine(_intermediateOutputDirectory, "assets");
            _customDataDirectory = Path.Combine(_outputDirectory, "cdata");
            _targetPlatformCacheRoot = Settings.Current.UseBuildCache ? Path.Combine(Settings.Current.BuildCacheDirectory, _targetPlatform.ToString()) : null;
            _manifestFile = _outputDirectory + ".manifest";
            _oldManifestFile = _outputDirectory + ".old.manifest";
            _versionFile = _outputDirectory + ".version";
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
            if (Directory.Exists(_intermediateOutputDirectory) && lastOutputInstances != null)
            {
                _validOldOutputInstances = true;
                foreach (OutputAsset lastOutputInstance in lastOutputInstances)
                {
                    _oldOutputInstances.Add(lastOutputInstance.Handle.FileBase, lastOutputInstance);
                }
            }
            if (basePatchStream is null || !File.Exists(basePatchStream))
            {
                return;
            }
            ProcessBasePatchStream(basePatchStream);
        }

        private void ProcessBasePatchStream(string basePatchStream)
        {
            Manifest manifest = new Manifest();
            string[] patchSearchPaths = new[] { Settings.Current.OutputDirectory };
            try
            {
                manifest.Load(basePatchStream, patchSearchPaths);
            }
            catch
            {
                _tracer.TraceError("Could not load {0}.", basePatchStream);
                return;
            }
            _basePatchStream = basePatchStream;
            _basePatchStreamAssets = new SortedDictionary<string, AssetHeader>();
            foreach (Asset asset in manifest.Assets)
            {
                _basePatchStreamAssets.Add(Path.GetFileName(asset.FileBasePath), new AssetHeader
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
            throw new NotImplementedException();
        }

        public void CreateVersionFile(AssetDeclarationDocument document, string streamPostfix)
        {
            using (StreamWriter writer = File.CreateText(_versionFile))
            {
                if (!string.IsNullOrEmpty(streamPostfix))
                {
                    writer.Write(streamPostfix);
                }
                else
                {
                    writer.Write("  ");
                }
            }
        }

        public void CommitManifest(AssetDeclarationDocument document)
        {
            throw new NotImplementedException();
        }

        public void CleanOutput()
        {
            throw new NotImplementedException();
        }

        public void LinkStream(AssetDeclarationDocument document)
        {
            throw new NotImplementedException();
        }
    }
}