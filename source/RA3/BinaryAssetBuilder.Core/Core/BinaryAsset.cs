using BinaryAssetBuilder.Utility;
using System;
using System.IO;
using System.Threading;

namespace BinaryAssetBuilder.Core
{
    public class BinaryAsset
    {
        private enum Availability
        {
            Invalid,
            Missing,
            Present
        }

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(BinaryAsset), "Provides output management for assets");
        private static readonly byte[] _copyBuffer = new byte[0x100000];
        private string _cacheDirectory;
        private string _customDataFileName;
        private AssetBuffer _buffer;
        private Availability _memoryAvailability;
        private Availability _cacheAvailability;
        private Availability _outputAvailability;
        private AssetLocationInfo _lastLocationInfo;
        private Availability _localAvailability;
        private Availability _basePatchStreamAvailability;
        private AssetHeader _assetHeader;
        private OutputManager _parent;

        public AssetBuffer Buffer
        {
            get => _buffer;
            set
            {
                _buffer = value;
                UpdateMemoryAvailability(true);
            }
        }
        public bool IsOutputAsset { get; set; }
        public string FileBase => Instance.Handle.FileBase;
        public InstanceDeclaration Instance { get; set; }
        public int InstanceFileSize
        {
            get
            {
                if (_assetHeader is null)
                {
                    UpdateAssetHeader(false);
                }
                return _assetHeader.InstanceDataSize;
            }
        }
        public int RelocationFileSize
        {
            get
            {
                if (_assetHeader is null)
                {
                    UpdateAssetHeader(false);
                }
                return _assetHeader.RelocationDataSize;
            }
        }
        public int ImportsFileSize
        {
            get
            {
                if (_assetHeader is null)
                {
                    UpdateAssetHeader(false);
                }
                return _assetHeader.ImportsDataSize;
            }
        }
        public string AssetFileName { get; }
        public string AssetOutputDirectory { get; }
        public string CustomDataOutputDirectory { get; }

