using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CloneStoredObjectsSpecialPowerUpdateModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public float MinDestinationRadius;
    public float MaxDestinationRadius;
    public AssetReference<AttributeModifier> TriggerAttributeModifierOnClones;
    public AssetReference<FXList> TriggerFX;
    public AssetReference<FXList> TargetFX;
    public Time ClonedObjectLifetime;
}
