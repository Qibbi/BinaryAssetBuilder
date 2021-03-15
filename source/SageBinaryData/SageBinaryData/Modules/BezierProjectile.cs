using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BezierProjectileBehaviorModuleData
    {
        public UpdateModuleData Base;
        public float FirstHeight;
        public float SecondHeight;
        public float FirstHeightMin;
        public float FirstHeightMax;
        public float SecondHeightMin;
        public float SecondHeightMax;
        public Percentage FirstPercentIndent;
        public Percentage SecondPercentIndent;
        public Time FinalStuckTime;
        public Time PreLandingStateTime;
        public int BounceCount;
        public float BounceDistance;
        public float BounceFirstHeight;
        public float BounceSecondHeight;
        public Percentage BounceFirstPercentIndent;
        public Percentage BounceSecondPercentIndent;
        public KindOfBitFlags GarrisonHitKillRequiredKindOf;
        public KindOfBitFlags GarrisonHitKillForbiddenKindOf;
        public uint GarrisonHitKillCount;
        public AssetReference<FXList> GarrisonHitKillFX;
        public AssetReference<FXList> GroundHitFX;
        public AssetReference<FXList> MaxDistanceReachedFX;
        public AssetReference<FXList> GroundBounceFX;
        public AssetReference<WeaponTemplate> GroundHitWeapon;
        public AssetReference<WeaponTemplate> GroundBounceWeapon;
        public Velocity FlightPathAdjustDistPerSecond;
        public Percentage FirstPercentHeight;
        public Percentage SecondPercentHeight;
        public float CurveFlattenMinDist;
        public EmotionType PreLandingEmotion;
        public float PreLandingEmotionRadius;
        public Time InvisibleTime;
        public Time FadeInTime;
        public Time PostLandingStateTime;
        public EmotionType PostLandingEmotion;
        public float PostLandingEmotionRadius;
        public float SidewaysDrift;
        public float MaxDistanceToTravel;
        public SageBool TumbleRandomly;
        public SageBool DetonateCallsKill;
        public SageBool OrientToFlightPath;
        public SageBool CrushStyle;
        public SageBool DieOnImpact;
        public SageBool FlightPathAdjustStraightOnly;
        public SageBool IgnoreTerrainHeight;
        public SageBool PingPongSidewaysDrift;
    }
}
