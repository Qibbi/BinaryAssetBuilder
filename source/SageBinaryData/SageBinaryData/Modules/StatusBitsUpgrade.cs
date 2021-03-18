using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StatusBitsUpgradeModuleData
    {
        public UpgradeModuleData Base;
        public ObjectStatusBitFlags StatusToSet;
        public ObjectStatusBitFlags StatusToClear;
    }
}
