using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MissileUpdateModuleData
    {
        public BezierProjectileBehaviorModuleData Base;
        public Time FuelLifetime;
        public Time IgnitionDelay;
        public float DistanceToTravelBeforeTurning;
        public float DistanceToTargetBeforeDiving;
        public AssetReference<FXList> IgnitionFX;
        public AssetReference<FXParticleSystemTemplate> ExhaustTemplate;
        public SageBool DetonateOnNoFuel;
    }
}
