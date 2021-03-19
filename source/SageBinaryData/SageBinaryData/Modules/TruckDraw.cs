using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DTruckDrawModuleData
    {
        public W3DScriptedModelDrawModuleData Base;
        public AssetReference<FXParticleSystemTemplate> Dust;
        public AssetReference<FXParticleSystemTemplate> DirtSpray;
        public AssetReference<FXParticleSystemTemplate> PowerslideSpray;
        public AnsiString LeftFrontTireBone;
        public AnsiString RightFrontTireBone;
        public AnsiString LeftRearTireBone;
        public AnsiString RightRearTireBone;
        public AnsiString MidLeftFrontTireBone;
        public AnsiString MidRightFrontTireBone;
        public AnsiString MidLeftRearTireBone;
        public AnsiString MidRightRearTireBone;
        public AnsiString MidLeftMidTireBone;
        public AnsiString MidRightMidTireBone;
        public AnsiString LeftFrontTireBone2;
        public AnsiString RightFrontTireBone2;
        public AnsiString LeftRearTireBone2;
        public AnsiString RightRearTireBone2;
        public AnsiString MidLeftMidTireBone2;
        public AnsiString MidRightMidTireBone2;
        public float TireRotationMultiplier;
        public float TireRotationMultiplierFront;
        public float PowerslideRotationAddition;
        public AnsiString CabBone;
        public AnsiString TrailerBone;
        public float CabRotationMultiplier;
        public float TrailerRotationMultiplier;
        public float RotationDamping;
    }
}
