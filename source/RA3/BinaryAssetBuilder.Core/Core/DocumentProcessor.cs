using BinaryAssetBuilder.Project;
using BinaryAssetBuilder.Utility;
using Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BinaryAssetBuilder.Core
{
    public class DocumentProcessor
    {
        private class TypeCompileData
        {
            public TimeSpan TotalProcessTime = new TimeSpan(0L);
            public TimeSpan LongestProcessTime = new TimeSpan(0L);
            public uint InstancesProcessed;
            public readonly string TypeName;
            public string LongestProcessInstance = string.Empty;

            public TypeCompileData(string typeName)
            {
                TypeName = typeName;
            }
        }

        public class ProcessOptions
        {
            public string BasePatchStream;
            public string[] BasePatchStreamSearchPaths = null;
            public StreamReference[] StreamReferences = null;
            public string RelativeBasePath = string.Empty;
            public bool GenerateOutput;
            public string Configuration;
            public bool UsePrecompiled;
        }

        [NonSerialized] public const uint Version = 11u;

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(DocumentProcessor), "Provides XML processing functionality");
        private static readonly InstanceHandleSet _missingReferences = new InstanceHandleSet();
        private static TimeSpan _totalProcInstancesTime = new TimeSpan(0L);
        private static TimeSpan _totalPrepareOutputTime = new TimeSpan(0L);
        private static TimeSpan _totalPrepareSourceTime = new TimeSpan(0L);
        private static TimeSpan _totalPostProcTime = new TimeSpan(0L);
        private static TimeSpan _totalValidateTime = new TimeSpan(0L);
        private static IDictionary<uint, TypeCompileData> _typeProcessingTime = new SortedDictionary<uint, TypeCompileData>();
        private static readonly Stack<string> _currentDocumentStack = new Stack<string>();
        private static readonly Stack<string> _currentstreamStack = new Stack<string>();

        private readonly List<string> _documentStack = new List<string>();
        [NonSerialized] private readonly Dictionary<string, AssetLocationInfo> _lastWrittenAssets = new Dictionary<string, AssetLocationInfo>();
        private int _instancesProcessedCount;
        private int _filesProcessedCount;
        private int _filesParsedCount;
        private int _instancesCopiedFromCacheCount;
        private int _instancesCompiledCount;
        private long _maxTotalMemory;
        private bool _isCompilingProject;
        private Dictionary<string, string> _projectDefaultConfigurations;

        public static string CurrentDocument => _currentDocumentStack.Peek();

        public ISessionCache Cache { get; set; }
        public InstanceHandleSet MissingReferences => _missingReferences;
        public InstanceHandleSet ChangedInheritFromReferences { get; } = new InstanceHandleSet();
        public SchemaSet SchemaSet { get; set; }
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
            MetricManager.Submit("BAB.NetworkCacheEnabled", Settings.Current.UseBuildCache);
            if (Settings.Current.UseBuildCache)
            {
                _tracer.TraceInfo("Network caching enabled ('{0}').", Settings.Current.BuildCacheDirectory);
            }
        }

        private static void ResetTimers()
        {
            _totalProcInstancesTime = new TimeSpan(0L);
            _totalPrepareOutputTime = new TimeSpan(0L);
            _totalPrepareSourceTime = new TimeSpan(0L);
            _totalPostProcTime = new TimeSpan(0L);
            _totalValidateTime = new TimeSpan(0L);
            _typeProcessingTime = new SortedDictionary<uint, TypeCompileData>();
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
                StreamReference currentStreamReference = null;
                if (inclusionItem.Type == InclusionType.Reference && !Settings.Current.SingleFile && Settings.Current.DataRoot is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.NoDataRootSpecified, "DataRoot must be specified if not doing /singleFile");
                }
                string currentConfiguration = configuration;
                AssetDeclarationDocument currentDocument;
                bool valid;
                if (inclusionItem.Type == InclusionType.Reference)
                {
                    foreach (StreamReference streamReference in options.StreamReferences)
                    {
                        if (inclusionItem.LogicalPath.EndsWith(streamReference.ReferenceName))
                        {
                            currentConfiguration = streamReference.ReferenceConfiguration;
                            currentStreamReference = streamReference;
                            _tracer.TraceInfo("Attempting use of referenced stream {0} with configuration {1}", streamReference.ReferenceName, streamReference.ReferenceConfiguration);
                            break;
                        }
                    }
                    valid = Cache.TryGetDocument(inclusionItem.PhysicalPath, currentConfiguration, Settings.Current.TargetPlatform, false, out currentDocument);
                    if (currentStreamReference != null && currentDocument != null && currentDocument.State == DocumentState.None)
                    {
                        bool currentValid = false;
                        foreach (BuildConfiguration buildConfiguration in Settings.Current.BuildConfigurations)
                        {
                            if (string.IsNullOrEmpty(currentConfiguration) || buildConfiguration.Name.ToLower().Equals(currentConfiguration.ToLower()))
                            {
                                string sourcePathFromRoot;
                                if (string.IsNullOrEmpty(currentStreamReference.ReferenceManifest))
                                {
                                    sourcePathFromRoot = Path.GetFileNameWithoutExtension(GetExpectedOutputManifest(inclusionItem.PhysicalPath)) + buildConfiguration.StreamPostfix + ".manifest";
                                }
                                else
                                {
                                    sourcePathFromRoot = currentStreamReference.ReferenceManifest;
                                }
                                currentDocument.FromLastHack();
                                if (!LoadPrecompiledReference(currentDocument, sourcePathFromRoot, options.BasePatchStreamSearchPaths))
                                {
                                    throw new BinaryAssetBuilderException(ErrorCode.ReferencingError, "Explicitly referenced external stream not found with desired build configuration.");
                                }
                                currentValid = true;
                                break;
                            }
                        }
                        if (!currentValid)
                        {
                            throw new BinaryAssetBuilderException(ErrorCode.ReferencingError, "Explicitly referenced stream was not found built with configuration {0}", currentConfiguration);
                        }
                    }
                    else if (!valid || currentDocument is null || currentDocument.State != DocumentState.Complete)
                    {
                        if (_isCompilingProject && _projectDefaultConfigurations.TryGetValue(inclusionItem.PhysicalPath.ToLower(), out string configName))
                        {
                            currentConfiguration = configName;
                            valid = Cache.TryGetFile(inclusionItem.PhysicalPath, currentConfiguration, Settings.Current.TargetPlatform, out FileHashItem hashItem);
                            _tracer.TraceInfo("Stream {0} references stream {1} which does not have a '{2}' configuration, using default configuration '{3}'",
                                              document.SourcePath,
                                              inclusionItem.LogicalPath,
                                              configuration,
                                              currentConfiguration);
                        }
                        else if (usePrecompiled)
                        {
                            _tracer.TraceInfo("Stream {0} references stream {1} which has not been compiled, attempting to use precompiled",
                                              document.SourcePath,
                                              inclusionItem.PhysicalPath);
                            if (LoadPrecompiledReference(document, GetExpectedOutputManifest(inclusionItem.PhysicalPath), options.BasePatchStreamSearchPaths) || _isCompilingProject)
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    valid = Cache.TryGetDocument(inclusionItem.PhysicalPath, configuration, Settings.Current.TargetPlatform, false, out currentDocument);
                }
                if (!valid)
                {
                    if (Settings.Current.ErrorLevel > 0)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.FileNotFound,
                                                              "Input file '{0}' not found (referenced from file://{1}). Treating it as empty.",
                                                              inclusionItem.LogicalPath,
                                                              document.SourcePath);
                    }
                    _tracer.TraceError("Input file '{0}' not found (referenced from file://{1}). Treating it as empty.", inclusionItem.LogicalPath, document.SourcePath);
                }
                _totalPostProcTime += DateTime.Now - now;
                bool output = inclusionItem.Type == InclusionType.Reference && !usePrecompiled;
                ProcessOptions newOptions = new ProcessOptions
                {
                    GenerateOutput = output,
                    UsePrecompiled = usePrecompiled,
                    Configuration = currentConfiguration
                };
                if (currentStreamReference is null)
                {
                    currentDocument = ProcessDocumentInternal(inclusionItem.LogicalPath, inclusionItem.PhysicalPath, output ? null : outputManager, newOptions);
                    now = DateTime.Now;
                    inclusionItem.Document = currentDocument;
                    document.AllDefines.AddDefinitions(currentDocument.AllDefines);
                }
                switch (inclusionItem.Type)
                {
                    case InclusionType.Reference:
                        document.ReferenceInstances.Add(currentDocument.ReferenceInstances);
                        document.ReferenceInstances.Add(currentDocument.Instances);
                        break;
                    case InclusionType.Instance:
                        document.TentativeInstances.Add(currentDocument.Instances);
                        document.TentativeInstances.Add(currentDocument.TentativeInstances);
                        break;
                    case InclusionType.All:
                        document.ReferenceInstances.Add(currentDocument.ReferenceInstances);
                        document.AllInstances.Add(currentDocument.Instances);
                        document.TentativeInstances.Add(currentDocument.TentativeInstances);
                        break;
                }
                currentDocument.Reset();
                _totalPostProcTime += DateTime.Now - now;
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
                    outputManager.CreateVersionFile(document, Settings.Current.CustomPostfix);
                }
                outputManager = null;
                _currentDocumentStack.Pop();
                _tracer.Message("{0} Stream complete", document.SourcePathFromRoot);
                _totalPrepareOutputTime += DateTime.Now - now;
            }
            _documentStack.RemoveAt(_documentStack.Count - 1);
            document.MakeComplete();
            document.MakeCacheable();
            Cache.SaveDocumentToCache(document.SourcePath, options.Configuration, Settings.Current.TargetPlatform, document);
        }

        private AssetDeclarationDocument ProcessDocumentInternal(string logicalPath, string sourcePath, OutputManager outputManager, ProcessOptions options)
        {
            DateTime now = DateTime.Now;
            AssetDeclarationDocument result = OpenDocument(sourcePath, logicalPath, options.Configuration);
            if (options.GenerateOutput)
            {
                if ((Settings.Current.UseStreamHints
                 && Cache.DirtyStreams != null
                 && !Cache.DirtyStreams.Contains(sourcePath)
                 && LoadPrecompiledReference(result, GetExpectedOutputManifest(result.SourcePath), options.BasePatchStreamSearchPaths))
                 || result.State == DocumentState.Complete)
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
                string outputDirectory = ShPath.Canonicalize(Path.Combine(Settings.Current.OutputDirectory, result.SourcePathFromRoot)) + Settings.Current.StreamPostfix + Settings.Current.CustomPostfix;
                string intermediateOutputDirectory = str + Settings.Current.StreamPostfix + Settings.Current.CustomPostfix;
                outputManager = new OutputManager(this, result.LastOutputAssets, outputDirectory, intermediateOutputDirectory, options.BasePatchStream, options.RelativeBasePath, options.BasePatchStreamSearchPaths);
                _currentDocumentStack.Push(sourcePath);
            }
            string fileName = Path.GetFileName(sourcePath);
            _currentDocumentStack.Push($"{fileName}:");
            if (result.State == DocumentState.Complete && result.IsLoaded && result.XmlDocument is null)
            {
                foreach (InstanceDeclaration instance in result.Instances)
                {
                    if (outputManager.GetBinaryAsset(instance, false).GetLocation(AssetLocation.All, AssetLocationOption.None) == AssetLocation.None)
                    {
                        _tracer.TraceInfo("Reloading 'file://{0}' for new stream", result.SourcePath);
                        result.State = DocumentState.Shallow;
                        break;
                    }
                }
            }
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

        private bool LoadPrecompiledReference(AssetDeclarationDocument parentDoc, string sourcePathFromRoot, string[] baseStreamSearchPaths)
        {
            string str = ShPath.Canonicalize(Path.Combine(Settings.Current.OutputDirectory, sourcePathFromRoot));
            if (!File.Exists(str))
            {
                _tracer.TraceWarning("Could not load precompiled manifest {0}, file not found", str);
                return false;
            }
            Manifest manifest = new Manifest();
            List<string> patchSearchPaths = new List<string>();
            if (baseStreamSearchPaths != null)
            {
                patchSearchPaths.AddRange(baseStreamSearchPaths);
            }
            patchSearchPaths.Add(Settings.Current.OutputDirectory);
            try
            {
                manifest.Load(str, patchSearchPaths.ToArray());
            }
            catch (Exception ex)
            {
                _tracer.TraceError("Could not load {0}: {1}\n\r{2}", str, ex.Message, ex.StackTrace);
                return false;
            }
            try
            {
                ManifestHeader header = new ManifestHeader();
                using (FileStream stream = File.OpenRead(str))
                {
                    header.LoadFromStream(stream, Settings.Current.BigEndian);
                }
                if (header.IsLinked == Settings.Current.LinkedStreams && header.Version == ManifestHeader.LatestVersion)
                {
                    if (header.AllTypesHash == Plugins.DefaultPlugin.GetAllTypesHash())
                    {
                        goto nomismatch;
                    }
                }
                _tracer.TraceWarning("Could not load precompiled manifest {0}, manifest is incompatible", str);
                return false;
            }
            catch (Exception ex)
            {
                throw new BinaryAssetBuilderException(ex,
                                                      ErrorCode.LockedFile,
                                                      "Unable to open '{0}'. Make sure no other application is writing or reading from this file while the data build is running.",
                                                      str);
            }
        nomismatch:
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

        public void ProcessProjectDocument(string projectPath, bool generateOutput)
        {
            _isCompilingProject = true;
            _projectDefaultConfigurations = new Dictionary<string, string>();
            Settings current = Settings.Current;
            XmlSchema schema = XmlSchema.Read(Assembly.GetExecutingAssembly().GetManifestResourceStream("BinaryAssetBuilderProject.xsd"), null);
            StreamReader reader = new StreamReader(projectPath);
            XmlReader xmlReader = XmlReader.Create(reader);
            xmlReader.Settings.Schemas.Add(schema);
            BinaryAssetBuilderProject project = null;
            try
            {
                project = new XmlSerializer(typeof(BinaryAssetBuilderProject)).Deserialize(xmlReader) as BinaryAssetBuilderProject;
            }
            catch (InvalidOperationException ex)
            {
                _tracer.TraceError("There is an error in '{0}': {1}\n", projectPath, ex.InnerException.Message);
            }
            reader.Close();
            if (project != null)
            {
                IDictionary<string, bool> compiledStreams = new SortedDictionary<string, bool>();
                foreach (BinaryStream binaryStream in project.Stream)
                {
                    string path = Path.GetFullPath(!Path.IsPathRooted(binaryStream.Source)
                        ? Path.Combine(Path.GetDirectoryName(projectPath), binaryStream.Source)
                        : binaryStream.Source).ToLower();
                    if (compiledStreams.TryGetValue(path, out bool isCompiled) && isCompiled)
                    {
                        _tracer.TraceError("{0} was specified twice in {1}, skipping duplicates", path, projectPath);
                    }
                    else if (binaryStream.Configuration != null && binaryStream.Configuration.Length > 0)
                    {
                        StreamConfiguration currentConfiguration = null;
                        foreach (StreamConfiguration configuration in binaryStream.Configuration)
                        {
                            if (configuration.IsDefault)
                            {
                                if (currentConfiguration != null)
                                {
                                    _tracer.TraceWarning("Stream {0} has multiple default configurations. Using {1}.", path, currentConfiguration.Name);
                                }
                                else
                                {
                                    currentConfiguration = configuration;
                                }
                            }
                        }
                        if (currentConfiguration is null)
                        {
                            _tracer.TraceInfo("No default configuration specified for {0}. Using{1}", binaryStream.Source, binaryStream.Configuration[0].Name);
                            currentConfiguration = binaryStream.Configuration[0];
                        }
                        _projectDefaultConfigurations[path] = currentConfiguration.Name;
                        foreach (StreamConfiguration configuration in binaryStream.Configuration)
                        {
                            Settings.Current = SettingsLoader.GetSettingsForConfiguration(configuration.Name);
                            Settings.Current.BuildConfigurationName = configuration.Name;
                            ProcessOptions op = new ProcessOptions
                            {
                                GenerateOutput = true,
                                UsePrecompiled = true,
                                Configuration = configuration.Name,
                                BasePatchStream = configuration.PatchStream,
                                BasePatchStreamSearchPaths = configuration.BaseStreamSearchPath,
                                RelativeBasePath = configuration.RelativeBasePath
                            };
                            if (configuration.StreamReference != null)
                            {
                                op.StreamReferences = configuration.StreamReference;
                            }
                            ProcessDocumentInternal(path, path, null, op);
                            Settings.Current = current;
                        }
                    }
                    else
                    {
                        _projectDefaultConfigurations[path] = string.Empty;
                        ProcessDocumentInternal(path, path, null, new ProcessOptions { GenerateOutput = true, UsePrecompiled = true });
                    }
                }
            }
            _isCompilingProject = false;
        }

        public void ProcessDocument(string fileName, bool generateOutput, bool outputStringHashes, out bool isSuccess)
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
                MetricManager.Submit("BAB.StartupTime", DateTime.Now - now);
                now = DateTime.Now;
                isSuccess = false;
                try
                {
                    if (Path.GetExtension(fileName).ToLower().Equals(".babproj", StringComparison.CurrentCultureIgnoreCase))
                    {
                        ProcessProjectDocument(fileName, generateOutput);
                    }
                    else
                    {
                        ProcessDocumentInternal(Path.IsPathRooted(fileName) ? Path.GetFileName(fileName) : fileName,
                                                fileName,
                                                null,
                                                new ProcessOptions
                                                {
                                                    GenerateOutput = generateOutput,
                                                    BasePatchStream = Settings.Current.BasePatchStream,
                                                    UsePrecompiled = Settings.Current.UsePrecompiled
                                                });
                        isSuccess = true;
                    }
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
                    MetricManager.Submit("BAB.LinkedStreamsEnabled", Settings.Current.LinkedStreams);
                    MetricManager.Submit("BAB.MaxMemorySize", _maxTotalMemory);
                    MetricManager.Submit("BAB.FilesProcessedCount", (long)_filesProcessedCount);
                    MetricManager.Submit("BAB.FilesParsedCount", (long)_filesParsedCount);
                    MetricManager.Submit("BAB.InstancesProcessedCount", (long)_instancesProcessedCount);
                    MetricManager.Submit("BAB.InstancesCompiledCount", (long)_instancesCompiledCount);
                    MetricManager.Submit("BAB.InstancesCopiedFromCacheCount", (long)_instancesCopiedFromCacheCount);
                    MetricManager.Submit("BAB.ShutdownTime", DateTime.Now - now);
                    MetricManager.Submit("BAB.BuildSuccessful", isSuccess);
                }
            }
        }

        public string GetExpectedOutputManifest(string path)
        {
            string dataRoot = FileNameResolver.GetDataRoot(path);
            return (string.IsNullOrEmpty(dataRoot) ? Path.GetFileNameWithoutExtension(path)
                                                   : Path.Combine(Path.GetDirectoryName(path[(dataRoot.Length + 1)..]), Path.GetFileNameWithoutExtension(path))) + ".manifest";
        }

        public void AddCompileTime(InstanceHandle handle, TimeSpan instanceCompileTime)
        {
            if (!_typeProcessingTime.TryGetValue(handle.TypeId, out TypeCompileData typeCompileData))
            {
                typeCompileData = new TypeCompileData(handle.TypeName);
                _typeProcessingTime.Add(handle.TypeId, typeCompileData);
            }
            ++typeCompileData.InstancesProcessed;
            if (instanceCompileTime > typeCompileData.LongestProcessTime)
            {
                typeCompileData.LongestProcessTime = instanceCompileTime;
                typeCompileData.LongestProcessInstance = handle.InstanceName;
            }
            typeCompileData.TotalProcessTime += instanceCompileTime;
        }

        public void OutputTypeCompileTime()
        {
            TimeSpan timeSpan = new TimeSpan(0L);
            foreach (KeyValuePair<uint, TypeCompileData> dataItem in _typeProcessingTime)
            {
                TypeCompileData data = dataItem.Value;
                _tracer.Message("{0}:", data.TypeName);
                _tracer.Message("    Instances Processed: {0}", data.InstancesProcessed);
                _tracer.Message("    Total Processing Time: {0}", data.TotalProcessTime);
                _tracer.Message("    Longest Processing Time: {0} ({1})", data.LongestProcessTime, data.LongestProcessInstance);
                _tracer.Message("    Average Processing Time: {0} seconds", data.TotalProcessTime.TotalSeconds / data.InstancesProcessed);
                timeSpan += data.TotalProcessTime;
            }
            _tracer.Message("Total Processing Time for all types: {0}", timeSpan);
        }
    }
}
