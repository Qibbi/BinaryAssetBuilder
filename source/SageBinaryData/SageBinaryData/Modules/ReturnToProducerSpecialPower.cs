using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ReturnToProducerSpecialPowerModuleData
{
    public SpecialPowerModuleData Base;
}
