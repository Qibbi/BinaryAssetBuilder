using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using BinaryAssetBuilder.Core.CommandLine;
using BinaryAssetBuilder.Core.IO;
using BinaryAssetBuilder.Core.Session;
using BinaryAssetBuilder.Core.Xml;
using BinaryAssetBuilder.Metrics;
using BinaryAssetBuilder.Remote;

namespace BinaryAssetBuilder
{
    internal static class Program
    {
        public sealed class ResidentInstance : IDisposable
        {
            private static ServerState _state;
            private static SessionCache _theSessionCache;
            private static PathMonitor _thePathMonitor;

            private Mutex _processSync;
            private bool _isOwned;
            private BinaryAssetBuilder _bab;
            private Thread _babThread;
            private Mutex _residentBabReady;

            public static ServerState State => _state;
            public static SessionCache TheSessionCache => _theSessionCache;
            public static PathMonitor ThePathMonitor => _thePathMonitor;

            public bool IsFirstInstance => _isOwned;

            public ResidentInstance()
            {
                _processSync = new Mutex(true, Assembly.GetExecutingAssembly().GetName().Name, out _isOwned);
            }

            public void Initialize()
            {
                _state = ServerState.Loading;
                _thePathMonitor = new PathMonitor(Settings.Current.ProcessedMonitorPaths);
                _theSessionCache = new SessionCache();
                _bab = new BinaryAssetBuilder();
                _bab.Cache = TheSessionCache;
                _bab.Monitor = ThePathMonitor;
                if (Settings.Current.Resident)
                {
                    _residentBabReady = new Mutex(true, "BinaryAssetBuilderReady");
                }
                _state = ServerState.Ready;
            }

            public bool SetupSettings(string[] args)
            {
                string cfg = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "BinaryAssetBuilder.cfg");
                if (!File.Exists(cfg))
                {
                    throw new BinaryAssetBuilderException(ErrorCode.FileNotFound, "BinaryAssetBuilder configuration not found.");
                }
                BinaryAssetBuilderDocument babConfig = new BinaryAssetBuilderDocument(cfg);
                Settings current = new Settings();
                current.ReadXml(babConfig.GetNode(nameof(Settings)));
                Settings.Current = current;
                CommandLineOptionProcessor processor = new CommandLineOptionProcessor(Settings.Current);
                if (args.Length == 0 || (args.Length > 0 && (args[0] == "/?" || args[0] == "-?")))
                {
                    Console.WriteLine(BinaryAssetBuilder.GetApplicationVersionString());
                    Console.WriteLine($"Usage: {nameof(BinaryAssetBuilder)} {processor.GetCommandLineHintText()}\n");
                    Console.WriteLine(processor.GetCommandLineHelpText(Console.LargestWindowWidth));
                    return false;
                }
                if (args.Length != 0 && !processor.ProcessOptions(args, out string[] messages))
                {
                    Console.WriteLine(string.Join("\n", messages));
                    Console.WriteLine($"Usage: {nameof(BinaryAssetBuilder)} {processor.GetCommandLineHintText()}\n");
                    Console.WriteLine(processor.GetCommandLineHelpText(Console.LargestWindowWidth));
                    return false;
                }
                SettingsLoader.PostProcessSettings(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                StringBuilder sb = new();
                foreach (string str in args)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0} ", str);
                }
                Console.WriteLine("Command Line: {0}", sb.ToString());
                return true;
            }

            public void StartBuild(string[] args)
            {
                if (!SetupSettings(args))
                {
                    return;
                }
                _babThread = new Thread(_bab.Run)
                {
                    Name = "BabBuildThread"
                };
                _babThread.Start();
            }

            public void Dispose()
            {
                if (_isOwned)
                {
                    return;
                }
                _processSync.ReleaseMutex();
                _isOwned = false;
            }
        }

        private static ResidentInstance _theResidentServer;

        private static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            using (ResidentInstance residentInstance = new ResidentInstance())
            {
                if (!residentInstance.IsFirstInstance)
                {
                    return;
                }
                _theResidentServer = residentInstance;
                if (!residentInstance.SetupSettings(args))
                {
                    return;
                }
                residentInstance.Initialize();
                MetricManager.AddListener(new ConsoleMetricsListener());
                residentInstance.StartBuild(args);
            }
        }
    }
}
