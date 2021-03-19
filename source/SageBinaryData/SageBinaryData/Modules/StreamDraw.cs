using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ParticleSystemList
    {
        public List<AssetReference<FXParticleSystemTemplate>> ParticleSys;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DStreamDrawModuleData
    {
        public DrawModuleData Base;
        public float Velocity;
        public float ArcHeightFactor;
        public float UVWorldSize;
        public int NumTubeSides;
        public float TubeRadius;
        public AssetReference<FXList> HitFx;
        public int WeaponSlotID;
        public int StreamStateID;
        public FXShaderMaterial FXShader;
        public unsafe ParticleSystemList* ParticleSystems;
        public SageBool UseDistortionShader;
    }
}
