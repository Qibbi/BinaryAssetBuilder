using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImmortalBodyModuleData
    {
        public ActiveBodyModuleData Base;
    }
}
