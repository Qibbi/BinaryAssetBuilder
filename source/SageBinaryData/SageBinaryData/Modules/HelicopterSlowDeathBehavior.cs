using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HelicopterSlowDeathBehaviorModuleData
    {
        public SlowDeathBehaviorModuleData Base;
        public float SpiralOrbitTurnRate;
        public float SpiralOrbitForwardSpeed;
        public float SpiralOrbitForwardSpeedDamping;
        public float MinSelfSpin;
        public float MaxSelfSpin;
        public Time SelfSpinUpdateDelay;
        public float SelfSpinUpdateAmount;
        public float FallHowFast;
        public Time MinBladeFlyOffDelay;
        public Time MaxBladeFlyOffDelay;
        public AssetReference<FXParticleSystemTemplate> AttachParticleSystem;
        public AnsiString AttachParticleBone;
        public AnsiString BladeBone;
        public AssetReference<ObjectCreationList> OclEjectPilot;
        public AssetReference<FXList> FxBlade;
        public AssetReference<ObjectCreationList> OclBlade;
        public AssetReference<FXList> FxHitGround;
        public AssetReference<ObjectCreationList> OclHitGround;
        public AssetReference<FXList> FxFinalBlowUp;
        public AssetReference<ObjectCreationList> OclFinalBlowUp;
        public float DelayFromGroundToFinalDeath;
        public TypedAssetId<GameObject> FinalRubbleObject;
        public float MaxBraking;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> DeathSound;
        public unsafe Coord3D* AttachParticleLoc;
    }
}
