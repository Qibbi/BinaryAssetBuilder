using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RestrictSpecialPowerBehaviorModuleData
{
    public BehaviorModuleData Base;
    public SpecialPowerRestrictionType RestrictionType;
    public TypedAssetId<GameObject> DependentObject;
    public List<float> DependentObjectRadius;
    public SageBool ConsiderSpecialPowerRadius;
}
