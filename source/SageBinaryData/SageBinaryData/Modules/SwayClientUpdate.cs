using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SwayClientUpdateModuleData
    {
        public ClientUpdateModuleData Base;
    }
}
