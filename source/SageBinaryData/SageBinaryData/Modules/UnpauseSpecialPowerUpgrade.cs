using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct UnpauseSpecialPowerUpgradeModuleData
{
    public UpgradeModuleData Base;
    public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
    public SageBool ObeyRechageOnTrigger;
}
