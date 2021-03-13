using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum DispositionType
    {
        DISPOSITION_NONE,
        LIKE_EXISTING,
        ON_GROUND_ALIGNED,
        SEND_IT_FLYING,
        SEND_IT_UP,
        SEND_IT_OUT,
        RANDOM_FORCE,
        FLOATING,
        INHERIT_VELOCITY,
        FORWARD_IMPACT,
        REVERSE_IMPACT,
        BUILDING_CHUNKS,
        FADE_AND_DIE_ORNAMENT,
        ANIMATED,
        ABSOLUTE_ANGLE,
        SPAWN_AROUND,
        RELATIVE_ANGLE,
        USE_WATER_SURFACE,
        USE_CLIFF,
        CLAMP_TO_GROUND
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DispositionTypeFlag
    {
        public const int Count = 0x00000013;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum OCNuggetOption
    {
        OCCOMMONNUGGETOPTION_NONE,
        ORIENT_IN_FORCE_DIRECTION,
        ISSUE_MOVE_AFTER_CREATION,
        ORIENT_IN_PRIMARY_DIRECTION,
        ORIENT_IN_SECONDARY_DIRECTION,
        CLEAR_REMOVEABLES,
        MOVE_USES_STRAFE_UPDATE,
        MOVE_TARGET_USES_DISPOSITION_OFFSET,
        MOVE_USES_EVACUATE_AND_EXIT,
        OFFSET_IN_LOCAL_SPACE,
        SPREAD_FORMATION,
        FADE_IN,
        FADE_OUT,
        PRESERVE_LAYER,
        IGNORE_ALL_OBJECTS,
        IGNORE_ENEMY_UNITS,
        IGNORE_ALLY_UNITS,
        CONTAIN_INSIDE_SOURCE_OBJECT,
        SKIP_IF_SIGNIFICANTLY_AIRBORNE,
        REQUIRES_LIVE_PLAYER,
        IGNORE_COMMANDPOINT_LIMIT,
        INHERIT_ATTRIBUTES_FROM_SOURCE,
        INHERIT_SCRIPTING_NAME,
        INHERIT_PRICE_PURCHASED,
        OK_TO_CHANGE_MODEL_COLOR,
        DONT_SET_PRODUCER,
        SCALE_TIBERIUM_FIELD,
        SCALE_ION_STORM,
        DO_NOT_TREAT_AS_STRUCTURE,
        USE_CREATORS_HEALTH_AS_BASE,
        USE_CREATORS_HEALTH_PERCENTAGE,
        COPY_CREATORS_UPGRADES,
        MOVE_TARGET_USES_OFFSET,
        TRANSFER_TEMPORARY_SLAVE,
        COPY_PRODUCTION_QUEUE_INDEX
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OCNuggetOptionFlag
    {
        public const int Count = 0x00000022;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OCNugget : IPolymorphic
    {
        public uint TypeId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CreateObjectNugget
    {
        public OCNugget Base;
        public TypedAssetId<GameObject> PutInContainer;
        public AssetReference<FXParticleSystem> ParticleSystem;
        public AssetReference<FXList> CreateFX;
        public uint Count;
        public OCNuggetOptionFlag Options;
        public DispositionTypeFlag Disposition;
        public float VelocityScale;
        public float MinForceMagnitude;
        public float MaxForceMagnitude;
        public Time MinLifetime;
        public Time MaxLifetime;
        public float MinDistanceAFormation;
        public float MinDistanceBFormation;
        public float MaxDistanceFormation;
        public Time FadeTime;
        public ModelConditionBitFlags StartingModelConditions;
        public ModelConditionFlagType TempModelCondition;
        public Time TempModelConditionTime;
        public Velocity DispositionIntensity;
        public unsafe AnsiString* DestinationPlayer;
        public AnsiString WaypointSpawn;
        public Angle DispositionAngle;
        public Angle MinForcePitch;
        public Angle MaxForcePitch;
        public Angle MinForceYaw;
        public Angle MaxForceYaw;
        public Angle OrientationOffset;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> FadeSound;
        public Percentage MinHordeDensity;
        public Percentage MaxHordeDensity;
        public float MinHealth;
        public float MaxHealth;
        public Time InvulnerableTime;
        public Time StartingBusyTime;
        public Time JustBuiltFrames;
        public int VeterancyLevel;
        public unsafe Coord3D* Offset;
        public List<AssetReference<UpgradeTemplate>> RequiredUpgrade;
        public List<AssetReference<UpgradeTemplate>> ForbiddenUpgrade;
        public List<TypedAssetId<GameObject>> CreateObject;
        public SageBool UseUpgradedLocomotor;
        public SageBool DisabledWhileBusy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FireWeaponNugget
    {
        public OCNugget Base;
        public AssetReference<WeaponTemplate> Weapon;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AttackNugget
    {
        public OCNugget Base;
        public uint NumberOfShots;
        public WeaponSlotType WeaponSlot;
        public float DeliveryDecalRadius;
        public unsafe RadiusDecalTemplate* DeliveryDecal;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ObjectCreationList
    {
        public BaseAssetType Base;
        public List<CreateObjectNugget> CreateObject;
        public List<AttackNugget> Attack;
        public List<FireWeaponNugget> FireWeapon;
    }
}
