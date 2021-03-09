using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentSaveLoad
    {
        public UIBaseComponent Base;
        public AnsiString FileToken;
    }
}
