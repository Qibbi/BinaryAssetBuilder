using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AIGateUpdateModuleData
    {
        public UpdateModuleData Base;
        public float TriggerWidthX;
        public float TriggerWidthY;
    }
}
