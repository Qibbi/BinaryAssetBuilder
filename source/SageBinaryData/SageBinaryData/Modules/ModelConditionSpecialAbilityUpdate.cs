using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ModelConditionSpecialAbilityUpdateModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public int WhichSpecialPower;
}
