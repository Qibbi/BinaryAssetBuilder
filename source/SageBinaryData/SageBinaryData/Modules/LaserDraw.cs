using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct W3DLaserDrawModuleData
    {
        public DrawModuleData Base;
        public float Texture1_UTile;
        public float Texture1_VTile;
        public float Texture2_UTile;
        public float Texture2_VTile;
        public float Texture1_UScrollRate;
        public float Texture1_VScrollRate;
        public float Texture2_UScrollRate;
        public float Texture2_VScrollRate;
        public int Texture1_NumFrames;
        public float Texture1_FrameRate;
        public int Texture2_NumFrames;
        public float Texture2_FrameRate;
        public float LaserWidth;
        public int WeaponSlotID;
        public int LaserStateID;
        public FXShaderMaterial FXShader;
        public unsafe ObjectStatusValidationDataType* ObjectStatusValidation;
        public SageBool UseDistortionShader;
    }
}
