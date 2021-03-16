using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct JumpJetSpecialPowerModuleData
    {
        public SpecialPowerModuleData Base;
        public float JumpRange;
        public unsafe RadiusDecalTemplate* ValidDecal;
        public unsafe RadiusDecalTemplate* InvalidDecal;
    }
}
