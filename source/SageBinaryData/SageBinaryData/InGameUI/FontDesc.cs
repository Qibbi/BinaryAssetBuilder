using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.InGameUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FontDesc
    {
        public AnsiString Name;
        public uint Size;
        public SageBool Bold;
    }
}
