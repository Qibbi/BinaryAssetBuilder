using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum SetLocomotorSpeedUpdateType
    {
        INVALID,
        IN_RANGE_OBJECT_FILTER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SetLocomotorSpeedUpdateModuleData
    {
        public UpdateModuleData Base;
        public SetLocomotorSpeedUpdateType Type;
        public float LocomotorSpeedToSet;
        public float LocomotorDeltaPerUpdate;
        public float OtherScaredScanRangeMultiplier;
        public float ObjectFilterRange;
        public Time UpdatePeriod;
        public Angle VisionArc;
        public unsafe ObjectFilter* ObjectFilter;
    }
}
