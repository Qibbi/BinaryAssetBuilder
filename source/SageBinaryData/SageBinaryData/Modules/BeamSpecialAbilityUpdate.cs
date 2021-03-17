using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BeamSpecialAbilityUpdateModuleData
    {
        public SpecialAbilityUpdateModuleData Base;
        public float DamagePerSecond;
        public AssetReference<AttributeModifier> TargetAttributeModifierAdd;
        public AssetReference<FXList> SweepFX;
        public float ReflectorExtendDistance;
        public AnsiString PreferredTargetBone;
        public SageBool JoinWithOtherBeams;
        public SageBool DissapateWhenTargetDead;
        public SageBool LineType;
        public SageBool TargetSamePlayerOnly;
    }
}