        public BinaryAsset(OutputManager parent, OutputAsset oldInstance, InstanceDeclaration instance)
        {
            _parent = parent;
            if (Settings.Current.OldOutputFormat)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Old Output Format no longer supported.");
            }
            Instance = instance;
            CustomDataOutputDirectory = Path.Combine(_parent.OutputDirectory, "cdata");
            AssetOutputDirectory = Path.Combine(_parent.IntermediateOutputDirectory, "assets");
            _customDataFileName = FileBase + ".cdata";
            AssetFileName = FileBase + ".asset";
            if (!string.IsNullOrEmpty(_parent.TargetPlatformCacheRoot) && _parent.DocumentProcessor.Plugins.GetExtendedTypeInformation(instance.Handle.TypeId).UseBuildCache)
            {
                _cacheDirectory = Path.Combine(_parent.TargetPlatformCacheRoot, $"{instance.Handle.TypeName}\\{instance.Handle.TypeHash:x8}\\{instance.Handle.InstanceHash >> 24:x2}");
            }
            AssetLocation location = GetLocation(AssetLocation.All, AssetLocationOption.None);
            if (oldInstance is null || location == AssetLocation.None)
            {
                return;
            }
            UpdateAssetHeaderFromOldInstance(oldInstance);
        }

        private void UpdateMemoryAvailability(bool forceUpdate)
        {
            if (_memoryAvailability != Availability.Invalid && !forceUpdate)
            {
                return;
            }
            _memoryAvailability = _buffer != null && _buffer.InstanceData != null && _buffer.RelocationData != null && _buffer.ImportsData != null
                ? Availability.Present
                : Availability.Missing;
        }

        private void UpdateCacheAvailability(bool forceUpdate)
        {
            if (_cacheAvailability != Availability.Invalid && !forceUpdate)
            {
                return;
            }
            if (string.IsNullOrEmpty(_cacheDirectory))
            {
                _cacheAvailability = Availability.Missing;
            }
            else
            {
                string assetFileName = Path.Combine(_cacheDirectory, AssetFileName);
                string cdataFileName = Path.Combine(_cacheDirectory, _customDataFileName);
                _cacheAvailability = File.Exists(assetFileName) && (!Instance.HasCustomData || File.Exists(cdataFileName)) ? Availability.Present : Availability.Missing;
            }
        }

        private void UpdateOutputAvailability(bool forceUpdate)
        {
            if (_outputAvailability != Availability.Invalid && !forceUpdate)
            {
                return;
            }
            string assetFileName = Path.Combine(AssetOutputDirectory, AssetFileName);
            string cdataFileName = Path.Combine(CustomDataOutputDirectory, _customDataFileName);
            _outputAvailability = File.Exists(assetFileName) && (!Instance.HasCustomData || File.Exists(cdataFileName)) ? Availability.Present : Availability.Missing;
        }

        private void UpdateLocalAvailability(bool forceUpdate)
        {
            if (_localAvailability != Availability.Invalid && !forceUpdate)
            {
                return;
            }
            _lastLocationInfo = _parent.DocumentProcessor.GetLastWrittenAsset(FileBase);
            _localAvailability = _lastLocationInfo != null ? Availability.Present : Availability.Missing;
        }

        private void UpdateBasePatchStreamAvailability(bool forceUpdate)
        {
            if (_basePatchStreamAvailability != Availability.Invalid && !forceUpdate)
            {
                return;
            }
            _basePatchStreamAvailability = _parent.BasePatchStreamAssets != null && _parent.BasePatchStreamAssets.TryGetValue(FileBase, out _assetHeader)
                ? Availability.Present
                : Availability.Missing;
        }

        private void UpdateAssetHeader(bool forceUpdate)
        {
            if (_assetHeader != null && !forceUpdate)
            {
                return;
            }
            AssetLocation location = GetLocation(AssetLocation.Memory | AssetLocation.Output, AssetLocationOption.ReturnAll);
            if (location == AssetLocation.None)
            {
                _assetHeader = null;
            }
            else if ((location & AssetLocation.Memory) != AssetLocation.None)
            {
                _assetHeader = new AssetHeader
                {
                    TypeId = Instance.Handle.TypeId,
                    InstanceId = Instance.Handle.InstanceId,
                    TypeHash = Instance.Handle.TypeHash,
                    InstanceHash = Instance.Handle.InstanceHash,
                    InstanceDataSize = _buffer.InstanceData.Length,
                    RelocationDataSize = _buffer.RelocationData.Length,
                    ImportsDataSize = _buffer.ImportsData.Length
                };
            }
            else if ((location & AssetLocation.Output) != AssetLocation.None)
            {
                long fileLength = 0;
                string path = Path.Combine(AssetOutputDirectory, AssetFileName);
                using (Stream stream = File.OpenRead(path))
                {
                    _assetHeader = new AssetHeader();
                    _assetHeader.LoadFromStream(stream, Settings.Current.BigEndian);
                    fileLength = stream.Length;
                }
                if (_assetHeader.IsValidFileLength(fileLength))
                {
                    return;
                }
                _tracer.TraceError("Invalid asset file detected. Deleting {0}.", path);
                File.Delete(path);
                if ((GetLocation(AssetLocation.Cache, AssetLocationOption.None) & AssetLocation.Cache) == AssetLocation.None)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.UnexpectedSize, "Can't recover from last error. Please restart to rebuild asset.");
                }
                _tracer.TraceInfo("Checking build cache copy of asset.");
                string cachePath = Path.Combine(_cacheDirectory, AssetFileName);
                using (Stream stream = File.OpenRead(cachePath))
                {
                    _assetHeader = new AssetHeader();
                    _assetHeader.LoadFromStream(stream, Settings.Current.BigEndian);
                    fileLength = stream.Length;
                }
                if (!_assetHeader.IsValidFileLength(fileLength))
                {
                    _tracer.TraceError("Invalid cached asset file detected. Deleting {0}.", cachePath);
                    File.Delete(cachePath);
                    throw new BinaryAssetBuilderException(ErrorCode.UnexpectedSize, "Can't recover from last error. Please restart to rebuild asset.");
                }
                CommitFromCache();
            }
            else
            {
                _assetHeader = null;
            }
        }

        private void UpdateAssetHeaderFromOldInstance(OutputAsset oldInstance)
        {
            if (_assetHeader != null || GetLocation(AssetLocation.All, AssetLocationOption.None) == AssetLocation.None)
            {
                return;
            }
            if (oldInstance.InstanceFileSize == 0 && oldInstance.RelocationFileSize == 0 && oldInstance.ImportsFileSize == 0)
            {
                _tracer.TraceWarning("Suspicious file sizes for {0}. Reloading info from disk.", Instance);
                UpdateAssetHeader(true);
            }
            else
            {
                _assetHeader = new AssetHeader
                {
                    TypeId = oldInstance.Handle.TypeId,
                    InstanceId = oldInstance.Handle.InstanceId,
                    TypeHash = oldInstance.Handle.TypeHash,
                    InstanceHash = oldInstance.Handle.InstanceHash,
                    InstanceDataSize = oldInstance.InstanceFileSize,
                    RelocationDataSize = oldInstance.RelocationFileSize,
                    ImportsDataSize = oldInstance.ImportsFileSize
                };
            }
        }

        private bool CopyAsset(string sourceAssetPath, string sourceCustomDataPath)
        {
            string assetOutputPath = Path.Combine(AssetOutputDirectory, AssetFileName);
            string tmpOutputPath = assetOutputPath + ".tmp";
            string cdataOutputPath = Path.Combine(CustomDataOutputDirectory, _customDataFileName);
            _assetHeader = null;
            try
            {
                if (!Directory.Exists(AssetOutputDirectory))
                {
                    Directory.CreateDirectory(AssetOutputDirectory);
                }
                lock (_copyBuffer)
                {
                    using Stream sourceAssetStream = File.OpenRead(sourceAssetPath);
                    using (Stream destAssetStream = File.Open(tmpOutputPath, FileMode.Create, FileAccess.Write))
                    {
                        int bytesRead;
                        for (long length = sourceAssetStream.Length; length > 0L; length -= bytesRead)
                        {
                            bytesRead = sourceAssetStream.Read(_copyBuffer, 0, _copyBuffer.Length);
                            if (bytesRead < 16)
                            {
                                throw new Exception();
                            }
                            if (_assetHeader is null)
                            {
                                _assetHeader = new AssetHeader();
                                _assetHeader.LoadFromBuffer(_copyBuffer, Settings.Current.BigEndian);
                                if (_assetHeader.InstanceId != Instance.Handle.InstanceId
                                 || _assetHeader.TypeId != Instance.Handle.TypeId
                                 || _assetHeader.InstanceHash != Instance.Handle.InstanceHash
                                 || _assetHeader.TypeHash != Instance.Handle.TypeHash)
                                {
                                    throw new Exception();
                                }
                            }
                            destAssetStream.Write(_copyBuffer, 0, bytesRead);
                        }
                        destAssetStream.Flush();
                    }
                    File.Move(tmpOutputPath, assetOutputPath, true);
                }
                if (Instance.HasCustomData)
                {
                    if (!Directory.Exists(CustomDataOutputDirectory))
                    {
                        Directory.CreateDirectory(CustomDataOutputDirectory);
                    }
                    File.Copy(sourceCustomDataPath, cdataOutputPath, true);
                }
            }
            catch
            {
                if (File.Exists(assetOutputPath))
                {
                    File.Delete(assetOutputPath);
                }
                if (File.Exists(cdataOutputPath))
                {
                    File.Delete(cdataOutputPath);
                }
                return false;
            }
            return true;
        }

        private void CommitFromLocal()
        {
            UpdateLocalAvailability(false);
            if (_localAvailability == Availability.Missing)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Failure to commit asset {0} from last output", Instance);
            }
            if (CopyAsset(Path.Combine(_lastLocationInfo.AssetOutputDirectory, AssetFileName), Path.Combine(_lastLocationInfo.CustomDataOutputDirectory, _customDataFileName)))
            {
                _tracer.Message("{0} copied from previous output: {1}", DocumentProcessor.CurrentDocument, Instance);
            }
            else
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Failure to commit asset {0} from previous output", Instance);
            }
        }

        private void CommitFromCache()
        {
            UpdateCacheAvailability(false);
            if (_cacheAvailability == Availability.Missing)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Asset not available. Failure to commit asset {0} from network.", Instance);
            }
            string sourceAssetPath = Path.Combine(_cacheDirectory, AssetFileName);
            string sourceCDataPath = Path.Combine(_cacheDirectory, _customDataFileName);
            bool success = false;
            int tries = 0;
            do
            {
                try
                {
                    if (CopyAsset(sourceAssetPath, sourceCDataPath))
                    {
                        _tracer.Message("{0} copied from cache: {1}", DocumentProcessor.CurrentDocument, Instance);
                        success = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    _tracer.Message("{0} in use ({1}), re-attempting grab: {2}", DocumentProcessor.CurrentDocument, ex.Message, Instance);
                    success = false;
                }
                Thread.Sleep(500);
                ++tries;
            }
            while (tries < 20);
            if (!success)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError,
                                                      "Asset copy failed. Failure to commit asset {0} from network ({1}, {2})",
                                                      Instance,
                                                      sourceAssetPath,
                                                      sourceCDataPath);
            }
        }

        private void CommitFromMemory()
        {
            UpdateMemoryAvailability(false);
            if (_memoryAvailability == Availability.Missing)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Failure to commit asset {0} from memory", Instance);
            }
            if (!Directory.Exists(AssetOutputDirectory))
            {
                Directory.CreateDirectory(AssetOutputDirectory);
            }
            try
            {
                string path = Path.Combine(AssetOutputDirectory, AssetFileName);
                string tmpPath = path + ".tmp";
                using (Stream stream = File.Open(tmpPath, FileMode.Create, FileAccess.Write))
                {
                    _assetHeader = new AssetHeader
                    {
                        TypeId = Instance.Handle.TypeId,
                        InstanceId = Instance.Handle.InstanceId,
                        TypeHash = Instance.Handle.TypeHash,
                        InstanceHash = Instance.Handle.InstanceHash,
                        InstanceDataSize = _buffer.InstanceData.Length,
                        RelocationDataSize = _buffer.RelocationData.Length,
                        ImportsDataSize = _buffer.ImportsData.Length
                    };
                    _assetHeader.SaveToStream(stream, Settings.Current.BigEndian);
                    stream.Write(_buffer.InstanceData, 0, _buffer.InstanceData.Length);
                    stream.Write(_buffer.RelocationData, 0, _buffer.RelocationData.Length);
                    stream.Write(_buffer.ImportsData, 0, _buffer.ImportsData.Length);
                    stream.Flush();
                }
                File.Move(tmpPath, path, true);
                _buffer = null;
                _memoryAvailability = Availability.Missing;
            }
            catch (Exception ex)
            {
                throw new BinaryAssetBuilderException(ex, ErrorCode.InternalError, "Failure to commit asset {0} from memory", Instance);
            }
        }

        private void ValidateAssetCopies()
        {
        }

        private void TouchCache()
        {
            if (string.IsNullOrEmpty(_cacheDirectory))
            {
                if (!Directory.Exists(_cacheDirectory))
                {
                    return;
                }
            }
            try
            {
                FileInfo assetFile = new FileInfo(Path.Combine(_cacheDirectory, AssetFileName));
                if (assetFile.Exists)
                {
                    assetFile.CreationTime = assetFile.LastWriteTime = assetFile.LastAccessTime = DateTime.Now;
                }
                if (!Instance.HasCustomData)
                {
                    return;
                }
                FileInfo cdataFile = new FileInfo(Path.Combine(_cacheDirectory, _customDataFileName));
                if (!cdataFile.Exists)
                {
                    return;
                }
                cdataFile.CreationTime = cdataFile.LastWriteTime = cdataFile.LastAccessTime = DateTime.Now;
            }
            catch
            {
            }
        }

        private void CopyToCache()
        {
            if (string.IsNullOrEmpty(_cacheDirectory))
            {
                return;
            }
            if (GetLocation(AssetLocation.Output, AssetLocationOption.None) == AssetLocation.None)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Failure to copy asset {0} to network", Instance);
            }
            _tracer.Message("{0} Submitting to cache {1}", DocumentProcessor.CurrentDocument, Instance);
            try
            {
                if (!Directory.Exists(_cacheDirectory))
                {
                    Directory.CreateDirectory(_cacheDirectory);
                }
                string assetPath = Path.Combine(_cacheDirectory, AssetFileName);
                FileInfo assetFile = new FileInfo(assetPath);
                if (!assetFile.Exists)
                {
                    File.Copy(Path.Combine(AssetOutputDirectory, AssetFileName), assetPath);
                }
                else
                {
                    assetFile.CreationTime = assetFile.LastWriteTime = assetFile.LastAccessTime = DateTime.Now;
                }
                if (!Instance.HasCustomData)
                {
                    return;
                }
                string cdataPath = Path.Combine(_cacheDirectory, _customDataFileName);
                FileInfo cdataFile = new FileInfo(cdataPath);
                if (!cdataFile.Exists)
                {
                    File.Copy(Path.Combine(CustomDataOutputDirectory, _customDataFileName), cdataPath);
                }
                else
                {
                    cdataFile.CreationTime = cdataFile.LastWriteTime = cdataFile.LastAccessTime = DateTime.Now;
                }
            }
            catch
            {
                _tracer.Message("Failed to copy asset {0} to network", Instance);
            }
        }

        public AssetLocation GetLocation(AssetLocation locationFilter, AssetLocationOption options)
        {
            AssetLocation result = AssetLocation.None;
            bool forceUpdate = (options & AssetLocationOption.ForceUpdate) != AssetLocationOption.None;
            bool returnSingle = (options & AssetLocationOption.ReturnAll) == AssetLocationOption.None;
            if ((locationFilter & AssetLocation.BasePatchStream) != AssetLocation.None)
            {
                UpdateBasePatchStreamAvailability(forceUpdate);
                if (_basePatchStreamAvailability == Availability.Present)
                {
                    if (returnSingle)
                    {
                        return AssetLocation.BasePatchStream;
                    }
                    result |= AssetLocation.BasePatchStream;
                }
            }
            if ((locationFilter & AssetLocation.Output) != AssetLocation.None)
            {
                UpdateOutputAvailability(forceUpdate);
                if (_outputAvailability == Availability.Present)
                {
                    if (returnSingle)
                    {
                        return AssetLocation.Output;
                    }
                    result |= AssetLocation.Output;
                }
            }
            if ((locationFilter & AssetLocation.Memory) != AssetLocation.None)
            {
                UpdateMemoryAvailability(forceUpdate);
                if (_memoryAvailability == Availability.Present)
                {
                    if (returnSingle)
                    {
                        return AssetLocation.Memory;
                    }
                    result |= AssetLocation.Memory;
                }
            }
            if ((locationFilter & AssetLocation.Local) != AssetLocation.None)
            {
                UpdateLocalAvailability(forceUpdate);
                if (_localAvailability == Availability.Present)
                {
                    if (returnSingle)
                    {
                        return AssetLocation.Local;
                    }
                    result |= AssetLocation.Local;
                }
            }
            if ((locationFilter & AssetLocation.Cache) != AssetLocation.None)
            {
                UpdateCacheAvailability(forceUpdate);
                if (_cacheAvailability == Availability.Present)
                {
                    if (returnSingle)
                    {
                        return AssetLocation.Cache;
                    }
                    result |= AssetLocation.Cache;
                }
            }
            return result;
        }

        public AssetLocation Commit()
        {
            AssetLocation result = GetLocation(AssetLocation.All, AssetLocationOption.None);
            switch (result)
            {
                case AssetLocation.Memory:
                    CommitFromMemory();
                    goto case AssetLocation.BasePatchStream;
                case AssetLocation.Output:
                    UpdateAssetHeader(false);
                    goto case AssetLocation.BasePatchStream;
                case AssetLocation.Local:
                    CommitFromLocal();
                    goto case AssetLocation.BasePatchStream;
                case AssetLocation.Cache:
                    CommitFromCache();
                    goto case AssetLocation.BasePatchStream;
                case AssetLocation.BasePatchStream:
                    if (result != AssetLocation.BasePatchStream)
                    {
                        UpdateOutputAvailability(true);
                    }
                    if (_outputAvailability == Availability.Missing)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Failure to commit asset {0}", Instance);
                    }
                    switch (result)
                    {
                        case AssetLocation.Memory:
                            CopyToCache();
                            break;
                        case AssetLocation.Cache:
                            TouchCache();
                            break;
                        default:
                            if (!Settings.Current.AlwaysTouchCache)
                            {
                                break;
                            }
                            goto case AssetLocation.Cache;
                    }
                    return result;
                default:
                    throw new BinaryAssetBuilderException(ErrorCode.DependencyCacheFailure, "Attempted to commit non-existing asset {0}", Instance);
            }
        }
    }
}