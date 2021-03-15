using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HighlanderBodyModuleData
    {
        public ActiveBodyModuleData Base;
    }
}
