using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.SageXml;
using BinaryAssetBuilder.Core.Xml;
using BinaryAssetBuilder.Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;

namespace BinaryAssetBuilder.Core.Session
{
    public class SessionCache : ISessionCache
    {
        private class FileConfig
        {
            public List<FileItem> All = new List<FileItem>();
            public FileItem LastCached;
        }

        private class CurrentState
        {
            public IDictionary<string, FileConfig> FileConfigs;
            public IDictionary<string, FileItem> Files;
            public DateTime Created;
            public uint AssetCompilersVersion;

            public void FromScratch()
            {
                FileConfigs = new SortedDictionary<string, FileConfig>();
                Files = new SortedDictionary<string, FileItem>();
                Created = DateTime.Now;
                AssetCompilersVersion = 0u;
            }

            public void FromLast(LastState last)
            {
                FileConfigs = new SortedDictionary<string, FileConfig>();
                Files = new SortedDictionary<string, FileItem>();
                Created = last.Created;
                AssetCompilersVersion = last.AssetCompilersVersion;
                foreach (FileItem file in last.Files)
                {
                    string lower = file.HashItem.Path.ToLower();
                    if (!FileConfigs.TryGetValue(lower, out FileConfig fileConfig))
                    {
                        fileConfig = new FileConfig();
                        FileConfigs[lower] = fileConfig;
                    }
                    fileConfig.All.Add(file);
                    if (file.Document is not null)
                    {
                        fileConfig.LastCached = file;
                    }
                    string postfix = GetPostfix(file.HashItem.BuildConfiguration, file.HashItem.TargetPlatform);
                    Files[lower + postfix] = file;
                }
            }
        }

        private class LastState : ISerializable
        {
            private FileItem[] _files;
            private uint _assetCompilersVersion;

            public FileItem[] Files { get => _files; set => _files = value; }
            public uint Version { get; set; }
            public uint AssetCompilersVersion => _assetCompilersVersion;
            public DateTime Created { get; set; }
            public uint DocumentProcessorVersion { get; set; }

            public void FromCurrent(CurrentState current)
            {
                if (current.Files.Count > 0)
                {
                    List<FileItem> files = new List<FileItem>();
                    foreach (FileItem fileItem in current.Files.Values)
                    {
                        if (fileItem.HashItem.Exists)
                        {
                            files.Add(fileItem);
                        }
                    }
                    _files = files.ToArray();
                }
                else
                {
                    _files = Array.Empty<FileItem>();
                }
                Created = current.Created;
                Version = CacheVersion;
                DocumentProcessorVersion = DocumentProcessor.Version;
                _assetCompilersVersion = current.AssetCompilersVersion;
            }

            public void ReadXml(Node node)
            {
                string[] values = node.GetAttributeValue("d", null).GetText().Split(';');
                Created = Convert.ToDateTime(values[0]);
                Version = Convert.ToUInt32(values[1]);
                DocumentProcessorVersion = Convert.ToUInt32(values[2]);
                _assetCompilersVersion = Convert.ToUInt32(values[3]);
                Marshaler.Marshal(node.GetChildNodes(nameof(FileItem)), ref _files);
            }

            public void WriteXml(XmlWriter writer)
            {
                writer.WriteAttributeString("d", $"{Created};{Version};{DocumentProcessorVersion};{AssetCompilersVersion}");
                foreach (FileItem item in _files)
                {
                    writer.WriteStartElement(nameof(FileItem));
                    item.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
        }

#if VERSION5
        public const uint CacheVersion = 16u;
#else
        public const uint CacheVersion = 18u;
#endif

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(SessionCache), "Provides caching functionality");

        private CurrentState _current;
        private LastState _last;

        private List<string> _dirtyStreams;
        private string _cacheFileName;

        private TimeSpan Age => DateTime.Now - _last.Created;

        public virtual string CacheFileName => _cacheFileName;
        public virtual List<string> DirtyStreams => _dirtyStreams;
        public virtual uint AssetCompilersVersion { get => _current.AssetCompilersVersion; set => _current.AssetCompilersVersion = value; }

