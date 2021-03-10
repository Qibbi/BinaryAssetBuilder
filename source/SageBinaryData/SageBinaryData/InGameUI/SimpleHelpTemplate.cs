using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUISimpleHelpTemplate
    {
        public AnsiString Title;
        public AnsiString Description;
        public AnsiString TypeDescription;
        public AnsiString Instructions;
    }
}
