using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StreamStateModuleData
    {
        public UpdateModuleData Base;
        public int StreamId;
    }
}
