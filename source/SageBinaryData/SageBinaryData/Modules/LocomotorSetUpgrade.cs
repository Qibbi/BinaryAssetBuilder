using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct LocomotorSetModuleData
{
    public UpgradeModuleData Base;
    public SageBool KillLocomotorUpgrade;
}
