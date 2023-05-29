using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SupplyCenterDockUpdateModuleData
{
    public DockUpdateModuleData Base;
    public float ValueMultiplier;
    public ScienceType BonusScience;
    public float BonusScienceMultiplier;
    public SageBool DistributedDeposit;
}
