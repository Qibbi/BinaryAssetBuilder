using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DynamicShroudClearingRangeUpdateModuleData
    {
        public UpdateModuleData Base;
        public float FinalVision;
        public uint ChangeInterval;
        public uint GrowInterval;
        public uint ShrinkDelay;
        public uint ShrinkTime;
        public uint GrowDelay;
        public uint GrowTime;
        public unsafe RadiusDecalTemplate* GridDecalTemplate;
        public SageBool InitiallyDisabled;
    }
}
