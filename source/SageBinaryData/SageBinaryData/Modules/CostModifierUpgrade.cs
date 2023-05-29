using System.Runtime.InteropServices;
using Relo;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CostModifierUpgradeModuleData
{
    public UpgradeModuleData Base;
    public List<Percentage> Percentages;
    public AnsiString UILabel;
    public unsafe ObjectFilter* ObjectFilter;
    public List<TypedAssetId<UpgradeTemplate>> ApplyToUpgrade;
    public SageBool IsUpgradeDiscountUpgrade;
    public SageBool StartsActive;
    public SageBool Slaughter;
}
