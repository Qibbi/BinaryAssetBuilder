using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StorePurchasedUpgradeBehaviorModuleData
    {
        public BehaviorModuleData Base;
        public uint MaxPlayerUpgrades;
    }
}
