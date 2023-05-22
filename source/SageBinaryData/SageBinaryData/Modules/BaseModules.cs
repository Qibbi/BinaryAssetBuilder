using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct AnimAndDuration
{
    public ModelConditionFlagType AnimState;
    public uint Frames;
    public uint Trigger;
}

public enum ParseCondStateType
{
    PARSE_NORMAL,
    PARSE_DEFAULT,
    PARSE_TRANSITION
}

[StructLayout(LayoutKind.Sequential)]
public struct ModuleData : IPolymorphic
{
    public uint TypeId;
#pragma warning disable IDE1006 // Naming Styles
    public TypedAssetId<BaseAssetType> id; // should be TypedAssetId<ModuleData> but .net thinks it might be a circular reference
#pragma warning restore IDE1006 // Naming Styles
}

[StructLayout(LayoutKind.Sequential)]
public struct ClientBehaviorModuleData : IPolymorphic
{
    public ModuleData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct DrawModuleData : IPolymorphic
{
    public ModuleData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct BehaviorModuleData : IPolymorphic
{
    public ModuleData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct ContainModuleData : IPolymorphic
{
    public BehaviorModuleData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct ClientUpdateModuleData : IPolymorphic
{
    public BehaviorModuleData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct UpdateModuleData : IPolymorphic
{
    public ContainModuleData Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct ModelConditionStateTurret
{
    public AnsiString TurretNameKey;
    public Angle TurretArtAngle;
    public AnsiString TurretPitch;
    public Angle TurretArtPitch;
    public int TurretID;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXEvent
{
    public int Frame;
    public int FrameStep;
    public int FrameStop;
    public AssetReference<FXList> Effect;
    public AnsiString Bone;
    public SageBool FireWhenSkipped;
}

[StructLayout(LayoutKind.Sequential)]
public struct LuaEvent
{
    public int Frame;
    public AnsiString Data;
    public unsafe ModelConditionStateTurret* Turret;
    public SageBool OnStateEnter;
    public SageBool OnStateLeave;
}

[StructLayout(LayoutKind.Sequential)]
public struct ParticleSysBone
{
    public AnsiString BoneName;
    public AssetReference<FXParticleSystemTemplate> FXParticleSystemTemplate;
    public AnsiString FXTrigger;
    public AnsiString Persist;
    public int PersistID;
#pragma warning disable IDE1006 // Naming Styles
    public AnsiString id;
#pragma warning restore IDE1006 // Naming Styles
    public SageBool FollowBone;
    public SageBool OnlyIfOnWater;
    public SageBool OnlyIfOnLand;
}

[StructLayout(LayoutKind.Sequential)]
public struct ScriptedModelDrawModel
{
    public AssetReference<BaseRenderAssetType> Name;
    public SageBool ExtraMesh;
}

[StructLayout(LayoutKind.Sequential)]
public struct BoneAttachPoint
{
    public int WeaponSlotID;
    public WeaponSlotType WeaponSlotType;
    public AnsiString BoneName;
}

[StructLayout(LayoutKind.Sequential)]
public struct ModelConditionState
{
    public ParseCondStateType ParseCondStateType;
    public AnsiString Name;
    public AnsiString ConditionsYes;
    public AnsiString Skeleton;
    public AnsiString ModelAnimationPrefix;
    public AssetReference<PackedTextureImage> PortraitImage;
    public AssetReference<PackedTextureImage> ButtonImage;
    public AnsiString OverrideTooltip;
#pragma warning disable IDE1006 // Naming Styles
    public AnsiString id;
#pragma warning restore IDE1006 // Naming Styles
    public List<ScriptedModelDrawModel> Model;
    public List<ReplaceTexture> Texture;
    public List<BoneAttachPoint> WeaponFireFXBone;
    public List<BoneAttachPoint> WeaponRecoilBone;
    public List<BoneAttachPoint> WeaponMuzzleFlash;
    public List<BoneAttachPoint> WeaponLaunchBone;
    public List<ParticleSysBone> ParticleSysBone;
    public List<FXEvent> FXEvent;
    public unsafe ShadowInfo* ShadowInfo;
    public List<ModelConditionStateTurret> Turret;
    public SageBool RetainSubObjects;
}

[StructLayout(LayoutKind.Sequential)]
public struct AttachModelStruct
{
    public AnsiString Object;
    public int Probability;
}

[StructLayout(LayoutKind.Sequential)]
public struct ScriptedModelDrawAttachModel
{
    public ModelConditionBitFlags FlagMask;
    public AnsiString Bone;
    public AttachModelStruct Model;
    public Coord3D Offset;
}

[StructLayout(LayoutKind.Sequential)]
public struct ScriptedModelDrawEmbedPortal
{
    public WaypointPortalType PortalType;
    public AnsiString BonePrefix;
}

public enum FXActionType
{
    NONE,
    HOLD,
    KILL,
    SPAWN
}

public enum FXTriggerType
{
    NONE,
    CATAPULT_ROCK,
    TREBUCHET_ROCK
}

public enum BodyDamageType
{
    PRISTINE,
    DAMAGED,
    REALLY_DAMAGED,
    RUBBLE
}

public enum MaxHealthChangeType
{
    SAME_CURRENTHEALTH,
    PRESERVE_RATIO,
    ADD_CURRENT_HEALTH_TOO,
#if KANESWRATH
    RESTORE_HEALTH_TO_MAX
#endif
}

public enum BodySideDestroyedType
{
    NONE,
    FRONT_DESTROYED,
    RIGHT_DESTROYED,
    BACK_DESTROYED,
    LEFT_DESTROYED
}

[StructLayout(LayoutKind.Sequential)]
public struct WeatherTexture
{
    public WeatherType Weather;
    public AssetReference<Texture> Texture;
}

[StructLayout(LayoutKind.Sequential)]
public struct InvisibilityNuggetType
{
    public ModelConditionBitFlags ForbiddenConditions;
    public ModelConditionBitFlags ForbiddenConditionExceptions;
    public WeaponSetBitFlags ForbiddenWeaponSets;
    public ObjectStatusBitFlags ForbiddenStatus;
    public uint CamouflageLevel;
    public InvisibilityType InvisibilityType;
    public InvisibilityNuggetOptionsBitFlags Options;
    public AssetReference<FXList> EnteringStealthFX;
    public AssetReference<FXList> LeavingStealthFX;
    public ObjectStatusBitFlags HintDetectableStates;
    public Time NoStealthForAttackWindow;
    public List<TypedAssetId<UpgradeTemplate>> IgnoreTreeCheckUpgrade;
}

[StructLayout(LayoutKind.Sequential)]
public struct DieMuxDataType
{
    public List<AnsiString> VeterancyLevels;
    public ObjectStatusBitFlags ExemptStatus;
    public ObjectStatusBitFlags RequiredStatus;
    public float DamageAmountRequired;
    public Angle MinKillerAngle;
    public Angle MaxKillerAngle;
    public DeathBitFlags DeathTypes;
    public DeathBitFlags DeathTypesForbidden;
}

[StructLayout(LayoutKind.Sequential)]
public struct ObjectStatusValidationDataType
{
    public ObjectStatusBitFlags ForbiddenStatus;
    public ObjectStatusBitFlags RequiredStatus;
}
