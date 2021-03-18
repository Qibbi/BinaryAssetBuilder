using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RadarUpdateModuleData
    {
        public UpdateModuleData Base;
        public float RadarExtendTime;
    }
}
