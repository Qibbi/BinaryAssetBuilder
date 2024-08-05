using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVelocityBase : IPolymorphic
{
    public FXParticleBaseModule Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVelocityCylinder
{
    public FXParticleEmissionVelocityBase Base;
    public ClientRandomVariable Radial;
    public ClientRandomVariable Normal;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVelocityOrtho
{
    public FXParticleEmissionVelocityBase Base;
    public RandCoord3D Position;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVelocityOutward
{
    public FXParticleEmissionVelocityBase Base;
    public ClientRandomVariable Speed;
    public ClientRandomVariable OtherSpeed;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVelocitySphere
{
    public FXParticleEmissionVelocityBase Base;
    public ClientRandomVariable Speed;
}

#if TIBERIUMWARS
[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEmissionVelocityHemisphere
{
    public FXParticleEmissionVelocitySphere Base;
}
#endif
