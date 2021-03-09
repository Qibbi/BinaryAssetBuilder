using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentShell
    {
        public UIBaseComponent Base;
        public AnsiString LoadMusic;
    }
}
