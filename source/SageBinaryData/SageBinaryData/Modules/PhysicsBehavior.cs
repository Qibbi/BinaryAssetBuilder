using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicsBehaviorModuleData
    {
        public UpdateModuleData Base;
        public float MaxXRotationVelocity;
        public float MaxYRotationVelocity;
        public float MaxZRotationVelocity;
        public float GravityMultiplier;
        public uint ShockStunnedTimeLow;
        public uint ShockStunnedTimeHigh;
        public uint ShockStandingTime;
        public float FirstHeight;
        public float SecondHeight;
        public Percentage FirstPercentIndent;
        public Percentage SecondPercentIndent;
        public int BounceCount;
        public float BounceDistance;
        public float BounceFirstHeight;
        public float BounceSecondHeight;
        public Percentage BounceFirstPercentIndent;
        public Percentage BounceSecondPercentIndent;
        public AssetReference<FXList> GroundHitFX;
        public AssetReference<FXList> GroundBounceFX;
        public Percentage FirstPercentHeight;
        public Percentage SecondPercentHeight;
        public float CurveFlattenMinDist;
        public SageBool TumbleRandomly;
        public SageBool AllowBouncing;
        public SageBool KillWhenRestingOnGround;
        public SageBool OrientToFlightPath;
        public SageBool IgnoreTerrainHeight;
    }
}
