using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HitReactionBehaviorModuleData
    {
        public UpdateModuleData Base;
        public uint LightDamageHitReactionLifeTimer;
        public uint MediumDamageHitReactionLifeTimer;
        public uint HeavyDamageHitReactionLifeTimer;
        public float LightDamageHitReactionThreshold;
        public float MediumDamageHitReactionThreshold;
        public float HeavyDamageHitReactionThreshold;
        public SageBool FastHitsResetReaction;
        public SageBool HitsParalyze;
    }
}
