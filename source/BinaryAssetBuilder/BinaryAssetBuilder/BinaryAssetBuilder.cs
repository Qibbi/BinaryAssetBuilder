using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;
using BinaryAssetBuilder.Core;
using BinaryAssetBuilder.Core.Diagnostics;
using BinaryAssetBuilder.Core.Hashing;
using BinaryAssetBuilder.Core.IO;
using BinaryAssetBuilder.Core.SageXml;
using BinaryAssetBuilder.Metrics;

namespace BinaryAssetBuilder
{
    internal sealed class BinaryAssetBuilder : IDisposable
    {
        private static Tracer _tracer = Tracer.GetTracer(nameof(BinaryAssetBuilder), nameof(BinaryAssetBuilder));

        public static MetricDescriptor[] _descriptors = new[]
        {
            MetricManager.GetDescriptor("BAB.MapName", MetricType.Name, "Map name"),
            MetricManager.GetDescriptor("BAB.ProcessingTime", MetricType.Duration, "Total processing time"),
            MetricManager.GetDescriptor("BAB.FilesProcessedCount", MetricType.Count, "Number of files processed"),
            MetricManager.GetDescriptor("BAB.InstancesProcessedCount", MetricType.Count, "Number of instances processed"),
            MetricManager.GetDescriptor("BAB.InstancesCopiedFromCacheCount", MetricType.Count, "Number of instances copied from cache"),
            MetricManager.GetDescriptor("BAB.InstancesCompiledCount", MetricType.Count, "Number of instances compiled"),
            MetricManager.GetDescriptor("BAB.FilesParsedCount", MetricType.Count, "Number of files parsed"),
            MetricManager.GetDescriptor("BAB.SessionCacheSize", MetricType.Size, "Size of session cache"),
            MetricManager.GetDescriptor("BAB.MaxMemorySize", MetricType.Size, "Maximum allocated memory"),
            MetricManager.GetDescriptor("BAB.StartupTime", MetricType.Duration, "Startup time"),
            MetricManager.GetDescriptor("BAB.SessionSerialization", MetricType.Duration, "Session Serialization time"),
            MetricManager.GetDescriptor("BAB.ShutdownTime", MetricType.Duration, "Shutdown time"),
            MetricManager.GetDescriptor("BAB.DocumentProcessingTime", MetricType.Duration, "Document processing time"),
            MetricManager.GetDescriptor("BAB.NetworkCacheEnabled", MetricType.Enabled, "Network cache enabled"),
            MetricManager.GetDescriptor("BAB.SessionCacheEnabled", MetricType.Enabled, "Session cache enabled"),
            MetricManager.GetDescriptor("BAB.LinkedStreamsEnabled", MetricType.Enabled, "Linked streams enabled"),
            MetricManager.GetDescriptor("BAB.InstanceProcessingTime", MetricType.Duration, "Instance Processing Time"),
            MetricManager.GetDescriptor("BAB.OutputPrepTime", MetricType.Duration, "Output Preparation Time"),
            MetricManager.GetDescriptor("BAB.PrepSourceTime", MetricType.Duration, "Prepare Sources Time"),
            MetricManager.GetDescriptor("BAB.ProcIncludesTime", MetricType.Duration, "Include Processing Time"),
            MetricManager.GetDescriptor("BAB.ValidateTime", MetricType.Duration, "Validation Time"),
            MetricManager.GetDescriptor("BAB.BuildSuccessful", MetricType.Success, "Build completed successfully")
        };

        private readonly Mutex _mutex = new();
        private readonly Mutex _sessionCacheSaveMutex = new();
        private PluginRegistry _pluginRegistry;
        private VerifierPluginRegistry _verifierPluginRegistry;
        private ISessionCache _cache;
        private PathMonitor _monitor;
        private DateTime _startTime = DateTime.Now;
        private int _runResult;
        private TimeSpan _cacheSerializationTime;

        public ISessionCache Cache { set => _cache = value; }
        public PathMonitor Monitor { set => _monitor = value; }
        public int RunResult => _runResult;

        public BinaryAssetBuilder()
        {
            AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SageBinaryData.dll"));
            _pluginRegistry = new PluginRegistry(Settings.Current.Plugins, Settings.Current.TargetPlatform);
            _verifierPluginRegistry = new VerifierPluginRegistry(Settings.Current.VerifierPlugins, Settings.Current.TargetPlatform);
        }

        public static string GetApplicationVersionString()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            string title = assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title ?? string.Empty;
            string version = assembly.GetName().Version.ToString();
            string copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? string.Empty;
            return $"{title} {version}\n{copyright}\n";
        }

