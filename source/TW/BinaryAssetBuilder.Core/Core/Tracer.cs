using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace BinaryAssetBuilder.Core
{
    public delegate void TraceWriteHandler(string source, TraceEventType eventType, string message);

    public class Tracer
    {
        private class InternalTraceSource : TraceSource
        {
            public InternalTraceSource(string name) : base(name)
            {
            }

            protected override string[] GetSupportedAttributes()
            {
                return new string[] { "mask" };
            }
        }

        private class InternalScopedTrace : IDisposable
        {
            private readonly Tracer _tracer;
            private readonly string _text;

            public InternalScopedTrace(Tracer tracer, string text)
            {
                _text = text;
                _tracer = tracer;
                _tracer.Output(TraceEventType.Verbose, $"Entering: {_text}");
                ++IndentLevel;
            }

            public void Dispose()
            {
                --IndentLevel;
                _tracer.Output(TraceEventType.Verbose, $"Leaving: {_text}");
            }
        }

        private static Dictionary<string, Tracer> Tracers { get; }
        private static LocalDataStoreSlot IndentLevelStore { get; }
        private static int IndentLevel
        {
            get
            {
                int result = 0;
                object data = Thread.GetData(IndentLevelStore);
                if (data is null)
                {
                    Thread.SetData(IndentLevelStore, 0);
                }
                else
                {
                    result = (int)data;
                }
                return result;
            }
            set => Thread.SetData(IndentLevelStore, value);
        }

        public static int DefaultTraceLevel { get; set; }
        public static TraceKind[] VerbosityLevels { get; }
        public static TraceWriteHandler TraceWrite { get; set; }

        private TraceSource _traceSource;
        private readonly string _name;
#pragma warning disable IDE0052 // Remove unread private members
        private readonly string _description;
#pragma warning restore IDE0052 // Remove unread private members
        private TraceKind _traceMask;

        public bool IsEnabled { get; set; }

        private TraceSource TraceSource
        {
            get
            {
                if (_traceSource is null)
                {
                    _traceSource = new InternalTraceSource(_name);
                }
                return _traceSource;
            }
        }

        static Tracer()
        {
            Tracers = new Dictionary<string, Tracer>();
            IndentLevelStore = Thread.AllocateDataSlot();
            DefaultTraceLevel = 1;
            VerbosityLevels = new TraceKind[]
            {
                TraceKind.None,
                TraceKind.Exception | TraceKind.Assert | TraceKind.Error | TraceKind.Warning | TraceKind.Message,
                TraceKind.Exception | TraceKind.Assert | TraceKind.Error | TraceKind.Warning | TraceKind.Message,
                (TraceKind)255,
                (TraceKind)255,
                (TraceKind)255,
                (TraceKind)511,
                (TraceKind)511,
                (TraceKind)511,
                TraceKind.All
            };
        }

        private Tracer(string name, string description)
        {
            _name = name;
            _description = description;
            _traceMask = VerbosityLevels[DefaultTraceLevel];
            IsEnabled = false;
            IsEnabled = string.Equals(Environment.GetEnvironmentVariable("BabEnableTrace"), "true", StringComparison.OrdinalIgnoreCase);
            if (!IsEnabled)
            {
                return;
            }
            string attribute = TraceSource.Attributes["mask"];
            if (attribute is null)
            {
                return;
            }
            _traceMask = (TraceKind)Enum.Parse(typeof(TraceKind), attribute, true);
        }

        private static void OnWrite(string source, TraceEventType type, string message)
        {
            if (TraceWrite is null)
            {
                return;
            }
            TraceWrite(source, type, message);
        }

        private static string GetCallingMethodInfo(string additionalInfo)
        {
            MethodBase method = new StackFrame(2).GetMethod();
            return $"{method.DeclaringType.Name}.{method.Name}({additionalInfo})";
        }

        public static Tracer GetTracer(string name, string description)
        {
            if (!Tracers.TryGetValue(name, out Tracer result))
            {
                result = new Tracer(name, description);
                Tracers.Add(name, result);
            }
            return result;
        }

        public void SetTraceLevel(int level)
        {
            _traceMask = VerbosityLevels[level];
        }

        private void Output(TraceEventType type, string format, params object[] args)
        {
            if (IsEnabled)
            {
                new StringBuilder(new string(' ', IndentLevel * Trace.IndentSize)).AppendFormat(format, args);
            }
            else
            {
                OnWrite(TraceSource.Name, type, string.Format(format, args));
            }
        }

        public IDisposable TraceMethod()
        {
            return (_traceMask & TraceKind.Method) == TraceKind.None ? null : new InternalScopedTrace(this, GetCallingMethodInfo(string.Empty));
        }

        public IDisposable TraceMethod(string format, params object[] args)
        {
            return (_traceMask & TraceKind.Method) == TraceKind.None ? null : new InternalScopedTrace(this, GetCallingMethodInfo(string.Format(format, args)));
        }

        public void Message(string format, params object[] args)
        {
            if ((_traceMask & TraceKind.Message) == TraceKind.None)
            {
                return;
            }
            Output(TraceEventType.Information, format, args);
        }

        public void TraceData(string format, params object[] args)
        {
            if ((_traceMask & TraceKind.Data) == TraceKind.None)
            {
                return;
            }
            Output(TraceEventType.Verbose, format, args);
        }

        public void TraceInfo(string format, params object[] args)
        {
            if ((_traceMask & TraceKind.Info) == TraceKind.None)
            {
                return;
            }
            Output(TraceEventType.Information, format, args);
        }

        public void TraceNote(string format, params object[] args)
        {
            if ((_traceMask & TraceKind.Note) == TraceKind.None)
            {
                return;
            }
            Output(TraceEventType.Verbose, format, args);
        }

        public void TraceError(string format, params object[] args)
        {
            if ((_traceMask & TraceKind.Error) == TraceKind.None)
            {
                return;
            }
            Output(TraceEventType.Error, format, args);
        }

        public void TraceWarning(string format, params object[] args)
        {
            if ((_traceMask & TraceKind.Warning) == TraceKind.None)
            {
                return;
            }
            Output(TraceEventType.Warning, format, args);
        }

        public void TraceException(string format, params object[] args)
        {
            if ((_traceMask & TraceKind.Exception) == TraceKind.None)
            {
                return;
            }
            Output(TraceEventType.Critical, format, args);
        }
    }
}
