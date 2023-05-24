using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct PlayerUpgradeSpecialPowerModuleData
{
    public SpecialPowerModuleData Base;
    public List<AssetReference<UpgradeTemplate>> Upgrade;
}
