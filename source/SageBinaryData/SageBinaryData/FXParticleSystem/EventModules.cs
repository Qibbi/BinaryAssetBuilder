using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEventBase : IPolymorphic
{
    public FXParticleBaseModule Base;
    public AssetReference<FXList> EventFX;
    public SageBool PerParticle;
    public SageBool KillAfterEvent;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEventLife
{
    public FXParticleEventBase Base;
    public ClientRandomVariable EventTime;
}

[StructLayout(LayoutKind.Sequential)]
public struct FXParticleEventCollision
{
    public FXParticleEventBase Base;
    public ClientRandomVariable HeightOffset;
    public SageBool OrientFXToTerrain;
}
