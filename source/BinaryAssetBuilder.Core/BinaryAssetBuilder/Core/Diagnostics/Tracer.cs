using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace BinaryAssetBuilder.Core.Diagnostics
{
    public delegate void TraceWriteHandler(string source, TraceEventType eventType, string message);

    public class Tracer
    {
        private class InternalScopedTrace : IDisposable
        {
            private readonly Tracer _tracer;
            private readonly string _text;
            public InternalScopedTrace(Tracer tracer, string text)
            {
                _text = text;
                _tracer = tracer;
                _tracer.Output(TraceEventType.Verbose, "Entering: {0}", _text);
                ++IndentLevel;
            }

            public void Dispose()
            {
                --IndentLevel;
                _tracer.Output(TraceEventType.Verbose, "Leaving: {0}", _text);
            }
        }

        private static readonly Dictionary<string, Tracer> _tracers = new Dictionary<string, Tracer>();
        private static readonly LocalDataStoreSlot _indentLEvelStore = Thread.AllocateDataSlot();
        private static TraceKind _traceMask;

        public static TraceKind[] VerbosityLevels = new[]
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

        private static int IndentLevel
        {
            get
            {
                int result = 0;
                object data = Thread.GetData(_indentLEvelStore);
                if (data is null)
                {
                    Thread.SetData(_indentLEvelStore, 0);
                }
                else
                {
                    result = (int)data;
                }
                return result;
            }
            set => Thread.SetData(_indentLEvelStore, value);
        }

        public static TraceWriteHandler TraceWrite { get; set; }

        private readonly string _name;
        private readonly string _description;

        static Tracer()
        {
            _traceMask = VerbosityLevels[1];
        }

        private Tracer(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public static Tracer GetTracer(string name, string description)
        {
            if (!_tracers.TryGetValue(name, out Tracer result))
            {
                result = new Tracer(name, description);
                _tracers.Add(name, result);
            }
            return result;
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

        public static void SetTraceLevel(int level)
        {
            _traceMask = VerbosityLevels[level];
        }

        private void Output(TraceEventType type, string format, params object[] args)
        {
            OnWrite(_name, type, new StringBuilder(new string(' ', IndentLevel * 4)).AppendFormat(format, args).ToString());
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
