using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ArmorUpgradeModuleData
    {
        public UpgradeModuleData Base;
        public ArmorSetType ArmorSetFlag;
        public SageBool KillArmorUpgrade;
        public SageBool IgnoreArmorUpgrade;
    }
}