        private static string GetPostfix(string configuration, TargetPlatform platform)
        {
            string str = string.IsNullOrEmpty(configuration) ? string.Empty : ":" + configuration;
            if (platform != TargetPlatform.Win32)
            {
                str += ":" + (int)platform;
            }
            return str;
        }

        private void CheckFiles(List<string> knownChangedFiles)
        {
            bool hasChangedFiles = knownChangedFiles.Count == 0;
            if (_last is null)
            {
                return;
            }
            if (_last.Version != CacheVersion)
            {
                _tracer.TraceInfo("Session cache outdated. Version is {0}. Expected version {1}.", _last.Version, CacheVersion);
                _last = null;
            }
            else if (_last.DocumentProcessorVersion != DocumentProcessor.Version)
            {
                _tracer.TraceInfo("Document Processor mismatch. Version is {0}. Expected version {1}.", _last.DocumentProcessorVersion, DocumentProcessor.Version);
                _last = null;
            }
            else
            {
                _tracer.TraceInfo("Checking {0} files for updates.", _last.Files.Length);
                int num = 0;
                foreach (FileItem file in _last.Files)
                {
                    if (file.Document is not null)
                    {
                        file.Document.ResetState();
                    }
                    if (file.HashItem is not null)
                    {
                        if (file.HashItem.IsDirty)
                        {
                            if (_dirtyStreams is not null)
                            {
                                if (file.Document is null || file.Document.StreamHints.Count == 0)
                                {
                                    _tracer.TraceInfo("Building all streams because {0} has no stream hints.", file.HashItem.Path);
                                    _dirtyStreams = null;
                                }
                                else
                                {
                                    foreach (string streamHint in file.Document.StreamHints)
                                    {
                                        if (!_dirtyStreams.Contains(streamHint))
                                        {
                                            _dirtyStreams.Add(streamHint);
                                        }
                                    }
                                }
                            }
                        }
                        file.HashItem.Reset();
                    }
                    ++num;
                    if (!hasChangedFiles && !knownChangedFiles.Contains(file.HashItem.Path))
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.PathMonitor, "Change went undetected by Path Monitor. File: {0}", file.HashItem.Path);
                    }
                }
            }
        }
        private bool TryGetFileItem(string path, string configuration, TargetPlatform platform, out FileItem documentItem, bool autoCreateDocument)
        {
            path = path.ToLower();
            configuration = configuration?.ToLower();
            string key = path + GetPostfix(configuration, platform);
            if (!_current.Files.TryGetValue(key, out documentItem))
            {
                documentItem = new FileItem
                {
                    HashItem = new FileHashItem(path, configuration, platform)
                };
                if (documentItem.HashItem.Exists)
                {
                    _current.Files[key] = documentItem;
                    if (!_current.FileConfigs.TryGetValue(path, out FileConfig fileConfig))
                    {
                        fileConfig = new FileConfig();
                        _current.FileConfigs[path] = fileConfig;
                    }
                    fileConfig.All.Add(documentItem);
                    if (documentItem.Document is not null)
                    {
                        fileConfig.LastCached = documentItem;
                    }
                }
            }
            if (autoCreateDocument && documentItem.Document is null)
            {
                documentItem.Document = new AssetDeclarationDocument();
                if (!_current.FileConfigs.TryGetValue(path, out FileConfig fileConfig))
                {
                    fileConfig = new FileConfig();
                    _current.FileConfigs[path] = fileConfig;
                }
                fileConfig.LastCached = documentItem;
            }
            return documentItem.HashItem.Exists;
        }
        private void MakeCacheable()
        {
            _last = new LastState();
            _last.FromCurrent(_current);
        }

