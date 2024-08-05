using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVolumeBase : IPolymorphic
{
    public FXParticleBaseModule Base;
    public SageBool IsHollow;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVolumeBox
{
    public FXParticleEmissionVolumeBase Base;
    public Coord3D HalfSize;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVolumeCylinder
{
    public FXParticleEmissionVolumeBase Base;
    public float Radius;
    public float RadiusRate;
    public float Length;
    public Coord3D Offset;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVolumeLine
{
    public FXParticleEmissionVolumeBase Base;
    public Coord3D StartPoint;
    public Coord3D EndPoint;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVolumeSpline
{
    public FXParticleEmissionVolumeBase Base;
    public Coord3D StartPoint;
    public Coord3D EndPoint;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVolumePoint
{
    public FXParticleEmissionVolumeBase Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVolumeSphere
{
    public FXParticleEmissionVolumeBase Base;
    public float Radius;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVolumeTerrainFire
{
    public FXParticleEmissionVolumeBase Base;
    public float CellEmissionChance;
    public RandCoord3D Offset;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVolumeLightning
{
    public FXParticleEmissionVolumeBase Base;
}
