using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FXNugget : IPolymorphic
{
    public uint TypeId;
    public ModelConditionBitFlags RequiredSecondaryModelConditions;
    public ModelConditionBitFlags ExcludedSecondaryModelConditions;
    public ModelConditionBitFlags RequiredSourceModelConditions;
    public ModelConditionBitFlags ExcludedSourceModelConditions;
    public WeatherType Weather;
    public unsafe ObjectFilter* SecondaryObjectFilter;
    public unsafe ObjectFilter* SourceObjectFilter;
    public List<DisabledType> SourceMustNotHaveBeenDisabledThisFrameByType;
    public SageBool StopIfPlayed;
    public SageBool OnlyIfOnLand;
    public SageBool PlayIfSourceIsStealthed;
}

[StructLayout(LayoutKind.Sequential)]
public struct EvaEventFXNugget
{
    public FXNugget Base;
    public AnsiString EvaEventOwner;
    public AnsiString EvaEventAlly;
    public AnsiString EvaEventEnemy;
}

[StructLayout(LayoutKind.Sequential)]
public struct SoundFXNugget
{
    public FXNugget Base;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> Value;
}

[StructLayout(LayoutKind.Sequential)]
public struct RayEffectFXNugget
{
    public FXNugget Base;
    public TypedAssetId<GameObject> Thing;
    public Coord3D PrimaryOffset;
    public Coord3D SecondaryOffset;
}

[StructLayout(LayoutKind.Sequential)]
public struct LightPulseFXNugget
{
    public FXNugget Base;
    public float Radius;
    public Percentage RadiusAsPercentOfObjectSize;
    public uint IncreaseTime;
    public uint DecreaseTime;
    public RGBColor Color;
}

public enum DynamicDecalShaderType
{
    ALPHA,
    ADDITIVE
}

[StructLayout(LayoutKind.Sequential)]
public struct DynamicDecalFXNugget
{
    public FXNugget Base;
    public AnsiString Decal;
    public DynamicDecalShaderType Shader;
    public float Size;
    public float OpacityStart;
    public float OpacityPeak;
    public float OpacityEnd;
    public Time OpacityFadeTimeOne;
    public Time OpacityFadeTimeTwo;
    public Time OpacityPeakTime;
    public Time StartingDelay;
    public Time Lifetime;
    public Color Color;
    public Coord2D Offset;
    public SageBool OrientToObject;
}

public enum BuffNuggetBuffType
{
    INVALID,
    HEALING,
    LEADERSHIP,
    GLORIOUSCHARGE,
    DOMINATE,
    CURSED,
    BUFF,
    DEBUFF,
    POISON
}

[StructLayout(LayoutKind.Sequential)]
public struct BuffNugget
{
    public FXNugget Base;
    public BuffNuggetBuffType BuffType;
    public TypedAssetId<GameObject> Template;
    public TypedAssetId<GameObject> OrcTemplate;
    public TypedAssetId<GameObject> InfantryTemplate;
    public TypedAssetId<GameObject> CavalryTemplate;
    public TypedAssetId<GameObject> VehicleTemplate;
    public TypedAssetId<GameObject> TrollTemplate;
    public TypedAssetId<GameObject> MumakilTemplate;
    public TypedAssetId<GameObject> ShipTemplate;
    public TypedAssetId<GameObject> MonsterTemplate;
    public Time Lifetime;
    public float Extrusion;
    public RGBColor Color;
    public SageBool ComplexBuff;
}

[StructLayout(LayoutKind.Sequential)]
public struct LaserFXNugget
{
    public FXNugget Base;
    public TypedAssetId<GameObject> LaserTemplate;
    public Coord3D Offset;
    public SageBool LaserBackwards;
}

[StructLayout(LayoutKind.Sequential)]
public struct CameraShakerVolumeFXNugget
{
    public FXNugget Base;
    public float Radius;
    public Time Duration;
    public Angle Amplitude;
}

[StructLayout(LayoutKind.Sequential)]
public struct ViewShakeFXNugget
{
    public FXNugget Base;
    public ViewShakeType Type;
}

[StructLayout(LayoutKind.Sequential)]
public struct AttachedModelFXNugget
{
    public FXNugget Base;
    public AssetReference<BaseRenderAssetType> Model;
    public Time ExpireTimer;
    public SageBool RandomlyRotate;
}

[StructLayout(LayoutKind.Sequential)]
public struct TerrainScorchFXNuggetRandomRange
{
    public TerrainScorchType Low;
    public TerrainScorchType High;
}

[StructLayout(LayoutKind.Sequential)]
public struct TerrainScorchFXNugget
{
    public FXNugget Base;
    public TerrainScorchType Type;
    public float Radius;
    public unsafe TerrainScorchFXNuggetRandomRange* RandomRange;
}

[StructLayout(LayoutKind.Sequential)]
public struct TintDrawableFXNugget
{
    public FXNugget Base;
    public Time PreColorTime;
    public Time PostColorTime;
    public Time SustainedColorTime;
    public float Frequency;
    public float Amplitude;
    public RGBColor Color;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXListAtBonePosFXNugget
{
    public FXNugget Base;
    public AssetReference<FXList> FX;
    public AnsiString Bone;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleSysBoneNugget
{
    public FXNugget Base;
    public AnsiString Bone;
    public FXTriggerType TriggerType;
    public int HoldBetweenStateID;
    public FXActionType ActionType;
    public AssetReference<FXParticleSystemTemplate> Particle;
    public Coord3D Offset;
    public SageBool RequireFrequentUpdate;
}

[StructLayout(LayoutKind.Sequential)]
public struct ParticleSystemFXNuggetRotate
{
    public Angle X;
    public Angle Y;
    public Angle Z;
}

[StructLayout(LayoutKind.Sequential)]
public struct ParticleSystemFXNugget
{
    public FXNugget Base;
    public AssetReference<FXParticleSystemTemplate> Particle;
    public int Count;
    public AnsiString AttachToBone;
    public AnsiString CreateOverrideBone;
    public AnsiString TargetOverrideBone;
    public float TargetCoeff;
    public Time SystemLife;
    public ParticleSystemFXNuggetRotate Rotate;
    public Coord3D Offset;
    public unsafe Coord3D* TargetOffset;
    public ClientRandomVariable Radius;
    public ClientRandomVariable Height;
    public ClientRandomVariable InitialDelay;
    public SageBool OrientToObject;
    public SageBool Ricochet;
    public SageBool AttachToObject;
    public SageBool CreateAtGroundHeight;
    public SageBool UseTarget;
    public SageBool SetTargetMatrix;
    public SageBool OnlyIfOnWater;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXList
{
    public BaseAssetType Base;
    public Time CullTracking;
    public int CullTrackingMin;
    public int CullTrackingMax;
    public PolymorphicList<FXNugget> NuggetList;
    public SageBool PlayEvenIfShrouded;
    public SageBool Tailorable;
}
