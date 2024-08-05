using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDrawBase : IPolymorphic
{
    public FXParticleBaseModule Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDrawGpu
{
    public FXParticleDrawBase Base;
    public AnsiString Shader;
    public int FramesPerRow;
    public int TotalFrames;
    public AssetReference<Texture> DetailTexture;
    public float SpeedMultiplier;
    public FXParticleSystem_GeometryType GeometryType;
    public SageBool SortParticles;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDrawLightningRandomSet
{
    public ClientRandomVariable StartAmplitude;
    public ClientRandomVariable EndAmplitude;
    public ClientRandomVariable StartFrequency;
    public ClientRandomVariable EndFrequency;
    public ClientRandomVariable StartPhase;
    public ClientRandomVariable EndPhase;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDrawLightning
{
    public FXParticleDrawBase Base;
    public Coord3D StartPoint;
    public Coord3D EndPoint;
    public List<FXParticleDrawLightningRandomSet> RandomSet;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDrawRenderObjectObjectSet
{
    public AnsiString RenderGroup;
    public int NumObjects;
    public Percentage Percent;
    public FXParticleSystem_ShaderType Shader;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDrawRenderObject
{
    public FXParticleDrawBase Base;
    public float SinkRate;
    public List<FXParticleDrawRenderObjectObjectSet> ObjectSet;
    public SageBool MultiRenderObjects;
    public SageBool SinkOnTerrainCollision;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDrawStreak
{
    public FXParticleDrawBase Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDrawSwarm
{
    public FXParticleDrawBase Base;
    public float OpaqueSpeed;
    public float TransparentSpeed;
    public float SpeedStretchAmount;
    public float AttractStrength;
    public AssetReference<Texture> EnvironmentTexture;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleDrawTrail
{
    public FXParticleDrawBase Base;
    public int TrailLife;
    public float UTile;
    public float VTile;
    public float UScrollRate;
    public float VScrollRate;
}