        public virtual void LoadCache(string sessionCachePath)
        {
            if (!string.IsNullOrEmpty(sessionCachePath))
            {
                try
                {
                    if (File.Exists(sessionCachePath + ".deflate"))
                    {
                        _tracer.TraceInfo("Loading compressed XML cache");
                        using Stream stream = new FileStream(sessionCachePath + ".deflate", FileMode.Open, FileAccess.Read, FileShare.Read);
                        BinaryAssetBuilderDocument babDoc = new BinaryAssetBuilderDocument(new DeflateStream(stream, CompressionMode.Decompress));
                        _last = new LastState();
                        _last.ReadXml(babDoc.GetNode(nameof(SessionCache)));
                    }
                    else if (File.Exists(sessionCachePath))
                    {
                        _tracer.TraceInfo("Loading XML cache");
                        using Stream stream = new FileStream(sessionCachePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        BinaryAssetBuilderDocument babDoc = new BinaryAssetBuilderDocument(stream);
                        _last = new LastState();
                        _last.ReadXml(babDoc.GetNode(nameof(SessionCache)));
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        File.Move(sessionCachePath, sessionCachePath + ".corrupt", true);
                    }
                    catch
                    {
                    }
                    try
                    {
                        File.Move(sessionCachePath + ".deflate", sessionCachePath + ".deflate.corrupt", true);
                    }
                    catch
                    {
                    }
                    _tracer.TraceInfo("Session cache file '{0}' could not be opened: {1}\nPlease rebuild", sessionCachePath, ex.Message);
                    throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Session cache could not be opened.\nPlease rebuild");
                }
            }
            _cacheFileName = sessionCachePath;
            if (_last is null)
            {
                return;
            }
            _tracer.TraceInfo("Session cache age is {0} days, {1} hours, {2} minutes.", Age.Days, Age.Hours, Age.Minutes);
        }

        public virtual void InitializeCache(List<string> knownChangedFiles)
        {
            _current = new CurrentState();
            _dirtyStreams = new List<string>();
            CheckFiles(knownChangedFiles);
            if (_last is not null)
            {
                _tracer.TraceInfo("Cached session data available.");
                _current.FromLast(_last);
            }
            else
            {
                _tracer.TraceInfo("Cached session data not available.");
                _current.FromScratch();
                _dirtyStreams = null;
            }
        }

        public virtual void SaveCache(bool saveCompressed)
        {
            MakeCacheable();
            string directoryName = Path.GetDirectoryName(CacheFileName);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            string cacheFileName = CacheFileName;
            if (saveCompressed)
            {
                cacheFileName += ".deflate";
            }
            using (Stream stream = new FileStream(cacheFileName + ".tmp", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Stream w = stream;
                if (saveCompressed)
                {
                    w = new DeflateStream(stream, CompressionMode.Compress);
                }
                BinaryAssetBuilderDocument.WriteXml(w, nameof(SessionCache), _last.WriteXml);
                MetricManager.Submit("BAB.SessionCacheSize", stream.Position);
            }
            if (File.Exists(cacheFileName))
            {
                File.Move(cacheFileName, cacheFileName + ".old", true);
            }
            File.Move(cacheFileName + ".tmp", cacheFileName);
        }

        public virtual bool TryGetFile(string path, string configuration, TargetPlatform targetPlatform, out FileHashItem hashItem)
        {
            TryGetFileItem(path, configuration, targetPlatform, out FileItem documentItem, false);
            hashItem = documentItem.HashItem;
            return hashItem.Exists;
        }

        public virtual bool TryGetDocument(string path, string configuration, TargetPlatform targetPlatform, bool autoCreateDocument, out AssetDeclarationDocument document)
        {
            TryGetFileItem(path, configuration, targetPlatform, out FileItem documentItem, autoCreateDocument);
            document = documentItem.Document;
            return documentItem.HashItem.Exists;
        }

        public virtual void SaveDocumentToCache(string path, string configuration, TargetPlatform targetPlatform, AssetDeclarationDocument document)
        {
            path = path.ToLower();
            configuration = configuration?.ToLower();
            if (!_current.Files.TryGetValue(path + GetPostfix(configuration, targetPlatform), out FileItem fileItem))
            {
                return;
            }
            fileItem.Document = document;
        }
    }
}
