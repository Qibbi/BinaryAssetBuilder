using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum OCLMonitorOption
    {
        MASTER,
        KILL_WHEN_RELEASED
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OCLMonitorOptionFlag
    {
        public const int Count = 0x00000002;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OCLMonitorUpdateModuleData
    {
        public UpdateModuleData Base;
        public OCLMonitorOptionFlag Options;
        public ObjectStatusBitFlags RequiredMasterObjectStatus;
    }
}
