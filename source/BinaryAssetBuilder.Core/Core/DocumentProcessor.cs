using BinaryAssetBuilder.Utility;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace BinaryAssetBuilder.Core
{
    public class DocumentProcessor
    {
        public class ProcessOptions
        {
            public string BasePatchStream;
            public bool GenerateOutput;
            public string Configuration;
            public bool UsePrecompiled;
        }

        [NonSerialized] public const uint Version = 10;

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(DocumentProcessor), "Provides XML processing functionality");
        private static readonly InstanceHandleSet _missingReferences = new InstanceHandleSet();
        private static TimeSpan _totalProcInstancesTime = new TimeSpan(0L);
        private static TimeSpan _totalPrepareOutputTime = new TimeSpan(0L);
        private static TimeSpan _totalPrepareSourceTime = new TimeSpan(0L);
        private static TimeSpan _totalPostProcTime = new TimeSpan(0L);
        private static TimeSpan _totalValidateTime = new TimeSpan(0L);
        private static readonly Stack<string> _currentDocumentStack = new Stack<string>();

        private readonly StringCollection _documentStack = new StringCollection();
        [NonSerialized] private readonly Dictionary<string, AssetLocationInfo> _lastWrittenAssets = new Dictionary<string, AssetLocationInfo>();
        private int _instancesProcessedCount;
        private int _filesProcessedCount;
        private int _filesParsedCount;
        private int _instancesCopiedFromCacheCount;
        private int _instancesCompiledCount;
        private readonly string _sessionCachePath;
        private long _maxTotalMemory;

        public static string CurrentDocument => _currentDocumentStack.Peek();

        public SessionCache Cache { get; private set; }
        public InstanceHandleSet MissingReferences => _missingReferences;
        public InstanceHandleSet ChangedInheritFromReferences { get; } = new InstanceHandleSet();
        public SchemaSet SchemaSet { get; }
        public PluginRegistry Plugins { get; }
        public VerifierPluginRegistry VerifierPlugins { get; }

        public DocumentProcessor(Settings settings, PluginRegistry pluginRegistry, VerifierPluginRegistry verifierPluginRegistry)
        {
            Plugins = pluginRegistry;
            VerifierPlugins = verifierPluginRegistry;
            if (Settings.Current.SingleFile)
            {
                _tracer.TraceInfo("Single file mode enabled.");
                Settings.Current.UseBuildCache = false;
            }
            _tracer.TraceData("Build Cache Status: {0}", Settings.Current.UseBuildCache ? "Active" : "Disabled");
            if (Settings.Current.UseSessionCache)
            {
                _sessionCachePath = Path.Combine(settings.SessionCacheDirectory, $"{nameof(BinaryAssetBuilder)}.{nameof(SessionCache)}.{settings.TargetPlatform}.xml");
            }
            MetricManager.Submit("BAB.NetworkCacheEnabled", Settings.Current.UseBuildCache);
            if (Settings.Current.UseBuildCache)
            {
                _tracer.TraceInfo("Network caching enabled ('{0}').", Settings.Current.BuildCacheDirectory);
            }
            SchemaSet = new SchemaSet(Settings.Current.StableSort);
        }

        private void InitializeSessionCache()
        {
            MetricManager.Submit("BAB.SessionCacheEnabled", Settings.Current.UseSessionCache);
            if (!Settings.Current.UseSessionCache)
            {
                if (File.Exists(_sessionCachePath) && !Settings.Current.SingleFile)
                {
                    File.Delete(_sessionCachePath);
                }
            }
            else
            {
                _tracer.TraceInfo("Session caching enabled ('{0}').", _sessionCachePath);
                Cache = new SessionCache();
                Cache.LoadCache(_sessionCachePath);
                Cache.InitializeCache();
            }
        }

        private void FinalizeSessionCache()
        {
            if (Cache != null)
            {
                Cache.SaveCache(false);
            }
        }

        private AssetDeclarationDocument OpenDocument(string sourcePath, string logicalPath, string configuration)
        {
            if (!Path.IsPathRooted(sourcePath))
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Path for document {0} is not rooted.", sourcePath);
            }
            Cache.TryGetFile(sourcePath, configuration, Settings.Current.TargetPlatform, out FileHashItem hashItem);
            Cache.TryGetDocument(sourcePath, configuration, Settings.Current.TargetPlatform, true, out AssetDeclarationDocument result);
            if (result.Processing)
            {
                StringBuilder sb = new StringBuilder("Illegal circular document inclusion detected. Inclusion chain as follows:");
                foreach (string doc in _documentStack)
                {
                    sb.AppendFormat("\n   {0}", doc);
                }
                sb.AppendFormat("\n   {0}", sourcePath);
                throw new BinaryAssetBuilderException(ErrorCode.CircularDependency, sb.ToString());
            }
            result.Open(this, hashItem, logicalPath, configuration);
            if (result.State != DocumentState.Complete)
            {
                ++_filesProcessedCount;
            }
            return result;
        }

        private void ProcessIncludedDocuments(AssetDeclarationDocument document, OutputManager outputManager, ProcessOptions options, bool usePrecompiled)
        {
            DateTime now = DateTime.Now;
            string configuration = options.Configuration;
            document.TentativeInstances.Clear();
            document.AllInstances.Clear();
            document.ReferenceInstances.Clear();
            document.AllDefines.Clear();
            if (document.IsLoaded)
            {
                foreach (InstanceDeclaration selfInstance in document.SelfInstances)
                {
                    if (selfInstance.InheritFromHandle != null)
                    {
                        ChangedInheritFromReferences.TryAdd(selfInstance.InheritFromHandle);
                    }
                }
            }
            foreach (InclusionItem inclusionItem in document.InclusionItems)
            {
                if (inclusionItem.Type == InclusionType.Reference && !Settings.Current.SingleFile && Settings.Current.DataRoot is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.NoDataRootSpecified, "DataRoot must be specified if not doing /singleFile");
                }
                bool valid = Cache.TryGetFile(inclusionItem.PhysicalPath, configuration, Settings.Current.TargetPlatform, out FileHashItem fileItem);
                if (inclusionItem.Type != InclusionType.Reference || (valid && !Settings.Current.UsePrecompiled) || !LoadPrecompiledReference(document, inclusionItem))
                {
                    if (!valid)
                    {
                        _tracer.TraceError("Input file '{0}' not found (referenced from file://{1}). Treating it as empty.", inclusionItem.LogicalPath, document.SourcePath);
                    }
                    _totalPostProcTime += DateTime.Now - now;
                    ProcessOptions newOptions = new ProcessOptions
                    {
                        GenerateOutput = inclusionItem.Type == InclusionType.Reference && !usePrecompiled,
                        UsePrecompiled = usePrecompiled,
                        Configuration = configuration
                    };
                    AssetDeclarationDocument assetDocument = ProcessDocumentInternal(inclusionItem.LogicalPath, inclusionItem.PhysicalPath, valid ? null : outputManager, newOptions);
                    now = DateTime.Now;
                    inclusionItem.Document = assetDocument;
                    document.AllDefines.AddDefinitions(assetDocument.AllDefines);
                    switch (inclusionItem.Type)
                    {
                        case InclusionType.Reference:
                            document.ReferenceInstances.Add(assetDocument.ReferenceInstances);
                            document.ReferenceInstances.Add(assetDocument.Instances);
                            break;
                        case InclusionType.Instance:
                            document.TentativeInstances.Add(assetDocument.Instances);
                            document.TentativeInstances.Add(assetDocument.TentativeInstances);
                            break;
                        case InclusionType.All:
                            document.ReferenceInstances.Add(assetDocument.ReferenceInstances);
                            document.AllInstances.Add(assetDocument.Instances);
                            document.TentativeInstances.Add(assetDocument.TentativeInstances);
                            break;
                    }
                    assetDocument.Reset();
                    _totalPostProcTime += DateTime.Now - now;
                }
            }
            foreach (InstanceDeclaration referenceInstance in document.ReferenceInstances)
            {
                if (document.AllInstances.TryGetValue(referenceInstance.Handle, out InstanceDeclaration assetDeclaration) && assetDeclaration.Document == referenceInstance.Document)
                {
                    document.AllInstances.Remove(assetDeclaration);
                }
                if (document.TentativeInstances.TryGetValue(referenceInstance.Handle, out assetDeclaration) && assetDeclaration.Document == referenceInstance.Document)
                {
                    document.TentativeInstances.Remove(assetDeclaration);
                }
            }
            document.EvaluateDefinitions();
        }

        private void ProcessDocumentContents(AssetDeclarationDocument document, OutputManager outputManager, ProcessOptions options, bool generateOutput)
        {
            if (document.State != DocumentState.Loaded && !document.ValidateInheritFromSources())
            {
                document.InplaceLoad("inheritFrom source changed");
                ProcessIncludedDocuments(document, outputManager, options, false);
            }
            if (document.State != DocumentState.Loaded && !document.ValidateCachedDefines())
            {
                document.InplaceLoad("used definitions changed");
                ProcessIncludedDocuments(document, outputManager, options, false);
            }
            if (document.State == DocumentState.Loaded)
            {
                DateTime now = DateTime.Now;
                ++_filesParsedCount;
                document.ProcessExpressions();
                document.ProcessOverrides();
                document.Validate();
                _totalValidateTime += DateTime.Now - now;
            }
            _instancesProcessedCount += document.SelfInstances.Count;
            document.RecordStringHashes();
            document.MergeInstances();
            if (outputManager != null)
            {
                DateTime now = DateTime.Now;
                document.ProcessInstances(outputManager, ref _instancesCompiledCount, ref _instancesCopiedFromCacheCount);
                _totalProcInstancesTime += DateTime.Now - now;
            }
            if (generateOutput)
            {
                DateTime now = DateTime.Now;
                _tracer.Message("Resolving references: {0}", document.SourcePathFromRoot);
                document.PrepareOutputInstances(outputManager);
                _tracer.Message("Generating stream: {0}", document.SourcePathFromRoot);
                outputManager.CommitManifest(document);
                outputManager.CleanOutput();
                document.UpdateOutputAssets(outputManager);
                if (Settings.Current.LinkedStreams)
                {
                    outputManager.LinkStream(document);
                }
                if (Settings.Current.VersionFiles)
                {
                    outputManager.CreateVersionFile(document, Settings.Current.StreamPostfix);
                }
                _tracer.Message("{0} Stream complete", document.SourcePathFromRoot);
                _totalPrepareOutputTime += DateTime.Now - now;
            }
            _documentStack.RemoveAt(_documentStack.Count - 1);
            document.MakeComplete();
        }

        private AssetDeclarationDocument ProcessDocumentInternal(string logicalPath, string sourcePath, OutputManager outputManager, ProcessOptions options)
        {
            DateTime now = DateTime.Now;
            AssetDeclarationDocument result = OpenDocument(sourcePath, logicalPath, options.Configuration);
            if (options.GenerateOutput)
            {
                if (result.State == DocumentState.Complete)
                {
                    return result;
                }
                if (!Settings.Current.SingleFile && string.IsNullOrEmpty(result.SourcePathFromRoot))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.IllegalPath,
                                                          "{0} is a stream (.manifest) but does not have {1} as its root.",
                                                          sourcePath,
                                                          Settings.Current.DataRoot);
                }
                string str = ShPath.Canonicalize(Path.Combine(Settings.Current.IntermediateOutputDirectory, result.SourcePathFromRoot));
                string outputDirectory = ShPath.Canonicalize(Path.Combine(Settings.Current.OutputDirectory, result.SourcePathFromRoot)) + Settings.Current.StreamPostfix;
                string intermediateOutputDirectory = str + Settings.Current.StreamPostfix;
                outputManager = new OutputManager(this, result.LastOutputAssets, outputDirectory, intermediateOutputDirectory, options.BasePatchStream);
            }
            string fileName = Path.GetFileName(sourcePath);
            _currentDocumentStack.Push($"{fileName}:");
            if (result.State == DocumentState.Shallow)
            {
                result.Reinitialize(outputManager);
            }
            if (!result.IsLoaded)
            {
                result.ReloadIfRequired(ChangedInheritFromReferences);
            }
            _documentStack.Add(sourcePath);
            result.Processing = true;
            _totalPrepareSourceTime += DateTime.Now - now;
            ProcessIncludedDocuments(result, outputManager, options, options.UsePrecompiled);
            if (result.State != DocumentState.Complete)
            {
                ProcessDocumentContents(result, outputManager, options, options.GenerateOutput);
            }
            result.Processing = false;
            _currentDocumentStack.Pop();
            _maxTotalMemory = Math.Max(_maxTotalMemory, GC.GetTotalMemory(false));
            return result;
        }

        private bool LoadPrecompiledReference(AssetDeclarationDocument parentDoc, InclusionItem item)
        {
            string expectedOutputManfiest = GetExpectedOutputManifest(parentDoc, item);
            string str = ShPath.Canonicalize(Path.Combine(Settings.Current.OutputDirectory, expectedOutputManfiest));
            if (!File.Exists(str))
            {
                return false;
            }
            Manifest manifest = new Manifest();
            string[] patchSearchPaths = new[] { Settings.Current.OutputDirectory };
            try
            {
                manifest.Load(str, patchSearchPaths);
            }
            catch
            {
                _tracer.TraceError("Could not load {0}.", str);
                return false;
            }
            foreach (Asset asset in manifest.Assets)
            {
                InstanceDeclaration instanceDeclaration = new InstanceDeclaration();
                instanceDeclaration.InitializePrecompiled(asset);
                parentDoc.ReferenceInstances.Add(instanceDeclaration);
            }
            return true;
        }

        private void TryDeleteFile(string path)
        {
            if (!File.Exists(path))
            {
                return;
            }
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                throw new BinaryAssetBuilderException(ex,
                                                      ErrorCode.LockedFile,
                                                      "Unable to delete '{0}'. Make sure no other application is writing or reading from this file while the data build is running.",
                                                      path);
            }
        }

        public void AddLastWrittenAsset(BinaryAsset asset)
        {
            if (_lastWrittenAssets.ContainsKey(asset.FileBase))
            {
                return;
            }
            _lastWrittenAssets.Add(asset.FileBase, new AssetLocationInfo
            {
                AssetOutputDirectory = asset.AssetOutputDirectory,
                CustomDataOutputDirectory = asset.CustomDataOutputDirectory
            });
        }

        public AssetLocationInfo GetLastWrittenAsset(string key)
        {
            _lastWrittenAssets.TryGetValue(key, out AssetLocationInfo result);
            return result;
        }

        public AssetDeclarationDocument ProcessDocument(string fileName, bool generateOutput, bool outputStringHashes)
        {
            XIncludeReaderWrapper.LoadAssembly();
            ExpressionEvaluatorWrapper.LoadAssembly();
            DateTime now = DateTime.Now;
            using (new MetricTimer("BAB.ProcessingTime"))
            {
                if (!File.Exists(fileName))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InputXmlFileNotFound, "File {0} not found", fileName);
                }
                MetricManager.Submit("BAB.MapName", Path.GetFileName(Path.GetDirectoryName(fileName)));
                HashProvider.InitializeStringHashes();
                InitializeSessionCache();
                MetricManager.Submit("BAB.StartupTime", DateTime.Now - now);
                now = DateTime.Now;
                bool success = false;
                AssetDeclarationDocument document = null;
                try
                {
                    document = ProcessDocumentInternal(fileName,
                                                       fileName,
                                                       null,
                                                       new ProcessOptions
                                                       {
                                                           BasePatchStream = Settings.Current.BasePatchStream,
                                                           Configuration = Settings.Current.BuildConfigurationName,
                                                           GenerateOutput = generateOutput
                                                       });
                    success = true;
                }
                finally
                {
                    MetricManager.Submit("BAB.PrepSourceTime", _totalPrepareSourceTime);
                    MetricManager.Submit("BAB.ProcIncludesTime", _totalPostProcTime);
                    MetricManager.Submit("BAB.ValidateTime", _totalValidateTime);
                    MetricManager.Submit("BAB.InstanceProcessingTime", _totalProcInstancesTime);
                    MetricManager.Submit("BAB.OutputPrepTime", _totalPrepareOutputTime);
                    MetricManager.Submit("BAB.DocumentProcessingTime", DateTime.Now - now);
                    now = DateTime.Now;
                    if ((success || Settings.Current.PartialSessionCache) && !Settings.Current.FreezeSessionCache)
                    {
                        FinalizeSessionCache();
                    }
                    if (outputStringHashes)
                    {
                        HashProvider.FinalizeStringHashes(Settings.Current.IntermediateOutputDirectory);
                    }
                    MetricManager.Submit("BAB.LinkedStreamsEnabled", Settings.Current.LinkedStreams);
                    MetricManager.Submit("BAB.MaxMemorySize", _maxTotalMemory);
                    MetricManager.Submit("BAB.FilesProcessedCount", (long)_filesProcessedCount);
                    MetricManager.Submit("BAB.FilesParsedCount", (long)_filesParsedCount);
                    MetricManager.Submit("BAB.InstancesProcessedCount", (long)_instancesProcessedCount);
                    MetricManager.Submit("BAB.InstancesCompiledCount", (long)_instancesCompiledCount);
                    MetricManager.Submit("BAB.InstancesCopiedFromCacheCount", (long)_instancesCopiedFromCacheCount);
                    MetricManager.Submit("BAB.ShutdownTime", DateTime.Now - now);
                    MetricManager.Submit("BAB.BuildSuccessful", success);
                }
                return document;
            }
        }

        public string GetExpectedOutputManifest(AssetDeclarationDocument parentDoc, InclusionItem item)
        {
            string physicalPath = item.PhysicalPath;
            string dataRoot = Settings.Current.DataRoot;
            return (string.IsNullOrEmpty(dataRoot)
                 || !physicalPath.StartsWith(dataRoot, StringComparison.InvariantCultureIgnoreCase) ? Path.GetFileNameWithoutExtension(physicalPath)
                                                                                                    : Path.Combine(Path.GetDirectoryName(physicalPath.Substring(dataRoot.Length + 1)),
                                                                                                                   Path.GetFileNameWithoutExtension(physicalPath))) + ".manifest";
        }
    }
}
