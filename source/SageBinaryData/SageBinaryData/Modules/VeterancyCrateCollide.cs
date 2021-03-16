using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VeterancyCrateCollideModuleData
    {
        public CrateCollideModuleData Base;
        public uint RangeOfEffect;
        public int AffectsUpToLevel;
        public SageBool AddsOwnerVeterancy;
        public SageBool IsPilot;
    }
}
