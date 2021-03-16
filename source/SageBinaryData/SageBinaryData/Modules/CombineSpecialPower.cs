using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CombineSpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
        public unsafe ObjectFilter* CombineWithObjectFilter;
    }
}
