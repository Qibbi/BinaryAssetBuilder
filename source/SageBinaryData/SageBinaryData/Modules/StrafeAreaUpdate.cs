using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StrafeAreaUpdateModuleData
    {
        public UpdateModuleData Base;
        public AssetReference<WeaponTemplate> WeaponName;
        public float Radius;
        public float MinRadius;
        public float PreattackDistance;
        public float SweepFrequency;
        public float SweepAmplitude;
        public float DivingFloor;
        public float InitialSweepPhase;
        public float TargetJitterOffset;
        public uint ShotsToFirePerFrame;
    }
}
