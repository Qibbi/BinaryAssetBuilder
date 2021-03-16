using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MoneyCrateCollideModuleData
    {
        public CrateCollideModuleData Base;
        public uint MoneyProvided;
    }
}
