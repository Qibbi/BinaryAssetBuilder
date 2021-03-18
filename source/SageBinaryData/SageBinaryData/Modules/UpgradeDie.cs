using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UpgradeDieModuleData
    {
        public DieModuleData Base;
        public AssetReference<UpgradeTemplate> UpgradeId;
    }
}
