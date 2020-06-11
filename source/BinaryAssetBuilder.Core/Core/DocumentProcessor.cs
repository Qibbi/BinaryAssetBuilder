using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

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
            }
        }

        private void FinalizeSessionCache()
        {
            if (_cache != null)
            {
                _cache.SaveCache(false);
            }
        }
    }
}
