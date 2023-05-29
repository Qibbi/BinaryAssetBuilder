using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.IO;
using BinaryAssetBuilder.Core.Xml;
using BinaryAssetBuilder.Metrics;
using BinaryAssetBuilder.Project;
using BinaryAssetBuilder.Utility;

namespace BinaryAssetBuilder.Core.SageXml
{
    public class DocumentProcessor
    {
        private sealed class TypeCompileData
        {
            public readonly string TypeName;
            public TimeSpan TotalProcessingTime = new TimeSpan(0L);
            public TimeSpan LongestProcessingTime = new TimeSpan(0L);
            public uint InstancesProcessed;
            public string LongestProcessInstance = string.Empty;

            public TypeCompileData(string typeName)
            {
                TypeName = typeName;
            }
        }

        public class ProcessOptions
        {
            public string BasePatchStream;
            public string[] BaseStreamSearchPaths = Array.Empty<string>();
            public StreamReference[] StreamReferences = Array.Empty<StreamReference>();
            public string RelativeBasePath = string.Empty;
            public bool UsePrecompiled;
            public bool GenerateOutput;
            public string Configuration;
        }

#if VERSION5
        public const uint Version = 10u;
#else
        public const uint Version = 11u;
#endif

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(DocumentProcessor), "Provides XML processing functionality");
        private static readonly InstanceHandleSet _missingReferences = new();
        private static TimeSpan _totalProcInstancesTime = new(0L);
        private static TimeSpan _totalPrepareOutputTime = new(0L);
        private static TimeSpan _totalPrepareSourceTime = new(0L);
        private static TimeSpan _totalPostProcTime = new(0L);
        private static TimeSpan _totalValidateTime = new(0L);
        private static SortedDictionary<uint, TypeCompileData> _typeProcessingTime = new();
        private static readonly Stack<string> _currentDocumentStack = new();
        private static readonly Stack<string> _currentStreamStack = new();

        private readonly List<string> _documentStack = new();
        private readonly InstanceHandleSet _requiredInheritFromSources = new();
        private readonly PluginRegistry _pluginRegistry;
        private readonly VerifierPluginRegistry _verifierPluginRegistry;
        private int _instancesProcessedCount;
        private int _filesProcessedCount;
        private int _filesParsedCount;
        private int _instancesCopiedFromCacheCount;
        private int _instancesCompiledCount;
        private long _maxTotalMemory;
        private bool _compilingProject;
        private Dictionary<string, string> _projectDefaultConfigurations;
        private readonly SortedDictionary<string, AssetLocationInfo> _lastWrittenAssets = new SortedDictionary<string, AssetLocationInfo>();

        public static string CurrentDocument => _currentDocumentStack.Peek();

        public ISessionCache Cache { get; set; }
        public static InstanceHandleSet MissingReferences => _missingReferences;
        public InstanceHandleSet ChangedInheritFromReferences => _requiredInheritFromSources;
        public SchemaSet SchemaSet { get; set; }
        public PluginRegistry Plugins => _pluginRegistry;
        public VerifierPluginRegistry VerifierPlugins => _verifierPluginRegistry;

        public DocumentProcessor(Settings settings, PluginRegistry pluginRegistry, VerifierPluginRegistry verifierPluginRegistry)
        {
            _pluginRegistry = pluginRegistry;
            _verifierPluginRegistry = verifierPluginRegistry;
            if (Settings.Current.SingleFile)
            {
                _tracer.TraceInfo("Single file mode enabled.");
                Settings.Current.BuildCache = false;
            }
            _tracer.TraceData("Build Cache Status: {0}", Settings.Current.BuildCache ? "Active" : "Disabled");
            MetricManager.Submit("BAB.NetworkCacheEnabled", Settings.Current.BuildCache);
            if (Settings.Current.BuildCache)
            {
                _tracer.TraceInfo("Network caching enabled ('{0}').", Settings.Current.BuildCacheDirectory);
            }
        }

        public static string GetExpectedOutputManifest(string path)
        {
            string dataRoot = FileNameResolver.GetDataRoot(path);
            return (string.IsNullOrEmpty(dataRoot) ? Path.GetFileNameWithoutExtension(path) : Path.Combine(Path.GetDirectoryName(path[(dataRoot.Length + 1)..]),
                                                                                                           Path.GetFileNameWithoutExtension(path))) + ".manifest";
        }

