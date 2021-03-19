using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ArticulationBone
    {
        public AnsiString ArticulationBoneName;
        public AnsiString ArticulationHelperBoneName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct W3DTankDrawModuleData
    {
        public W3DScriptedModelDrawModuleData Base;
        public float TreadAnimationRate;
        public float TreadPivotSpeedFraction;
        public float TreadDriveSpeedFraction;
        public AssetReference<FXParticleSystemTemplate> TreadDebrisRight;
        public AssetReference<FXParticleSystemTemplate> TreadDebrisLeft;
        public List<AnsiString> LeftTread;
        public List<AnsiString> RightTread;
        public List<ArticulationBone> ArticulationBone;
    }
}
