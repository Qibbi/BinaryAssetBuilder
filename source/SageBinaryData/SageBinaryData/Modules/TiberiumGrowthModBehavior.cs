using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct TiberiumGrowthModBehaviorModuleData
{
    public DieModuleData Base;
    public float GreenTiberiumMultiplier;
    public float BlueTiberiumMultiplier;
}
