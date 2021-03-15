using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DozerAIUpdateModuleData
    {
        public AIUpdateModuleData Base;
        public float RepairHealthPercentPerSecond;
        public float BoredTime;
        public float BoredRange;
    }
}
