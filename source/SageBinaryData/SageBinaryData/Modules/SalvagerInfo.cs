#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SalvagerInfoModuleData
{
    public BehaviorModuleData Base;
    public float SalvageRadius;
    public Percentage PercentageOfBountyRecycled;
    public SageBool UseBountyNotUnitCost;
}
#endif
