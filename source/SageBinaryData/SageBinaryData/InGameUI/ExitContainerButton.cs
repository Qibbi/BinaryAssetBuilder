using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIExitContainerButtonSettings
    {
        public AnsiString HelpTitleFormat;
        public AnsiString HelpDescription;
    }
}
