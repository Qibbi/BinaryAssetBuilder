using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.InGameUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentAptMediator
    {
        public UIBaseComponent Base;
        public AnsiString AptGlobalLoadVarName;
        public AnsiString AptEventHandlerName;
        public AnsiString AptFSCommandHandlerName;
        public AnsiString AptTokenDelimiters;
        public AnsiString NewSkoolIndicator;
        public AnsiString FunctionSeparator;
        public AnsiString ValueSeparator;
        public AnsiString InputParameterSeparator;
        public AnsiString ParameterNameSeparator;
        public AnsiString ParameterStartIndicator;
        public AnsiString SubObjectSeparator;
        public AnsiString OutputParameterSeparator;
    }
}
