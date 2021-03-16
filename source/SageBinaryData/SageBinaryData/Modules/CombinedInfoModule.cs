using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CombinedInfoModuleData
    {
        public CreateModuleData Base;
        public AnsiString DockingBone;
    }
}
