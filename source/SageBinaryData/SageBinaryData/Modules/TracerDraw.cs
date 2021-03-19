using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DTracerDrawModuleData
    {
        public DrawModuleData Base;
        public float MinLength;
        public float MaxLength;
        public float Width;
        public float MinSpeed;
        public float MaxSpeed;
        public float SweepSpeed;
        public float SpreadAngle;
        public float MinTracersPerFrame;
        public float MaxTracersPerFrame;
        public float FrameLifeTime;
        public WeaponSlotType WeaponSlotType;
        public int WeaponSlotID;
        public AssetReference<Texture> Texture;
        public AssetReference<FXList> TracerHitFx;
        public AssetReference<FXList> TracerEmitFx;
        public int TextureIndex;
        public Color4f HeadColor;
        public Color4f TailColor;
        public unsafe ObjectStatusValidationDataType* ObjectStatusValidation;
        public SageBool UseAdditiveBlending;
    }
}
