using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct StoreObjectsSpecialPowerModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public float Radius;
}
