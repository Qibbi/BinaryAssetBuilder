using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ReturnToDockSpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
    }
}
