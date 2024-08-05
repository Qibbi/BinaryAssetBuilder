using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RandomAlphaKeyframe
{
    public ClientRandomVariable Base;
    public Percentage RelativeAge;
    public uint Frame;
}

[StructLayout(LayoutKind.Sequential)]
public struct RGBColorKeyframe
{
    public Percentage RelativeAge;
    public uint Frame;
    public Color3f Color;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticlePhysicsBase : IPolymorphic
{
    public FXParticleBaseModule Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDefaultPhysics
{
    public FXParticlePhysicsBase Base;
    public float Gravity;
    public ClientRandomVariable VelocityDamping;
    public Coord3D DriftVelocity;
    public SageBool Swirly;
    public SageBool ParticlesAttachToBone;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleSwarmPhysics
{
    public FXParticlePhysicsBase Base;
    public float AttractStrength;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleAlpha
{
    public List<RandomAlphaKeyframe> Alpha;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleColor
{
    public float HouseColorSaturation;
    public List<RGBColorKeyframe> Color;
    public ClientRandomVariable ColorScale;
    public SageBool UseHouseColor;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleWind
{
    public FXParticleSystem_WindMotion Motion;
    public float Strength;
    public float FullStrengthDist;
    public float ZeroStrengthDist;
    public float AngleChangeMin;
    public float AngleChangeMax;
    public float PingPongStartAngleMin;
    public float PingPongStartAngleMax;
    public float PingPongEndAngleMin;
    public float PingPongEndAngleMax;
    public float TurbulenceAmplitude;
    public float TurbulenceFrequency;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleSystemTemplate
{
    public BaseAssetType Base;
    public FXParticleSystem_Priority Priority;
    public FXParticleSystem_ShaderType Shader;
    public FXParticleSystem_Type Type;
    public AssetReference<Texture> ParticleTexture;
    public AssetReference<BaseRenderAssetType> Drawable;
    public TypedAssetId<BaseAssetType> SlaveSystem; // should be TypedAssetId<FXParticleSystemTemplate> but .net thinks it might be a circular reference
    public TypedAssetId<BaseAssetType> PerParticleAttachedSystem; // should be TypedAssetId<FXParticleSystemTemplate> but .net thinks it might be a circular reference
    public uint SystemLifetime;
    public uint SortLevel;
    public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* EmitterSound;
    public Coord3D SlavePosOffset;
    public ClientRandomVariable Lifetime;
    public ClientRandomVariable Size;
    public ClientRandomVariable StartSizeRate;
    public ClientRandomVariable BurstDelay;
    public ClientRandomVariable BurstCount;
    public ClientRandomVariable InitialDelay;
    public unsafe FXParticleAlpha* Alphas;
    public unsafe FXParticleColor* Colors;
    public unsafe FXParticleWind* Wind;
    public unsafe FXParticlePhysicsBase* Physics;
    public unsafe FXParticleDrawBase* Draw;
    public unsafe FXParticleEmissionVolumeBase* Volume;
    public unsafe FXParticleEmissionVelocityBase* Velocity;
    public PolymorphicList<FXParticleEventBase> Event;
    public unsafe FXParticleUpdateBase* Update;
    public SageBool IsOneShot;
    public SageBool IsGroundAligned;
    public SageBool IsEmitAboveGroundOnly;
    public SageBool IsParticleUpTowardsEmitter;
    public SageBool UseMaximumHeight;
}
