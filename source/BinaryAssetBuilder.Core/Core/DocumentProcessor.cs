using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace BinaryAssetBuilder.Core
{
    public class DocumentProcessor
    {
        [NonSerialized] public const uint Version = 10;

        private static Tracer _tracer = Tracer.GetTracer(nameof(DocumentProcessor), "Provides XML processing functionality");
        private static InstanceHandleSet _missingReferences = new InstanceHandleSet();
        private static TimeSpan _totalProcInstancesTime = new TimeSpan(0L);
        private static TimeSpan _totalPrepareOutputTime = new TimeSpan(0L);
        private static TimeSpan _totalPrepareSourceTime = new TimeSpan(0L);
        private static TimeSpan _totalPostProcTime = new TimeSpan(0L);
        private static TimeSpan _totalValidateTime = new TimeSpan(0L);
        private static Stack<string> _currentDocumentStack = new Stack<string>();

        private StringCollection _documentStack = new StringCollection();
        private InstanceHandleSet _requiredInheritFromSources = new InstanceHandleSet();
        [NonSerialized] private Dictionary<string, AssetLocationInfo> _lastWrittenAssets = new Dictionary<string, AssetLocationInfo>();
        private SessionCache _cache;
        private SchemaSet _schemaSet;
        private PluginRegistry _pluginRegistry;
        private VerifierPluginRegistry _verifierPluginRegistry;
        private int _instancesProcessedCount;
        private int _filesProcessedCount;
        private int _filesParsedCount;
        private int _instancesCopiedFromCacheCount;
        private int _instancesCompiledCount;
        private string _sessionCachePath;
        private long _maxTotalMemory;

        public static string CurrentDocument => _currentDocumentStack.Peek();

        public SessionCache Cache => _cache;
        public InstanceHandleSet MissingReferences => _missingReferences;
        public InstanceHandleSet ChangedInheritFromReferences => _requiredInheritFromSources;
        public SchemaSet SchemaSet => _schemaSet;
        public PluginRegistry Plugins => _pluginRegistry;
        public VerifierPluginRegistry VerifierPlugins => _verifierPluginRegistry;

        public DocumentProcessor(Settings settings, PluginRegistry pluginRegistry, VerifierPluginRegistry verifierPluginRegistry)
        {
            _pluginRegistry = pluginRegistry;
            _verifierPluginRegistry = verifierPluginRegistry;
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
            _schemaSet = new SchemaSet(Settings.Current.StableSort);
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
                _cache = new SessionCache();
                _cache.LoadCache(_sessionCachePath);
                _cache.InitializeCache();
            }
        }

        private void FinalizeSessionCache()
        {
            if (_cache != null)
            {
                _cache.SaveCache(false);
            }
        }

        private AssetDeclarationDocument OpenDocument(string sourcePath, string logicalPath, bool generateOutput, string configuration)
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

        }

        private AssetDeclarationDocument ProcessDocumentInternal(string logicalPath, string sourcePath, bool generateOutput, OutputManager outputManager, string basePathStream)
        {
            DateTime now = DateTime.Now;
            AssetDeclarationDocument result = OpenDocument(sourcePath, logicalPath);
            if (generateOutput)
            {
                if (result.State == DocumentState.Complete)
                {
                    return result;
                }
            }
            return null;
            // TODO:
            // throw new NotImplementedException();
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
                    document = ProcessDocumentInternal(fileName, fileName, generateOutput, null, Settings.Current.BasePatchStream);
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
    }
}
