using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BeaconClientUpdateModuleData
    {
        public ClientUpdateModuleData Base;
        public uint FramesBetweenRadarPulses;
        public uint RadarPulseDuration;
    }
}
