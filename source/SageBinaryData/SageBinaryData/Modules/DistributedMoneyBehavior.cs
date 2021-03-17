using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DistributedMoneyBehaviorModuleData
    {
        public CreateModuleData Base;
        public uint Capacity;
        public Percentage OnDieSpawnPercentage;
        public DeathType RedistributeMoneyOnDeathType;
    }
}
