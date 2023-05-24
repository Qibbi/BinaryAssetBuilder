using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct MaxHealthUpgradeModuleData
{
    public UpgradeModuleData Base;
    public float AddMaxHealth;
    public MaxHealthChangeType ChangeType;
}
