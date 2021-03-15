using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AutoResolveInfo
    {
        public AnsiString AutoResolveUnitType;
        public TypedAssetId<BaseAssetType> AutoResolveBody; // should be TypedAssetId<ModuleData> but .net thinks it might be a circular reference
        public AssetReference<ArmorTemplate> AutoResolveArmor;
        public AssetReference<WeaponTemplate> AutoResolveWeapon;
        public AnsiString AutoResolveLeadership;
        public AnsiString AutoResolveCombatChain;
    }

    public enum BuildPlacementType
    {
        INVALID,
        MAIN_STRUCTURE,
        OTHER_STRUCTURE,
        TIBERIUM_FIELD
    }

    public enum BuildableStatus
    {
        YES,
        IGNORE_PREREQUISITES,
        NO,
        ONLY_BY_AI
    }

    public enum BuildCompletionType
    {
        INVALID,
        APPEARS_AT_RALLY_POINT,
        PLACED_BY_PLAYER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BuildPlacementTypeBitFlags
    {
        public const int Count = 0x00000004;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProjectedBuildabilityInfo
    {
        public float Radius;
        public BuildPlacementTypeBitFlags BuildPlacementTypes;
        public ObjectStatusBitFlags StatusToReject;
        public ModelConditionBitFlags ModelConditionsToReject;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ArmorTemplateSet
    {
        public AssetReference<ArmorTemplate> Armor;
        public AssetReference<DamageFX> DamageFX;
        public ArmorSetBitFlags Conditions;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LocomotorSet
    {
        public float Speed;
        public LocomotorSetType Condition;
        public AssetReference<LocomotorTemplate> Locomotor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Flammability
    {
        public uint Fuel;
        public uint MaxBurnRate;
        public uint Decay;
        public uint Resistance;
    }

    public enum SkirmishAIBaseLocation
    {
        FRONT,
        SIDE,
        BACK,
        SPREAD,
        CENTER,
        TIBERIUM,
        HOMEBASE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SkirmishAIInformation
    {
        public SkirmishAIBaseLocation BaseBuildingLocation;
        public unsafe float* ConquerMetricsOverrideDPS;
        public DamageType ConquerMetricsOverrideDamageType;
        public WeaponAntiBitFlags ConquerMetricsOverrideAntiMask;
        public SageBool UnitBuilderStandardCombatUnit;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PerUnitFX
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ReplaceModule
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InheritableModule
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AutoResolveArmor
    {
        public List<TypedAssetId<UpgradeTemplate>> RequiredUpgrade;
        public List<TypedAssetId<UpgradeTemplate>> ExcludedUpgrade;
        public AssetReference<ArmorTemplate> Armor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AutoResolveWeapon
    {
        public List<TypedAssetId<UpgradeTemplate>> RequiredUpgrade;
        public List<TypedAssetId<UpgradeTemplate>> ExcludedUpgrade;
        public AssetReference<WeaponTemplate> Weapon;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FormationPreviewDecal
    {
        public AnsiString Texture;
        public float Width;
        public float Height;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VisionInfo
    {
        public float VisionRange;
        public float ShroudClearingRange;
        public Percentage VisionSide;
        public Percentage VisionRear;
        public float VisionBonusTestRadius;
        public uint VisionBonusTestSegments;
        public Percentage VisionBonusPercentPerFoot;
        public Percentage MaxVisionBonusPercent;
        public Percentage MinVisionBonusPercent;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CrusherInfo
    {
        public int CrushKnockback;
        public float CrushZFactor;
        public Percentage MinCrushVelocityPercent;
        public Percentage CrushDecelerationPercent;
        public AssetReference<WeaponTemplate> CrushWeapon;
        public AssetReference<WeaponTemplate> CrushRevengeWeapon;
        public sbyte CrusherLevel;
        public sbyte CrushableLevel;
        public sbyte MountedCrusherLevel;
        public sbyte MountedCrushableLevel;
        public SageBool CrushEqualLevelProps;
        public SageBool UseCrushAttack;
        public SageBool CrushOnlyWhileCharging;
        public SageBool CrushAllies;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameObject
    {
        public BaseInheritableAsset Base;
        public KindOfBitFlags KindOf;
        public List<AnsiString> Browser;
        public AnsiString ReviveText;
        public AnsiString RecruitText;
        public AnsiString Description;
        public AnsiString TypeDescription;
        public AnsiString Hotkey;
        public RadarPriorityType RadarPriority;
        public BuildCompletionType BuildCompletion;
        public float FenceWidth;
        public float FenceXOffset;
        public float RemoveTerrainRadius;
        public float EmotionRange;
        public Angle PlacementViewAngle;
        public Time BuildFadeInOnCreateTimeSeconds;
        public float FactoryExitWidth;
        public float FactoryExtraBibWidth;
        public AnsiString Side;
        public AnsiString EditorName;
        public EditorSortingType EditorSorting;
        public int BountyValue;
        public float BuildTime;
        public float BuildFadeInOnCreateTime;
        public int EnergyProduction;
        public int EnergyBonus;
        public TypedAssetId<LogicCommandSet> CommandSet;
        public AnsiString SelectPortrait;
        public AnsiString ButtonImage;
        public int VoicePriority;
        public float MinZIncreaseForVoiceMoveToHigherGround;
        public AssetReference<CrowdResponse> CrowdResponse;
        public uint CampnessValue;
        public float CampnessValueRadius;
        public float Scale;
        public float HealthBoxScale;
        public float HealthBoxHeightOffset;
        public uint OcclusionDelay;
        public float LiveCameraPitch;
        public int FormationWidth;
        public int FormationDepth;
        public float InstanceScaleFuzziness;
        public float ThreatRadius;
        public int RamPower;
        public float RamZMult;
        public float ShockwaveResistance;
        public int CommandPoints;
        public int CommandPointBonus;
        public uint VoiceAttackChargeTimeout;
        public float MaxDistanceForEngaged;
        public uint EngagedStateTimeout;
        public float ThreatLevel;
        public uint SlopeLimitIndex;
        public float PathfindDiameter;
        public int SupplyOverride;
        public int DisplayMeleeDamage;
        public int DisplayRangedDamage;
        public int HeroSortOrder;
        public AnsiString ExperienceScalarTable;
        public float FiringArc;
        public float CamouflageDetectionMultiplier;
        public int SelectionPriority;
        public ProductionQueueType ProductionQueueType;
        public BuildPlacementType BuildPlacementTypeFlag;
        public KindOfBitFlags BuildOnRequiredObjectKindOf;
        public UnitCategory UnitCategory;
        public WeaponCategory WeaponCategory;
        public Time HasFiredRecentlyTime;
        public AssetReference<UnitTypeIcon> UnitTypeIcon;
        public Time ReinvisibilityDelay;
        public unsafe AnsiString* DisplayName;
        public unsafe GameDependencyType* GameDependency;
        public List<ArmorTemplateSet> ArmorSet;
        public List<WeaponTemplateSet> WeaponSet;
        public List<LocomotorSet> LocomotorSet;
        public unsafe BuildableStatus* Buildable;
        public unsafe ThingClassType* ThingClass;
        public unsafe DeadCollideSizeType* DeadCollideSize;
        public unsafe List<AnsiString>* BuildFadeInOnCreateList;
        public unsafe List<AnsiString>* BuildVariations;
        public unsafe List<TypedAssetId<BaseAssetType>> EquivalentTo; // should be TypedAssetId<GameObject> but .net thinks it might be a circular reference
        public unsafe Color* DisplayColor;
        public unsafe Flammability* Flammability;
        public unsafe SkirmishAIInformation* SkirmishAIInformation;
        public unsafe PolymorphicList<DrawModuleData>* Draws;
        public unsafe PolymorphicList<BehaviorModuleData>* Behaviors;
        public unsafe UpdateModuleData* AI;
        public unsafe BodyModuleData* Body;
        public unsafe PolymorphicList<ClientUpdateModuleData>* ClientUpdates;
        public unsafe PolymorphicList<ClientBehaviorModuleData>* ClientBehaviors;
        public unsafe PerUnitFX* UnitSpecificFX;
        public unsafe Geometry* Geometry;
        public unsafe ReplaceModule* ReplaceModule;
        public unsafe InheritableModule* InheritableModule;
        public unsafe AutoResolveArmor* AutoResolveArmor;
        public unsafe AutoResolveWeapon* AutoResolveWeapon;
        public unsafe List<AnsiString>* WorldMapArmoryUpgradesAllowed;
        public unsafe FormationPreviewDecal* FormationPreviewDecal;
        public unsafe FormationPreviewDecal* FormationPreviewItemDecal;
        public unsafe Coord3D* LiveCameraOffset;
        public unsafe AudioArrayVoice* AudioArrayVoice;
        public unsafe AudioArraySound* AudioArraySound;
        public unsafe GameObjectEvaEvents* EvaEvents;
        public List<AnsiString> UpgradeCameo;
        public unsafe ShadowInfo* ShadowInfo;
        public unsafe AutoResolveInfo* AutoResolveInfo;
        public unsafe VisionInfo* VisionInfo;
        public unsafe CrusherInfo* CrusherInfo;
        public unsafe ProjectedBuildabilityInfo* ProjectedBuildabilityInfo;
        public unsafe List<TypedAssetId<UpgradeTemplate>> DisplayUpgrade;
        public ushort BuildCost;
        public ushort RefundValue;
        public ushort ThreatValue;
        public ushort MaxSimultaneousOfType;
        public byte TransportSlotCount;
        public SageBool IsTrainable;
        public SageBool IsForbidden;
        public SageBool IsPrerequisite;
        public SageBool IsGrabbable;
        public SageBool IsHarvestable;
        public byte StructureRubbleHeight;
        public SageBool ForceLuaRegistration;
        public SageBool ShowHealthInSelectionDecal;
        public SageBool KeepSelectableWhenDead;
        public SageBool IsAutoBuilt;
        public SageBool CanPathThroughGates;
        public SageBool ShouldClearShotsOnIdle;
        public SageBool BuildInProximityToSamePlayerStucture;
    }
}
