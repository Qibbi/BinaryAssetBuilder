using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct GiveOrRestoreUpgradeSpecialPowerModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public AnsiString CommandButton;
    public AssetReference<UpgradeTemplate> UpgradeToGive;
    public WeaponSetBitFlags WeaponFlags;
}
