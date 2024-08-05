using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleUpdateBase : IPolymorphic
{
    public FXParticleBaseModule Base;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleUpdateDefault
{
    public FXParticleUpdateBase Base;
    public FXParticleSystem_RotationType Rotation;
    public ClientRandomVariable SizeRate;
    public ClientRandomVariable SizeRateDamping;
    public ClientRandomVariable AngleZ;
    public ClientRandomVariable AngularRateZ;
    public ClientRandomVariable AngularDamping;
    public ClientRandomVariable AngleXY;
    public ClientRandomVariable AngularRateXY;
    public ClientRandomVariable AngularDampingXY;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleUpdateRenderObject
{
    public FXParticleUpdateBase Base;
    public FXParticleSystem_RotationType Rotation;
    public ClientRandomVariable AngleZ;
    public ClientRandomVariable AngularRateZ;
    public ClientRandomVariable AngularDamping;
    public RandCoord3D StartSize;
    public RandCoord3D SizeRate;
    public RandCoord3D SizeDamping;
}
