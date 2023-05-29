using System.Runtime.InteropServices;
using Relo;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct LaserUpdateModuleData
{
    public ClientUpdateModuleData Base;
    public AssetReference<FXParticleSystemTemplate> ParticleSystemId;
    public AnsiString ParentFireBoneName;
    public AssetReference<FXParticleSystemTemplate> TargetParticleSystemId;
    public float LaserLifetime;
    public SageBool ParentFireBoneOnTurret;
}
