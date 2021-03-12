using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RangeReal
    {
        public float Min;
        public float Max;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RangeDuration
    {
        public Time MinSeconds;
        public Time MaxSeconds;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LinearTargetType
    {
        public float Time;
        public unsafe Coord2D* Position;
    }

    public enum PartitionManagerDistTestType
    {
        SPHERE,
        EXTENTS_3D,
        CIRCLE
    }

    public enum WeaponFlagsType
    {
        NONE,
        EMPTY_CLIP_ON_ACTIVATE,
        ORTHOGONAL_SCATTER,
        LENGTH_SCATTER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponFlagsBitFlags
    {
        public const int Count = 4;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum WeaponReloadType
    {
        AUTO,
        NONE,
        RETURN_TO_BASE
    }

    public enum WeaponPrefireType
    {
        PER_SHOT,
        PER_CLIP,
        PER_BURST,
        PER_TARGET,
        PER_POSITION
    }

    public enum WeaponReAcquireDetailType
    {
        PRE_SHOT,
        PER_SHOT,
        PER_CLIP,
        PER_ATTACK,
        PRE_FIRE,
        POST_FIRE
    }

    public enum WeaponCollideType
    {
        ALLIES,
        ENEMIES,
        NEUTRAL,
        STRUCTURES,
        SHRUBBERY,
        PROJECTILES,
        WALLS,
        SMALL_MISSILES,
        BALLISTIC_MISSILES,
        CONTROLLED_STRUCTURES,
        MONSTERS
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponCollideBitFlags
    {
        public const int Count = 11;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum WeaponAffectsType
    {
        SELF,
        ALLIES,
        ENEMIES,
        NEUTRALS,
        SUICIDE,
        NOT_SIMILAR,
        NOT_AIRBORNE,
        PROJECTILES,
        SAME_HEIGHT_ONLY,
        MINES
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponAffectsBitFlags
    {
        public const int Count = 10;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum WpnAntiT
    {
        ANTI_AIRBORNE_VEHICLE,
        ANTI_GROUND,
        ANTI_PROJECTILE,
        ANTI_SMALL_MISSILE,
        ANTI_MINE,
        ANTI_AIRBORNE_INFANTRY,
        ANTI_BALLISTIC_MISSILE,
        ANTI_PARACHUTE,
        ANTI_STRUCTURE,
        ANTI_AIRBORNE_MONSTER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponAntiBitFlags
    {
        public const int Count = 10;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum FireEffectType
    {
        INCREASE_BURN_RATE,
        DECREASE_BURN_RATE,
        INCREASE_FUEL,
        INCREASE_BURN_RATE_ON_EXISTING_FIRE,
        INCREASE_FUEL_ON_EXISTING_FIRE
    }

    public enum ParalyzeEffectType
    {
        EMP,
        USER_PARALYZE,
        NONE
    }

    public enum InfoWarEffect
    {
        NONE,
        RADAR_JAM,
        RESET_RADAR_JAM,
        RESET_RADAR_SPIES,
        RESET_RADAR_HACKS,
        RESET_RADAR_FREEZE,
        RESET_RADAR_ALL
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InfoWarEffectBitFlags
    {
        public const int Count = 7;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponEffectNugget : IPolymophic
    {
        public uint TypeId;
        public PartitionManagerDistTestType PartitionFilterTestType;
        public ObjectStatusBitFlags ForbiddenTargetObjectStatus;
        public ModelConditionBitFlags ForbiddenTargetModelCondition;
        public unsafe ObjectFilter* SpecialObjectFilter;
        public List<TypedAssetId<UpgradeTemplate>> RequiredUpgrade;
        public List<TypedAssetId<UpgradeTemplate>> ForbiddenUpgrade;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ScalarInfo
    {
        public Percentage Scalar;
        public ObjectFilter Filter;
        public List<TypedAssetId<UpgradeTemplate>> RequiredUpgrade;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ParalyzeNuggetType
    {
        public WeaponEffectNugget Base;
        public float Radius;
        public Angle EffectArc;
        public Time DurationSeconds;
        public ParalyzeEffectType ParalyzeType;
        public ParalyzeEffectType RemoveParalyzeType;
        public AssetReference<FXList> ParalyzeFX;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InformationWarfareNuggetType
    {
        public WeaponEffectNugget Base;
        public InfoWarEffectBitFlags InfoWarType;
        public float RadarJamRadius;
        public Time RadarJamDuration;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpendStolenTiberiumNuggetType
    {
        public WeaponEffectNugget Base;
        public int AmountToSpend;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ReportWeaponFiredStatNuggetType
    {
        public WeaponEffectNugget Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DamageNuggetType
    {
        public WeaponEffectNugget Base;
        public float Damage;
        public float DamageTaperOff;
        public float Radius;
        public float MinRadius;
        public Angle DamageArc;
        public float DamageMaxHeight;
        public float DamageMaxHeightAboveTerrain;
        public float FlankingBonus;
        public float FlankedScalar;
        public Time DelayTimeSeconds;
        public DamageType DamageType;
        public DeathType DeathType;
        public DamageFXType DamageFXType;
        public DamageSubType DamageSubType;
        public float DrainLifeMultiplier;
        public float DamageSpeed;
        public unsafe AnsiString* UnderAttackOverrideEvaEvent;
        public AssetReference<GameObject> VictimShroudRevealer;
        public List<ScalarInfo> DamageScalarDetails;
        public SageBool DamageArcInverted;
        public SageBool AcceptDamageAdd;
        public SageBool OnlyKillOwnerWhenTriggered;
        public SageBool DrainLife;
        public SageBool CylinderAOE;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DamageAndSpawnNuggetType
    {
        public DamageNuggetType Base;
        public float SpawnProbability;
        public ModelConditionBitFlags SpawnedModelConditionFlags;
        public TypedAssetId<GameObject> SpawnTemplate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FireLogicNuggetType
    {
        public DamageNuggetType Base;
        public FireEffectType FireEffect;
        public uint MinMaxBurnRate;
        public uint MinDecay;
        public uint MaxResistance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FireOnObjectsNuggetType
    {
        public DamageNuggetType Base;
        public AssetReference<WeaponTemplate> Weapon;
        public unsafe ObjectFilter* Filter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TintObjectsNuggetType
    {
        public DamageNuggetType Base;
        public Time PreColorTime;
        public Time PostColorTime;
        public Time SustainedColorTime;
        public float Frequency;
        public float Amplitude;
        public RGBColor Color;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DamageFieldNuggetType
    {
        public WeaponEffectNugget Base;
        public AssetReference<WeaponTemplate> WeaponTemplate;
        public Time DurationSeconds;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VeteranProjectile
    {
        public VeterancyLevel VeterancyLevel;
        public AssetReference<GameObject> ProjectileTemplate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProjectileNuggetType
    {
        public WeaponEffectNugget Base;
        public AssetReference<WeaponTemplate> WarheadTemplate;
        public AssetReference<GameObject> ProjectileTemplate;
        public WeaponSlotType WeaponLaunchBoneSlotOverride;
        public unsafe Coord3D* AttackOffset;
        public List<VeteranProjectile> VeterancyProjectiles;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SuppressionNuggetType
    {
        public WeaponEffectNugget Base;
        public float Radius;
        public float Suppression;
        public Time DurationSeconds;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponOCLNuggetType
    {
        public WeaponEffectNugget Base;
        public AssetReference<ObjectCreationList> WeaponOCL;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ActivateLaserNuggetType
    {
        public WeaponEffectNugget Base;
        public Time Lifetime;
        public int LaserId;
        public AssetReference<FXList> HitGroundFX;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ActivateStreamNuggetType
    {
        public WeaponEffectNugget Base;
        public Time Lifetime;
        public int StreamId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ActivateLinearDamageNuggetType
    {
        public WeaponEffectNugget Base;
        public Time Lifetime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SlavesAttackNuggetType
    {
        public WeaponEffectNugget Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MetaImpactNuggetType
    {
        public WeaponEffectNugget Base;
        public float ShockWaveAmount;
        public float ShockWaveRadius;
        public Angle ShockWaveArc;
        public float ShockWaveTaperOff;
        public float ShockWaveSpeed;
        public float ShockWaveZMult;
        public float CyclonicFactor;
        public Time ShockwaveDelaySeconds;
        public float Suppression;
        public float HeroResist;
        public float ShockWaveClearWaveMult;
        public float ShockWaveClearFlingHeight;
        public unsafe ObjectFilter* KillObjectFilter;
        public SageBool ShockWaveArcInverted;
        public SageBool InvertShockWave;
        public SageBool FlipDirection;
        public SageBool OnlyWhenJustDied;
        public SageBool ShockWaveClearRadius;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpecialPowerNuggetType
    {
        public WeaponEffectNugget Base;
        public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AttributeModifierNuggetType
    {
        public WeaponEffectNugget Base;
        public AssetReference<AttributeModifier> AttributeModifierName;
        public AssetReference<AttributeModifier> AttributeModifierOwnerName;
        public DamageFXType DamageFXType;
        public float Radius;
        public Angle DamageArc;
        public AttributeModifierCategoryBitFlags AntiCategories;
        public AssetReference<FXList> AntiFX;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DamageContainedNuggetType
    {
        public DamageNuggetType Base;
        public int MaxUnitsToDamage;
        public AssetReference<FXList> WindowBlastFX;
        public ObjectFilter DamageObjectFilter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LuaEventNuggetType
    {
        public WeaponEffectNugget Base;
        public AnsiString EventName;
        public float Radius;
        public SageBool SendToEnemies;
        public SageBool SendToAllies;
        public SageBool SendToNeutral;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LineDamageNuggetType
    {
        public DamageNuggetType Base;
        public Angle OffsetAngle;
        public float LineWidth;
        public float LineLengthLeadIn;
        public float LineLengthLeadOut;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SeedTiberiumNuggetType
    {
        public WeaponOCLNuggetType Base;
        public float FieldAmount;
        public float SpawnedInFieldBonus;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ScatterProjectileNuggetType
    {
        public WeaponEffectNugget Base;
        public float ScatterMin;
        public float ScatterMax;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ScatterRadiusType
    {
        public float Radius;
        public ObjectFilter Filter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ContainedObjectAttackNuggetType
    {
        public WeaponEffectNugget Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponTemplate
    {
        public BaseInheritableAsset Base;
        public AnsiString Name;
        public float AttackRange;
        public float MinimumAttackRange;
        public float RangeBonusMinHeight;
        public float RangeBonus;
        public float RangeBonusPerFoot;
        public float RequestAssistRange;
        public Angle AcceptableAimDelta;
        public Angle AimDirection;
        public float ScatterRadius;
        public float ScatterLength;
        public float ScatterTargetScalar;
        public float WeaponSpeed;
        public float MinWeaponSpeed;
        public float MaxWeaponSpeed;
        public Time IdleAfterFiringDelaySeconds;
        public Time HoldAfterFiringDelaySeconds;
        public Angle WeaponRecoil;
        public Angle MinTargetPitch;
        public Angle MaxTargetPitch;
        public AnsiString PreferredTargetBone;
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* FireSound;
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* FireSoundPerClip;
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* FiringLoopSound;
        public AssetReference<FXList> FireFX;
        public AssetReference<FXList> FireVeteranFX;
        public AssetReference<FXList> FireFlankFX;
        public AssetReference<FXList> PreAttackFX;
        public int ClipSize;
        public int ContinuousFireOne;
        public int ContinuousFireTwo;
        public Time ContinuousFireCoastSeconds;
        public Time AutoReloadWhenIdleSeconds;
        public int ShotsPerBarrel;
        public ObjectStatusBitFlags RequiredFiringObjectStatus;
        public ObjectStatusBitFlags ForbiddenFiringObjectStatus;
        public float ContinueAttackRange;
        public Time SuspendFXDelaySeconds;
        public Percentage HitPercentage;
        public Percentage HitPassengerPercentage;
        public float HealthProportionalResolution;
        public int MaxAttackPassengers;
        public float RestrictedHeightRange;
        public WeaponFlagsBitFlags Flags;
        public WeaponPrefireType PreAttackType;
        public WeaponReAcquireDetailType ReAcquireDetailType;
        public WeaponReloadType AutoReloadsClip;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> SingleAmmoReloadedNotFullSound;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> ClipReloadedSound;
        public WeaponAffectsBitFlags RadiusDamageAffects;
        public AnsiString FXTrigger;
        public WeaponCollideBitFlags ProjectileCollidesWith;
        public WeaponAntiBitFlags AntiMask;
        public TypedAssetId<GameObject> ProjectileStreamName;
        public unsafe SoundOrEvaEvent* OverrideVoiceAttackSound;
        public unsafe SoundOrEvaEvent* OverrideVoiceEnterStateAttackSound;
        public unsafe RangeDuration* PreAttackDelay;
        public unsafe RangeDuration* FiringDuration;
        public unsafe RangeDuration* CoolDownDelayBetweenShots;
        public unsafe RangeDuration* ClipReloadTime;
        public unsafe Coord2D* ScatterTarget;
        public unsafe LinearTargetType* LinearTarget;
        public PolymorphicList<WeaponEffectNugget> Nuggets;
        public unsafe ObjectFilter* SurpriseAttackObjectFilter;
        public unsafe ObjectFilter* CombinedAttackObjectFilter;
        public unsafe ObjectFilter* HitStoredObjectFilter;
        public List<ScatterRadiusType> ScatterRadiusVsType;
        public SageBool ScatterIndependently;
        public SageBool DisableScatterForTargetsOnWall;
        public SageBool ScaleWeaponSpeed;
        public SageBool CanBeDodged;
        public SageBool HoldDuringReload;
        public SageBool CanFireWhileMoving;
        public SageBool CanFireWhileCharging;
        public SageBool FiringLoopSoundContinuesDuringReload;
        public SageBool DamageDealtAtSelfPosition;
        public SageBool CheckStatusFlagsInRangeChecks;
        public SageBool ProjectileSelf;
        public SageBool MeleeWeapon;
        public SageBool ChaseWeapon;
        public SageBool LeechRangeWeapon;
        public SageBool HitStoredTarget;
        public SageBool CapableOfFollowingWaypoints;
        public SageBool ShowAmmoPips;
        public SageBool AllowAttackGarrisonedBldgs;
        public SageBool PlayFXWhenStealthed;
        public SageBool IgnoreLinearFirstTarget;
        public SageBool ForceDisplayPercentReady;
        public SageBool IsAimingWeapon;
        public SageBool NoVictimNeeded;
        public SageBool RotatingTurret;
        public SageBool PassengerProportionalAttack;
        public SageBool FinishAttackOnceStarted;
        public SageBool CannotTargetCastleVictims;
        public SageBool RequireFollowThru;
        public SageBool ShareTimers;
        public SageBool ShouldPlayUnderAttackEvaEvent;
        public SageBool InstantLoadClipOnActivate;
        public SageBool LockWhenUsing;
        public SageBool BombardType;
        public SageBool UseInnateAttributes;
        public SageBool StopFiringOnCanBeInvisible;
        public SageBool ContactWeapon;
    }
}