        private void InitializeSessionCache()
        {
            if (Settings.Current.SessionCache)
            {
                string sessionCachePath = Path.Combine(Settings.Current.SessionCacheDirectory, "BinaryAssetBuilder.SessionCache.xml");
                if (sessionCachePath != _cache.CacheFileName)
                {
                    DateTime now = DateTime.Now;
                    _cache.LoadCache(sessionCachePath);
                    _cacheSerializationTime = DateTime.Now - now;
                }
                if (Settings.Current.Resident && _monitor.IsResultTrustable)
                {
                    _cache.InitializeCache(_monitor.GetChangedFiles());
                }
                else
                {
                    _cache.InitializeCache(new System.Collections.Generic.List<string>());
                }
                _monitor.Reset();
                if (_pluginRegistry.AssetBuilderPluginsVersion != _cache.AssetCompilersVersion)
                {
                    Settings.Current.StreamHints = false;
                    _cache.AssetCompilersVersion = _pluginRegistry.AssetBuilderPluginsVersion;
                }
                _tracer.TraceInfo("Session caching enabled ('{0}').", sessionCachePath);
            }
            else
            {
                _cache.InitializeCache(new System.Collections.Generic.List<string>());
            }
        }

        private bool BuildStringHashes(SchemaSet theSchemas)
        {
            string fileName = Path.Combine(HashProvider.OutputDirectory, HashProvider.StringHashesFile);
            new DocumentProcessor(Settings.Current, _pluginRegistry, _verifierPluginRegistry)
            {
                Cache = _cache,
                SchemaSet = theSchemas
            }.ProcessDocument(fileName, true, false, out bool result);
            return result;
        }

        public void ConsoleTraceWriter(string source, TraceEventType eventType, string message)
        {
            if (eventType == TraceEventType.Information || eventType == TraceEventType.Verbose)
            {
                Console.WriteLine($"[{DateTime.Now - _startTime}] {message}");
            }
            else
            {
                Console.WriteLine($"[{DateTime.Now - _startTime}] {eventType}: {message}");
            }
        }

        public void DoBuildData()
        {
            try
            {
                MetricManager.OpenSession();
                _startTime = DateTime.Now;
                _tracer.Message("BinaryAssetBuilder started");
                MetricManager.IsEnabled = Settings.Current.MetricsReporting;
                SchemaSet theSchemas = new SchemaSet(Settings.Current.StableSort);
                HashProvider.InitializeStringHashes(Settings.Current.SessionCacheDirectory);
                MetricManager.Submit("BAB.SessionCacheEnabled", Settings.Current.SessionCache);
                InitializeSessionCache();
                DocumentProcessor documentProcessor = new DocumentProcessor(Settings.Current, _pluginRegistry, _verifierPluginRegistry)
                {
                    Cache = _cache,
                    SchemaSet = theSchemas
                };
                documentProcessor.ProcessDocument(Settings.Current.InputPath, true, true, out bool success);
                MetricManager.IsEnabled = false;
                Settings.Current.SingleFile = true;
                Settings.Current.BuildCache = false;
                if (Settings.Current.OutputAssetReport)
                {
                    AssetReport.Close();
                }
                HashProvider.FinalizeStringHashes();
                if (Settings.Current.OutputStringHashes)
                {
                    BuildStringHashes(theSchemas);
                }
                MetricManager.IsEnabled = Settings.Current.MetricsReporting;
                if (Settings.Current.SessionCache && (success || Settings.Current.PartialSessionCache) && !Settings.Current.FreezeSessionCache)
                {
                    DateTime now = DateTime.Now;
                    _cache.SaveCache(Settings.Current.CompressedSessionCache);
                    _cacheSerializationTime += DateTime.Now - now;
                    MetricManager.Submit("BAB.SessionSerialization", _cacheSerializationTime);
                }
                _tracer.Message("BinaryAssetBuilder complete");
                DocumentProcessor.OutputTypeCompileTimes();
            }
            catch (Exception ex)
            {
                _runResult = -1;
                if (ex is BinaryAssetBuilderException binaryAssetBuilderException)
                {
                    binaryAssetBuilderException.Trace(_tracer);
                }
                else
                {
                    _tracer.TraceError(ex.ToString());
                }
                if (Settings.Current.PauseOnError)
                {
                    Console.WriteLine("\nPress ENTER to exit\n");
                    Console.ReadLine();
                }
                if (Settings.Current.Resident)
                {
                    Console.WriteLine("Resident BAB must now exit due to previous errors.");
                }
            }
            finally
            {
                MetricManager.CloseSession();
            }
            try
            {
                if (!Settings.Current.Resident)
                {
                    return;
                }
            }
            finally
            {
                if (RunResult != 0)
                {
                    Environment.Exit(RunResult);
                }
            }
        }

        public void Run()
        {
            _pluginRegistry.ReInitialize(Settings.Current.Plugins, Settings.Current.TargetPlatform);
            _verifierPluginRegistry.ReInitialize(Settings.Current.VerifierPlugins, Settings.Current.TargetPlatform);
            Tracer.TraceWrite = new TraceWriteHandler(ConsoleTraceWriter);
            Tracer.SetTraceLevel(Settings.Current.TraceLevel);
            if (string.IsNullOrEmpty(Settings.Current.DataRoot))
            {
                throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "Data root not set.");
            }
            DoBuildData();
        }

        public void Dispose()
        {
            _mutex.Dispose();
            _sessionCacheSaveMutex.Dispose();
        }
    }
}
