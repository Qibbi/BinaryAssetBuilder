using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UpgradeDieModuleData
{
    public DieModuleData Base;
    public AssetReference<UpgradeTemplate> UpgradeId;
}
