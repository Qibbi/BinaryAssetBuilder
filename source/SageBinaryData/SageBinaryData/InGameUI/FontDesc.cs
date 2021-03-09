using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FontDesc
    {
        public AnsiString Name;
        public uint Size;
        public SageBool Bold;
    }
}
