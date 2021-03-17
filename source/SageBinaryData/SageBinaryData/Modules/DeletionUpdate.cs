using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeletionUpdateModuleData
    {
        public UpdateModuleData Base;
        public uint MinFrames;
        public uint MaxFrames;
    }
}
