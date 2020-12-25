using BinaryAssetBuilder.Core;
using Metrics;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace BinaryAssetBuilder
{
    internal class BinaryAssetBuilder
    {
        private static Tracer _tracer = Tracer.GetTracer(nameof(BinaryAssetBuilder), nameof(BinaryAssetBuilder));
        private static GUIBuildOutput _buildWindow;

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

        private Mutex _mutex = new Mutex();
        private Mutex _sessionCacheMutex = new Mutex();
        private PluginRegistry _pluginRegistry;
        private VerifierPluginRegistry _verifierPluginRegistry;
        private ISessionCache _sessionCache;
        private PathMonitor _pathMonitor;
        private DateTime _startTime = DateTime.Now;
        private int _runResult;
        private TimeSpan _cacheSerializationTime;

        public ISessionCache Cache { get => _sessionCache; set => _sessionCache = value; }
        public PathMonitor Monitor { get => _pathMonitor; set => _pathMonitor = value; }
        public int RunResult => _runResult;

        public BinaryAssetBuilder()
        {
            _pluginRegistry = new PluginRegistry(Settings.Current.Plugins, Settings.Current.TargetPlatform);
            _verifierPluginRegistry = new VerifierPluginRegistry(Settings.Current.VerifierPlugins, Settings.Current.TargetPlatform);
        }

        private void InitializeSessionCache()
        {
            if (Settings.Current.UseSessionCache)
            {
                string sessionCachePath = Path.Combine(Settings.Current.SessionCacheDirectory, "BinaryAssetBuilder.SessionCache.xml");
                if (sessionCachePath != _sessionCache.CacheFileName)
                {
                    DateTime now = DateTime.Now;
                    _sessionCache.LoadCache(sessionCachePath);
                    _cacheSerializationTime = DateTime.Now - now;
                }
                if (Settings.Current.Resident && _pathMonitor.IsResultTrustable())
                {
                    _sessionCache.InitializeCache(_pathMonitor.GetChangedFiles());
                }
                else
                {
                    _sessionCache.InitializeCache(new System.Collections.Generic.List<string>());
                }
                _pathMonitor.Reset();
                if (_pluginRegistry.AssetBuilderPluginVersion != _sessionCache.AssetCompilersVersion)
                {
                    Settings.Current.UseStreamHints = false;
                    _sessionCache.AssetCompilersVersion = _pluginRegistry.AssetBuilderPluginVersion;
                }
                _tracer.TraceInfo("Session caching enabled ('{0}').", sessionCachePath);
            }
            else
            {
                _sessionCache.InitializeCache(new System.Collections.Generic.List<string>());
            }
        }

        private bool BuildStringHashes(SchemaSet theSchemas)
        {
            string fileName = Path.Combine(HashProvider.GetOutputDirectory(), HashProvider.StringHashesFile);
            new DocumentProcessor(Settings.Current, _pluginRegistry, _verifierPluginRegistry)
            {
                Cache = _sessionCache,
                SchemaSet = theSchemas
            }.ProcessDocument(fileName, true, false, out bool result);
            return result;
        }

        public static string GetApplicationVersionString()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            string title = entryAssembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title ?? string.Empty;
            string name = entryAssembly.GetName().Version.ToString(3);
            string copyright = entryAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? string.Empty;
            return $"{title} {name}\n{copyright}\n";
        }

        public void BaseTraceWriter(string source, TraceEventType eventType, string message)
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

        public void GuiTraceWriter(string source, TraceEventType eventType, string message)
        {
            BaseTraceWriter(source, eventType, message);
            _buildWindow?.Write(source, eventType, message);
        }

        public void DoBuildData()
        {
            try
            {
                MetricManager.OpenSession();
                _tracer.Message($"{nameof(BinaryAssetBuilder)} started");
                MetricManager.IsEnabled = true;
                SchemaSet theSchemas = new SchemaSet(Settings.Current.StableSort);
                HashProvider.InitializeStringHashes(Settings.Current.SessionCacheDirectory);
                MetricManager.Submit("BAB.SessionCacheEnabled", Settings.Current.UseSessionCache);
                InitializeSessionCache();
                DocumentProcessor documentProcessor = new DocumentProcessor(Settings.Current, _pluginRegistry, _verifierPluginRegistry)
                {
                    Cache = _sessionCache,
                    SchemaSet = theSchemas
                };
                documentProcessor.ProcessDocument(Settings.Current.InputPath, true, true, out bool success);
                MetricManager.IsEnabled = false;
                Settings.Current.SingleFile = true;
                Settings.Current.UseBuildCache = false;
                if (Settings.Current.OutputAssetReport)
                {
                    AssetReport.Close();
                }
                HashProvider.FinalizeStringHashes();
                if (Settings.Current.OutputStringHashes)
                {
                    BuildStringHashes(theSchemas);
                }
                if (Settings.Current.UseSessionCache && (success || Settings.Current.UsePartialSessionCache) && !Settings.Current.FreezeSessionCache)
                {
                    DateTime now = DateTime.Now;
                    _sessionCache.SaveCache(Settings.Current.UseCompressedSessionCache);
                    _cacheSerializationTime += DateTime.Now - now;
                    MetricManager.Submit("BAB.SessionSerialization", _cacheSerializationTime);
                }
                _tracer.Message($"{nameof(BinaryAssetBuilder)} complete");
                documentProcessor.OutputTypeCompileTime();
            }
            catch (Exception ex)
            {
                _runResult = -1;
                if (ex.GetType() == typeof(BinaryAssetBuilderException))
                {
                    ((BinaryAssetBuilderException)ex).Trace(_tracer);
                }
                else
                {
                    _tracer.TraceError(ex.ToString());
                }
                if (Settings.Current.PauseOnError && _buildWindow is null)
                {
                    Console.WriteLine("\nPress ENTER to exit\n");
                    Console.ReadLine();
                }
                if (_buildWindow != null)
                {
                    _buildWindow.SaveAndOpenText();
                }
                if (Settings.Current.Resident)
                {
                    Console.WriteLine("Resident BAB must now exit due to previous errors.");
                }
            }
            finally
            {
                MetricManager.CloseSession();
                if (_buildWindow != null)
                {
                    _buildWindow.DiffThreadClose();
                    _buildWindow = null;
                }
            }
            try
            {
                if (!Settings.Current.Resident)
                {
                    return;
                }
                // ((IClientCommand)Activator.GetObject(typeof(IClientCommand), "ipc://BinaryAssetBuilderClientChannel/ClientCommand")).NotifyBuildFinished(RunResult);
            }
            catch
            {
            }
            finally
            {
                if (RunResult != 0)
                {
                    if (Settings.Current.Resident)
                    {
                        // Program._systemTrayForm.systemTrayIcon.Visible = false;
                    }
                    Environment.Exit(RunResult);
                }
            }
        }

        public void Run()
        {
            _pluginRegistry.ReInitialize(Settings.Current.Plugins, Settings.Current.TargetPlatform);
            _verifierPluginRegistry.ReInitialize(Settings.Current.VerifierPlugins, Settings.Current.TargetPlatform);
            Tracer.TraceWrite = BaseTraceWriter;
            if (Settings.Current.GuiMode)
            {
                _buildWindow = new GUIBuildOutput();
                _buildWindow.Show();
                Tracer.TraceWrite = GuiTraceWriter;
            }
            Tracer.SetTraceLevel(Settings.Current.TraceLevel);
            if (string.IsNullOrEmpty(Settings.Current.DataRoot))
            {
                throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "Data root not set in application configuration file.");
            }
            if (Settings.Current.GuiMode)
            {
                new Thread(new ThreadStart(DoBuildData)).Start();
                // Application.Run((Form)_buildWindow);
            }
            else
            {
                DoBuildData();
            }
        }
    }
}
