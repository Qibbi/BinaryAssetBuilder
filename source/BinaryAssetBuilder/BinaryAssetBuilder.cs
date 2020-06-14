using BinaryAssetBuilder.Core;
using Metrics;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;

namespace BinaryAssetBuilder
{
    internal class BinaryAssetBuilder
    {
        private static Tracer _tracer;
        private static bool _pauseOnError;
        private static GUIBuildOutput _buildWindow;
        private static Thread _workThread;

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

        private int _runResult;

        public static string GetApplicationVersionString()
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            string title = entryAssembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            string name = entryAssembly.GetName().Version.ToString(3);
            string copyright = entryAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            return $"{title} {name}\n{copyright}\n";
        }

        private string[] ProcessPaths(string combinedPaths)
        {
            string[] result = combinedPaths.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int idx = 0; idx < result.Length; ++idx)
            {
                if (result[idx] != "*")
                {
                    result[idx] = ShPath.Canonicalize(Path.Combine(Settings.Current.DataRoot, result[idx]));
                }
            }
            return result;
        }

        public void ConsoleTraceWriter(string source, TraceEventType eventType, string message)
        {
            if (eventType == TraceEventType.Information || eventType == TraceEventType.Verbose)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine($"{eventType}: {message}");
            }
        }

        public void GuiTraceWriter(string source, TraceEventType eventType, string message)
        {
            _buildWindow?.Write(source, eventType, message);
            ConsoleTraceWriter(source, eventType, message);
        }

        public void DoBuildData()
        {
            try
            {
                MetricManager.AddListener(new ConsoleMetricsListener());
                MetricManager.OpenSession();
                _tracer.Message($"{nameof(BinaryAssetBuilder)} started");
                PluginRegistry pluginRegistry = new PluginRegistry(Settings.Current.Plugins, Settings.Current.TargetPlatform);
                VerifierPluginRegistry verifierPluginRegistry = new VerifierPluginRegistry(Settings.Current.VerifierPlugins, Settings.Current.TargetPlatform);
                new DocumentProcessor(Settings.Current, pluginRegistry, verifierPluginRegistry)
                    .ProcessDocument(Settings.Current?.InputPath, true, true);
                new DocumentProcessor(Settings.Current, pluginRegistry, verifierPluginRegistry)
                    .ProcessDocument(Path.Combine(Settings.Current.IntermediateOutputDirectory, HashProvider.StringHashesFile), true, false);
                _tracer.Message($"{nameof(BinaryAssetBuilder)} complete");
            }
            catch (BinaryAssetBuilderException ex)
            {
                ex.Trace(_tracer);
                if (_pauseOnError)
                {
                    if (_buildWindow is null)
                    {
                        Console.WriteLine("\nPress ENTER to exit\n");
                        Console.ReadLine();
                    }
                    else
                    {
                        Thread.Sleep(10000);
                    }
                }
                _runResult = (int)ex.ErrorCode;
                if (_buildWindow is null)
                {
                    return;
                }
                _buildWindow.SaveAndOpenText();
            }
            finally
            {
                MetricManager.CloseSession();
                if (_buildWindow != null)
                {
                    _buildWindow.DiffThreadClose();
                }
            }
        }

        public void PostProcessSettings()
        {
            Settings current = Settings.Current;
            string directoryName = Path.GetDirectoryName(GetType().Assembly.ManifestModule.FullyQualifiedName);
            if (!Path.IsPathRooted(current.InputPath))
            {
                current.InputPath = Path.GetFullPath(Path.Combine(directoryName, current.InputPath));
            }
            if (!Path.IsPathRooted(current.DataRoot))
            {
                current.DataRoot = Path.GetFullPath(Path.Combine(directoryName, current.DataRoot));
            }
            if (!Path.IsPathRooted(current.SchemaPath))
            {
                current.SchemaPath = Path.GetFullPath(Path.Combine(directoryName, current.SchemaPath));
            }
            if (string.IsNullOrEmpty(current.OutputDirectory))
            {
                current.OutputDirectory = Path.GetDirectoryName(current.InputPath);
            }
            if (string.IsNullOrEmpty(current.IntermediateOutputDirectory) || !current.LinkedStreams)
            {
                current.IntermediateOutputDirectory = current.OutputDirectory;
            }
            current.UseSessionCache = current.CacheLevel > 1;
            current.UseBuildCache = current.CacheLevel > 0;
            if (current.UseBuildCache && string.IsNullOrEmpty(current.BuildCacheDirectory))
            {
                current.BuildCacheDirectory = Path.Combine(current.OutputDirectory, "cache");
            }
            if (current.UseSessionCache && string.IsNullOrEmpty(current.SessionCacheDirectory))
            {
                current.SessionCacheDirectory = current.OutputDirectory;
            }
            current.BigEndian = current.TargetPlatform != TargetPlatform.Win32;
            string artPaths = null;
            string audioPaths = null;
            string dataPaths = null;
            if (!string.IsNullOrEmpty(current.BuildConfigurationName))
            {
                BuildConfiguration buildConfiguration = null;
                if (current.BuildConfigurations != null)
                {
                    foreach (BuildConfiguration bcn in current.BuildConfigurations)
                    {
                        if (bcn.Name.Equals(current.BuildConfigurationName, StringComparison.OrdinalIgnoreCase))
                        {
                            buildConfiguration = bcn;
                            break;
                        }
                    }
                }
                if (buildConfiguration is null)
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "Invalid build configuration '{0}' specified.", current.BuildConfigurationName);
                }
                artPaths = buildConfiguration.ArtPaths;
                audioPaths = buildConfiguration.AudioPaths;
                dataPaths = buildConfiguration.DataPaths;
                current.Postfix = buildConfiguration.Postfix;
                current.StreamPostfix = !buildConfiguration.AppendPostfixToStream
                                     || buildConfiguration.StreamPostfix != null
                                     || string.IsNullOrEmpty(buildConfiguration.Postfix) ? (buildConfiguration.StreamPostfix ?? string.Empty) : "_" + buildConfiguration.Postfix;
                if (string.IsNullOrEmpty(artPaths) && string.IsNullOrEmpty(dataPaths) && string.IsNullOrEmpty(audioPaths) && string.IsNullOrEmpty(current.Postfix))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "No search paths or postfix for configuration {0} specified", current.BuildConfigurationName);
                }
            }
            else
            {
                current.Postfix = null;
            }
            if (artPaths is null)
            {
                artPaths = Settings.Current.DefaultArtPaths;
            }
            if (audioPaths is null)
            {
                audioPaths = Settings.Current.DefaultAudioPaths;
            }
            if (dataPaths is null)
            {
                dataPaths = Settings.Current.DefaultDataPaths;
            }
            if (string.IsNullOrEmpty(artPaths) || string.IsNullOrEmpty(audioPaths) || string.IsNullOrEmpty(dataPaths))
            {
                throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "No search paths for selected configuration specified.");
            }
            current.ArtPaths = ProcessPaths(artPaths);
            current.AudioPaths = ProcessPaths(audioPaths);
            current.DataPaths = ProcessPaths(dataPaths);
        }

        public void Run(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string arg in args)
            {
                sb.AppendFormat("{0} ", arg);
            }
            Console.WriteLine("Command Line: {0}", sb.ToString());
            Tracer.TraceWrite = ConsoleTraceWriter;
            Settings.Current = ConfigurationManager.GetSection("assetbuilder") as Settings;
            if (Settings.Current is null)
            {
                throw new ApplicationException($"{nameof(BinaryAssetBuilder)} configuration not found.");
            }
            CommandLineOptionProcessor lineOptionProcessor = new CommandLineOptionProcessor(Settings.Current);
            if (args.Length == 0 || (args.Length > 0 && args[0] == "/?"))
            {
                Console.WriteLine(GetApplicationVersionString());
                Console.WriteLine($"Usage: {nameof(BinaryAssetBuilder)} {lineOptionProcessor.GetCommandLineHintText()}\n");
                Console.WriteLine(lineOptionProcessor.GetCommandLineHelpText());
            }
            else
            {
                if (!lineOptionProcessor.ProcessOptions(args, out string[] messages))
                {
                    Console.WriteLine(string.Join("\n", messages));
                }
                else
                {
                    PostProcessSettings();
                    if (Settings.Current.GuiMode)
                    {
                        _buildWindow = new GUIBuildOutput();
                        _buildWindow.Show();
                        Tracer.TraceWrite = GuiTraceWriter;
                    }
                    Tracer.DefaultTraceLevel = Settings.Current.TraceLevel;
                    _tracer = Tracer.GetTracer(nameof(BinaryAssetBuilder), "Main executable");
                    _tracer.TraceInfo("Command Line: {0}", sb.ToString());
                    if (string.IsNullOrEmpty(Settings.Current.DataRoot))
                    {
                        throw new BinaryAssetBuilderException(ErrorCode.InvalidArgument, "Data root not set in application configuration file.");
                    }
                    _pauseOnError = Settings.Current.PauseOnError;
                    if (_buildWindow != null)
                    {
                        _workThread = new Thread(new ThreadStart(DoBuildData));
                        _workThread.Start();
                        Application.Current.Run(_buildWindow);
                    }
                    else
                    {
                        DoBuildData();
                    }
                }
            }
        }

        [STAThread]
        private static int Main(string[] args)
        {
            BinaryAssetBuilder binaryAssetBuilder;
            try
            {
                binaryAssetBuilder = new BinaryAssetBuilder();
                if (binaryAssetBuilder is null)
                {
                    Console.WriteLine($"Critical failure: {nameof(BinaryAssetBuilder)} object could not be instantiated.");
                    return -1;
                }
                binaryAssetBuilder.Run(args);
            }
            catch (Exception ex)
            {
                if (_tracer != null)
                {
                    _tracer.TraceException("{0} \n\n   This is an internal error or potentially a bug.", ex);
                }
                else
                {
                    Console.WriteLine("{0} \n\n   This is an internal error or potentially a bug.", ex);
                }
                if (_pauseOnError)
                {
                    if (_buildWindow is null)
                    {
                        Console.WriteLine("\nPress ENTER to exit\n");
                        Console.ReadLine();
                    }
                    else
                    {
                        Thread.Sleep(10000);
                    }
                }
                return -1;
            }
            return binaryAssetBuilder._runResult;
        }
    }
}
