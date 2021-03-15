using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DamageCreationList
    {
        public AssetReference<ObjectCreationList> ObjectCreationList;
        public FXTriggerType TriggerFX;
        public BodySideDestroyedType DestroyedSide;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ActiveBodyModuleData
    {
        public BodyModuleData Base;
        public float MaxHealth;
        public float MaxHealthDamaged;
        public float MaxHealthReallyDamaged;
        public float InitialHealth;
        public float RecoveryTime;
        public float DodgePercent;
        public Time EnteringDamagedTransitionTime;
        public Time EnteringReallyDamagedTransitionTime;
        public AnsiString GrabObject;
        public AssetReference<FXList> GrabFX;
        public float GrabDamage;
        public AssetReference<FXList> HealingBuffFX;
        public AssetReference<AttributeModifier> DamagedAttributeModifier;
        public AssetReference<AttributeModifier> ReallyDamagedAttributeModifier;
        public float CheerRadius;
        public AssetReference<FXList> BurningDeathFX;
        public unsafe Coord2D* GrabOffset;
        public List<DamageCreationList> DamageCreation;
        public SageBool UseDefaultDamageSettings;
        public SageBool RemoveUpgradesOnDeath;
        public SageBool BurningDeathBehavior;
    }
}
