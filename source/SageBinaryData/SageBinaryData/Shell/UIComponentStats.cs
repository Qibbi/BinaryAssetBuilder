using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentStats
    {
        public UIBaseComponent Base;
        public AnsiString PlayerToken;
        public AnsiString TitleToken;
        public AnsiString DataToken;
    }
}