        private static void TryDeleteFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }
            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                throw new BinaryAssetBuilderException(ex, ErrorCode.LockedFile, "Unable to delete '{0}'. Make sure no other application is writing or reading from this file.", filePath);
            }
        }

        public static void ResetTimers()
        {
            _totalProcInstancesTime = new TimeSpan(0L);
            _totalPrepareOutputTime = new TimeSpan(0L);
            _totalPrepareSourceTime = new TimeSpan(0L);
            _totalPostProcTime = new TimeSpan(0L);
            _totalValidateTime = new TimeSpan(0L);
            _typeProcessingTime = new SortedDictionary<uint, TypeCompileData>();
        }

        private AssetDeclarationDocument OpenDocument(string sourcePath, string logicalPath, bool generateOutput, string configuration)
        {
            if (!Path.IsPathRooted(sourcePath))
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Path for document {0} is not rooted", sourcePath);
            }
            Cache.TryGetFile(sourcePath, configuration, Settings.Current.TargetPlatform, out FileHashItem fileItem);
            Cache.TryGetDocument(sourcePath, configuration, Settings.Current.TargetPlatform, true, out AssetDeclarationDocument result);
            if (result.Processing)
            {
                StringBuilder sb = new StringBuilder("Illegal circular document inclusion detected. Inclusion chain as follows:");
                foreach (string item in _documentStack)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture, "\n    {0}", item);
                }
                sb.AppendFormat(CultureInfo.InvariantCulture, "\n    {0}", sourcePath);
                throw new BinaryAssetBuilderException(ErrorCode.CircularDependency, sb.ToString());
            }
            result.Open(this, fileItem, logicalPath, configuration);
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
            string sourceDirectory = document.SourceDirectory;
            if (document.IsLoaded)
            {
                foreach (InstanceDeclaration selfInstance in document.SelfInstances)
                {
                    if (selfInstance.InheritFromHandle is not null)
                    {
                        _requiredInheritFromSources.TryAdd(selfInstance.InheritFromHandle);
                    }
                }
            }
            foreach (InclusionItem inclusionItem in document.InclusionItems)
            {
                StreamReference streamReference = null;
                if (inclusionItem.Type == InclusionType.Reference && !Settings.Current.SingleFile && Settings.Current.DataRoot is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.NoDataRootSpecified, "DataRoot must be specified if not doing /singlefile");
                }
                string currentConfiguration = configuration;
                AssetDeclarationDocument currentDocument;
                bool inputFileFound;
                if (inclusionItem.Type == InclusionType.Reference)
                {
                    foreach (StreamReference reference in options.StreamReferences)
                    {
                        if (inclusionItem.LogicalPath.EndsWith(reference.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            currentConfiguration = reference.Configuration;
                            streamReference = reference;
                            _tracer.TraceInfo("Attempting use of referenced stream {0} with configuration {1}", reference.Name, reference.Configuration);
                            break;
                        }
                    }
                    inputFileFound = Cache.TryGetDocument(inclusionItem.PhysicalPath, currentConfiguration, Settings.Current.TargetPlatform, false, out currentDocument);
                    if (streamReference is not null && currentDocument is not null && currentDocument.State == DocumentState.None)
                    {
                        bool streamFound = false;
                        foreach (BuildConfiguration buildConfiguration in Settings.Current.BuildConfigurations)
                        {
                            if (string.IsNullOrEmpty(currentConfiguration) || buildConfiguration.Name.Equals(currentConfiguration, StringComparison.OrdinalIgnoreCase))
                            {
                                string sourcePathFromRoot;
                                if (string.IsNullOrEmpty(streamReference.Manifest))
                                {
                                    sourcePathFromRoot = Path.GetFileNameWithoutExtension(GetExpectedOutputManifest(inclusionItem.PhysicalPath))
                                        + buildConfiguration.StreamPostfix
                                        + ".manifest";
                                }
                                else
                                {
                                    sourcePathFromRoot = streamReference.Manifest;
                                }
                                currentDocument.FromLastHack();
                                if (!LoadPrecompiledReference(currentDocument, sourcePathFromRoot, options.BaseStreamSearchPaths))
                                {
                                    throw new BinaryAssetBuilderException(ErrorCode.ReferencingError, "Explicitly referenced external stream not found with desired build configuration");
                                }
                                streamFound = true;
                                break;
                            }
                        }
                        if (!streamFound)
                        {
                            throw new BinaryAssetBuilderException(ErrorCode.ReferencingError,
                                                                  "Explicitly referenced external stream was not found with configuration {0}",
                                                                  currentConfiguration);
                        }
                    }
                    else if (!inputFileFound || currentDocument is null || currentDocument.State != DocumentState.Complete)
                    {
                        if (_compilingProject && _projectDefaultConfigurations.TryGetValue(inclusionItem.PhysicalPath.ToLowerInvariant(), out string str))
                        {
                            inputFileFound = Cache.TryGetFile(inclusionItem.PhysicalPath, currentConfiguration, Settings.Current.TargetPlatform, out FileHashItem _);
                            _tracer.TraceInfo("Stream {0} references stream {1} which does not have a '{2}' configuration, using default configuration '{3}'",
                                              document.SourcePath,
                                              inclusionItem.LogicalPath,
                                              configuration,
                                              currentConfiguration);
                        }
                        else if (usePrecompiled)
                        {
                            _tracer.TraceInfo("Stream {0} references stream {1} which has not been compiled, attempting to use precompiled", document.SourcePath, inclusionItem.LogicalPath);
                            if (LoadPrecompiledReference(document, GetExpectedOutputManifest(inclusionItem.PhysicalPath), options.BaseStreamSearchPaths) || _compilingProject)
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    inputFileFound = Cache.TryGetDocument(inclusionItem.PhysicalPath, configuration, Settings.Current.TargetPlatform, false, out currentDocument);
                }
                if (!inputFileFound)
                {
                    if (Settings.Current.ErrorLevel > 0)
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.FileNotFound,
                                                              "Input file '{0}' not found (referenced from file://{1}).",
                                                              inclusionItem.LogicalPath,
                                                              document.SourcePath);
                    }
                    _tracer.TraceError("Input file '{0}' not found (referenced from file://{1}). Treating it as empty.", inclusionItem.LogicalPath, document.SourcePath);
                }
                bool generateOutput = inclusionItem.Type == InclusionType.Reference && !usePrecompiled;
                _totalPostProcTime += DateTime.Now - now;
                ProcessOptions childOptions = new ProcessOptions
                {
                    GenerateOutput = generateOutput,
                    UsePrecompiled = usePrecompiled,
                    Configuration = currentConfiguration
                };
                if (streamReference is null)
                {
                    currentDocument = ProcessDocumentInternal(inclusionItem.LogicalPath, inclusionItem.PhysicalPath, generateOutput ? null : outputManager, childOptions);
                    now = DateTime.Now;
                    inclusionItem.Document = currentDocument;
                    document.AllDefines.AddDefintions(currentDocument.AllDefines);
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
                if (document.AllInstances.TryGetValue(referenceInstance.Handle, out InstanceDeclaration instanceDeclaration)
                    && instanceDeclaration.Document == referenceInstance.Document)
                {
                    document.AllInstances.Remove(instanceDeclaration);
                }
                if (document.TentativeInstances.TryGetValue(referenceInstance.Handle, out instanceDeclaration) && instanceDeclaration.Document == referenceInstance.Document)
                {
                    document.TentativeInstances.Remove(instanceDeclaration);
                }
            }
            document.EvaluateDefinitions();
        }

        private void ProcessDocumentContents(AssetDeclarationDocument document, OutputManager outputManager, ProcessOptions options, bool generateOutput)
        {
            string configuration = options.Configuration;
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
            if (outputManager is not null)
            {
                DateTime now = DateTime.Now;
                document.ProcessInstances(outputManager, ref _instancesCompiledCount, ref _instancesCopiedFromCacheCount);
                _totalProcInstancesTime += DateTime.Now - now;
            }
            document.AddStreamHints(_currentStreamStack.ToArray());
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
                _currentStreamStack.Pop();
                _tracer.Message("{0} Stream complete", document.SourcePathFromRoot);
                _totalPrepareOutputTime += DateTime.Now - now;
            }
            _documentStack.RemoveAt(_documentStack.Count - 1);
            document.MakeComplete();
            document.MakeCacheable();
            Cache.SaveDocumentToCache(document.SourcePath, configuration, Settings.Current.TargetPlatform, document);
        }

        private bool LoadPrecompiledReference(AssetDeclarationDocument parent, string sourcePathFromRoot, string[] baseStreamSearchPaths)
        {
            string str = ShPath.Canonicalize(Path.Combine(Settings.Current.OutputDirectory, sourcePathFromRoot));
            if (!File.Exists(str))
            {
                _tracer.TraceWarning("Could not load precompiled manifest {0}, file not found", str);
                return false;
            }
            Manifest manifest = new Manifest();
            List<string> baseStreamSearchPathList = new List<string>();
            if (baseStreamSearchPaths is not null)
            {
                baseStreamSearchPathList.AddRange(baseStreamSearchPaths);
            }
            baseStreamSearchPathList.Add(Settings.Current.OutputDirectory);
            try
            {
                manifest.Load(str, baseStreamSearchPathList.ToArray());
            }
            catch (Exception ex)
            {
                _tracer.TraceError("Could not load {0}: {1}\n\r{2}", str, ex.Message, ex.StackTrace);
                return false;
            }
            try
            {
                ManifestHeader header = new ManifestHeader();
                using (FileStream fs = File.OpenRead(str))
                {
                    header.LoadFromStream(fs, Settings.Current.BigEndian);
                }
                if (header.IsLinked != Settings.Current.LinkedStreams || header.Version != ManifestHeader.LatestVersion || header.AllTypesHash != Plugins.DefaultPlugin.AllTypesHash)
                {
                    _tracer.TraceWarning("Could not load precompiled manifest {0}, manifest is incompatible", str);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new BinaryAssetBuilderException(ex,
                                                      ErrorCode.LockedFile,
                                                      "Unable to open '{0}'. Make sure no other application is writing or reading from this file while the data build is running",
                                                      str);
            }
            foreach (Asset asset in manifest.Assets)
            {
                InstanceDeclaration instanceDeclaration = new InstanceDeclaration();
                instanceDeclaration.InitializePrecompiled(asset);
                parent.ReferenceInstances.Add(instanceDeclaration);
            }
            return true;
        }

        public AssetDeclarationDocument ProcessDocumentInternal(string logicalPath, string sourcePath, OutputManager outputManager, ProcessOptions options)
        {
            DateTime now = DateTime.Now;
            AssetDeclarationDocument result = OpenDocument(sourcePath, logicalPath, options.GenerateOutput, options.Configuration);
            if (options.GenerateOutput)
            {
                if ((Settings.Current.StreamHints
                    && Cache.DirtyStreams is not null
                    && !Cache.DirtyStreams.Contains(sourcePath)
                    && LoadPrecompiledReference(result, GetExpectedOutputManifest(result.SourcePath), options.BaseStreamSearchPaths))
                    || result.State == DocumentState.Complete)
                {
                    return result;
                }
                if (!Settings.Current.SingleFile && string.IsNullOrEmpty(result.SourcePathFromRoot))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.IllegalPath, "{0} is a stream (.manifest) but does not have {1} as its root!", sourcePath, Settings.Current.DataRoot);
                }
                string str = ShPath.Canonicalize(Path.Combine(Settings.Current.IntermediateOutputDirectory, result.SourcePathFromRoot));
                string outputDirectory = ShPath.Canonicalize(Path.Combine(Settings.Current.OutputDirectory, result.SourcePathFromRoot))
                                           + Settings.Current.StreamPostfix + Settings.Current.CustomPostfix;
                string intermediateOutputDirectory = str + Settings.Current.StreamPostfix + Settings.Current.CustomPostfix;
                outputManager = new OutputManager(this,
                                                  result.LastOutputAssets,
                                                  outputDirectory,
                                                  intermediateOutputDirectory,
                                                  options.BasePatchStream,
                                                  options.RelativeBasePath,
                                                  options.BaseStreamSearchPaths);
                _currentStreamStack.Push(sourcePath);
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
                result.ReInitialize(outputManager);
            }
            if (!result.IsLoaded)
            {
                result.ReloadIfRequired(_requiredInheritFromSources);
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

        public void ProcessProjectDocument(string projectPath, bool generateOutput)
        {
            _compilingProject = true;
            _projectDefaultConfigurations = new Dictionary<string, string>();
            Settings current = Settings.Current;
            XmlReader reader = XmlReader.Create(Assembly.GetExecutingAssembly().GetManifestResourceStream("BinaryAssetBuilderProject.xsd"));
            XmlSchema schema = XmlSchema.Read(reader, null);
            BinaryAssetBuilderProject babproj = new();
            using (Stream stream = File.Open(projectPath, FileMode.Open))
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(schema);
                try
                {
                    BinaryAssetBuilderDocument builderDocument = new BinaryAssetBuilderDocument(stream, settings);
                    babproj.ReadXml(builderDocument.GetNode(nameof(BinaryAssetBuilderProject)));
                }
                catch (Exception ex)
                {
                    _tracer.TraceError("There is an error in '{0}': {1}\n", projectPath, ex.InnerException.Message);
                    babproj = null;
                }
            }
            if (babproj is not null)
            {
                SortedDictionary<string, bool> dictionary = new SortedDictionary<string, bool>();
                foreach (BinaryStream stream in babproj.Streams)
                {
                    string lower = Path.GetFullPath(!Path.IsPathRooted(stream.Source) ? Path.Combine(Path.GetDirectoryName(projectPath), stream.Source) : stream.Source).ToLowerInvariant();
                    if (dictionary.TryGetValue(lower, out bool flag) && flag)
                    {
                        _tracer.TraceError("{0} was specified twice in {1}, skipping duplicates", lower, projectPath);
                    }
                    else if (stream.Configurations is not null && stream.Configurations.Length > 0)
                    {
                        StreamConfiguration configuration = null;
                        foreach (StreamConfiguration streamConfiguration in stream.Configurations)
                        {
                            if (streamConfiguration.Default)
                            {
                                if (configuration is not null)
                                {
                                    _tracer.TraceWarning("Stream {0} has multiple default configurations. Using {1}", lower, configuration.Name);
                                }
                                else
                                {
                                    configuration = streamConfiguration;
                                }
                            }
                        }
                        if (configuration is null)
                        {
                            configuration = stream.Configurations[0];
                            _tracer.TraceInfo("No default configuration specified for {0}. Using {1}", stream.Source, configuration.Name);
                        }
                        _projectDefaultConfigurations[lower] = configuration.Name;
                        foreach (StreamConfiguration streamConfiguration in stream.Configurations)
                        {
                            Settings.Current = SettingsLoader.GetSettingsForConfiguration(streamConfiguration.Name);
                            Settings.Current.BuildConfigurationName = streamConfiguration.Name;
                            ProcessOptions options = new ProcessOptions
                            {
                                GenerateOutput = true,
                                UsePrecompiled = true,
                                Configuration = streamConfiguration.Name,
                                BasePatchStream = streamConfiguration.PatchStream,
                                BaseStreamSearchPaths = streamConfiguration.BaseStreamSearchPaths,
                                RelativeBasePath = streamConfiguration.RelativeBasePath
                            };
                            if (streamConfiguration.StreamReferences is not null)
                            {
                                options.StreamReferences = streamConfiguration.StreamReferences;
                            }
                            ProcessDocumentInternal(lower, lower, null, options);
                            Settings.Current = current;
                        }
                    }
                    else
                    {
                        _projectDefaultConfigurations[lower] = string.Empty;
                        ProcessDocumentInternal(lower, lower, null, new ProcessOptions { GenerateOutput = true, UsePrecompiled = true });
                    }
                }
            }
            _compilingProject = false;
        }

        public void ProcessDocument(string fileName, bool generateOutput, bool outputStringHashes, out bool success)
        {
            XIncludingReaderWrapper.LoadAssembly();
            ExpressionEvaluatorWrapper.LoadAssembly();
            DateTime startTime = DateTime.Now;
            using (new MetricTimer("BAB.ProcessingTime"))
            {
                if (!File.Exists(fileName))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InputXmlFileNotFound, "File '{0}' not found", fileName);
                }
                MetricManager.Submit("BAB.MapName", Path.GetFileName(Path.GetDirectoryName(fileName)));
                MetricManager.Submit("BAB.StartupTime", DateTime.Now - startTime);
                startTime = DateTime.Now;
                success = false;
                try
                {
                    if (Path.GetExtension(fileName).Equals(".babproj", StringComparison.OrdinalIgnoreCase))
                    {
                        ProcessProjectDocument(fileName, generateOutput);
                    }
                    else
                    {
                        ProcessDocumentInternal(fileName, fileName, null, new ProcessOptions
                        {
                            GenerateOutput = generateOutput,
                            BasePatchStream = Settings.Current.BasePatchStream,
                            UsePrecompiled = Settings.Current.UsePrecompiled
                        });
                    }
                    success = true;
                }
                finally
                {
                    MetricManager.Submit("BAB.PrepSourceTime", _totalPrepareSourceTime);
                    MetricManager.Submit("BAB.ProcIncludesTime", _totalPostProcTime);
                    MetricManager.Submit("BAB.ValidateTime", _totalValidateTime);
                    MetricManager.Submit("BAB.InstanceProcessingTime", _totalProcInstancesTime);
                    MetricManager.Submit("BAB.OutputPrepTime", _totalPrepareOutputTime);
                    MetricManager.Submit("BAB.DocumentProcessingTime", DateTime.Now - startTime);
                    startTime = DateTime.Now;
                    MetricManager.Submit("BAB.LinkedStreamsEnabled", Settings.Current.LinkedStreams);
                    MetricManager.Submit("BAB.MaxMemorySize", _maxTotalMemory);
                    MetricManager.Submit("BAB.FilesProcessedCount", _filesProcessedCount);
                    MetricManager.Submit("BAB.FilesParsedCount", _filesParsedCount);
                    MetricManager.Submit("BAB.InstancesProcessedCount", _instancesProcessedCount);
                    MetricManager.Submit("BAB.InstancesCompiledCount", _instancesCompiledCount);
                    MetricManager.Submit("BAB.InstancesCopiedFromCacheCount", _instancesCopiedFromCacheCount);
                    MetricManager.Submit("BAB.ShutdownTime", DateTime.Now - startTime);
                    MetricManager.Submit("BAB.BuildSuccessful", success);
                }
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

        public AssetLocationInfo GetLastWrittenAsset(string fileBase)
        {
            _lastWrittenAssets.TryGetValue(fileBase, out AssetLocationInfo result);
            return result;
        }

        public static void AddCompileTime(InstanceHandle handle, TimeSpan instanceCompileTime)
        {
            if (!_typeProcessingTime.TryGetValue(handle.TypeId, out TypeCompileData typeData))
            {
                typeData = new TypeCompileData(handle.TypeName);
                _typeProcessingTime.Add(handle.TypeId, typeData);
            }
            ++typeData.InstancesProcessed;
            if (instanceCompileTime > typeData.LongestProcessingTime)
            {
                typeData.LongestProcessingTime = instanceCompileTime;
                typeData.LongestProcessInstance = handle.InstanceName;
            }
            typeData.TotalProcessingTime += instanceCompileTime;
        }

        public static void OutputTypeCompileTimes()
        {
            TimeSpan totalProcessingTime = new TimeSpan(0L);
            foreach (KeyValuePair<uint, TypeCompileData> kvp in _typeProcessingTime)
            {
                TypeCompileData typeData = kvp.Value;
                _tracer.Message("{0}:", typeData.TypeName);
                _tracer.Message("    Instances Processed: {0}", typeData.InstancesProcessed);
                _tracer.Message("    Total Processing Time: {0}", typeData.TotalProcessingTime);
                _tracer.Message("    Longest Processing Time: {0} ({1})", typeData.LongestProcessingTime, typeData.LongestProcessInstance);
                _tracer.Message("    Average Processing Time: {0} seconds", typeData.TotalProcessingTime.TotalSeconds / typeData.InstancesProcessed);
                totalProcessingTime += typeData.TotalProcessingTime;
            }
            _tracer.Message("Total Processing Time for all types: {0}", totalProcessingTime);
        }
    }
}
