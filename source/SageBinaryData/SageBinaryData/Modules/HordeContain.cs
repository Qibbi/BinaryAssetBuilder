using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum FormationType
    {
        MAIN
    }

    public enum HordeMeleeType
    {
        AMOEBA
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HordeMeleeBehaviorData
    {
        public HordeMeleeType Type;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PositionAndLeaderType
    {
        public float X;
        public float Y;
        public int LeaderRank;
        public int LeaderIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RankInfoType
    {
        public int RankID;
        public TypedAssetId<GameObject> UnitType;
        public List<PositionAndLeaderType> Position;
        public unsafe WeaponSetBitFlags* WeaponConditionSet;
        public unsafe WeaponSetBitFlags* WeaponConditionClear;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BannerCarrierPosType
    {
        public TypedAssetId<GameObject> UnitType;
        public Coord2D Pos;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HordeContainModuleData
    {
        public TransportContainModuleData Base;
        public FormationType Formation;
        public TypedAssetId<GameObject> AlternateFormation;
        public LocomotorSetType ForcedLocomotorSet;
        public float MeleeAttackLeashDistance;
        public float GeometryFrontAngleRadians;
        public AnsiString EvaEventLastMemberDeath;
        public float FrontAngle;
        public float FlankedDelaySeconds;
        public float FlankedDurationSeconds;
        public uint MinimumHordeSize;
        public Time BackupMinDelayTime;
        public Time BackupMaxDelayTime;
        public float BackupMinDistance;
        public float BackupMaxDistance;
        public float BackupPercentage;
        public float RadiusCowerOverride;
        public float VisionOverrideRear;
        public float VisionOverrideSide;
        public ObjectStatusBitFlags ForbiddenCoverStatus;
        public unsafe HordeMeleeBehaviorData* MeleeBehavior;
        public unsafe Coord2D* RandomOffset;
        public List<RankInfoType> RankInfo;
        public List<int> RankThatStopsAdvance;
        public List<int> RankToReleaseWhenAttacking;
        public unsafe Coord2D* LeaderPosition;
        public List<BannerCarrierPosType> BannerCarrierPosition;
        public List<TypedAssetId<GameObject>> BannerCarriersAllowed;
        public List<TypedAssetId<GameObject>> LeadersAllowed;
        public List<AssetReference<AttributeModifier>> AttributeModifier;
        public SageBool UseSlowHordeMovement;
        public SageBool SpawnBannerCarrierImmediately;
        public SageBool BannerCarrierByUpgradeOnly;
    }
}
