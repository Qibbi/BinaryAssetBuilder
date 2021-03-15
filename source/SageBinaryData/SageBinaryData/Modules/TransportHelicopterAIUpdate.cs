using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum FlyOffMapType
    {
        CONTINUE_STRAIGHT,
        REVERSE_DIRECTION,
        CLOSEST_MAP_EDGE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TransportHelicopterAIUpdateModuleData
    {
        public SupplyTruckAIUpdateModuleData Base;
        public FlyOffMapType FlyOffMap;
        public Time DelayAFterLoadingOrUnloading;
        public SageBool FlyOffMapOnUnload;
    }
}
