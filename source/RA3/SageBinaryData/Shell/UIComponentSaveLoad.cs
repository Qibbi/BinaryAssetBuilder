using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.Shell
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentSaveLoad
    {
        public UIBaseComponent Base;
        public AnsiString FileToken;
    }
}
