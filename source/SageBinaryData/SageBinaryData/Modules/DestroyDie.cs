using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DestroyDieModuleData
    {
        public DieModuleData Base;
    }
}
