using BinaryAssetBuilder.Core;
using BinaryAssetBuilder.Native;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace BinaryAssetBuilder
{
    internal static class Program
    {
        public class ResidentInstance : IDisposable
        {
            // private static ServerState _state;
            private static SessionCache _theSessionCache;
            private static PathMonitor _thePathMonitor;

            private Mutex _processSync;
            private bool _isOwned;
            // private IpcChannel _ipcChannel;
            private BinaryAssetBuilder _bab;
            private Thread _babThread;
            private Mutex _residentBabReadyMutex;

            public static SessionCache TheSessionCache => _theSessionCache;
            public static PathMonitor ThePathMonitor => _thePathMonitor;
            // public static ServerState State => _state;

            public bool IsFirstInstance => _isOwned;

            public ResidentInstance()
            {
                _processSync = new Mutex(true, Assembly.GetExecutingAssembly().GetName().Name, out _isOwned);
            }

            public void Initialize()
            {
                _thePathMonitor = new PathMonitor(Settings.Current.ProcessedMonitorPaths);
                _theSessionCache = new SessionCache();
                _bab = new BinaryAssetBuilder
                {
                    Cache = TheSessionCache,
                    Monitor = ThePathMonitor
                };
                if (Settings.Current.Resident)
                {
                    // CreateRemotingObjects();
                    _residentBabReadyMutex = new Mutex(true, "BinaryAssetBuilderResidentReady");
                }
                Metrics.MetricManager.AddListener(new FileMetricsListener(BinaryAssetBuilder._descriptors));
            }

            public bool SetupSettings(string[] args)
            {
                Settings.Current = (Settings)(ConfigurationManager.GetSection("assetbuilder") as Settings).Clone();
                if (Settings.Current is null)
                {
                    throw new ApplicationException("BinaryAssetBuilder configuration not found.");
                }
                if (args.Length == 0 || (args.Length > 0 && (args[0] == "/?" || args[0] == "-?")))
                {
                    CommandLineOptionProcessor processor = new CommandLineOptionProcessor(Settings.Current);
                    Console.WriteLine(BinaryAssetBuilder.GetApplicationVersionString());
                    Console.WriteLine($"Usage: {nameof(BinaryAssetBuilder)} {processor.GetCommandLineHintText()}\n");
                    Console.WriteLine(processor.GetCommandLineHelpText());
                    return false;
                }
                if (args.Length != 0 && !new CommandLineOptionProcessor(Settings.Current).ProcessOptions(args, out string[] messages))
                {
                    Console.WriteLine(string.Join("\n", messages));
                    return false;
                }
                SettingsLoader.PostProcessSettings(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                StringBuilder sb = new StringBuilder();
                foreach (string str in args)
                {
                    sb.AppendFormat("{0} ", str);
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
                _babThread = new Thread(new ThreadStart(_bab.Run))
                {
                    Name = "BabBuildThread"
                };
                _babThread.Start();
            }

            public void Dispose()
            {
                if (!_isOwned)
                {
                    return;
                }
                _processSync.ReleaseMutex();
                _isOwned = false;
                // ChannelServices.UnregisterChannel((IChannel)_ipcChannel);
                // _ipcChannel = null;
            }
        }

        private static ResidentInstance _theResidentServer;

        // public static SystemTrayForm _systemTrayForm;

        [STAThread]
        private static void Main(string[] args)
        {
            IntPtr consoleWindow = IntPtr.Zero;
            if (Kernel32.AllocConsole())
            {
                consoleWindow = Kernel32.GetConsoleWindow();
                User32.SetLayeredWindowAttributes(consoleWindow, 0u, 225, 2);
            }
            User32.ShowWindow(consoleWindow, 5);
            Console.ForegroundColor = ConsoleColor.Green;
            using (ResidentInstance residentInstance = new ResidentInstance())
            {
                if (!residentInstance.IsFirstInstance)
                {
                    return;
                }
                _theResidentServer = residentInstance;
                if (residentInstance.SetupSettings(args))
                {
                    residentInstance.Initialize();
                    if (Settings.Current.Resident)
                    {
                        // 
                    }
                    else
                    {
                        residentInstance.StartBuild(args);
                    }
                }
            }
            Console.WriteLine("\nPress ENTER to exit\n");
            Console.ReadLine();
        }
    }
}
