using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct RefundDieModuleData
{
    public DieModuleData Base;
    public AssetReference<UpgradeTemplate> UpgradeRequired;
    public List<AnsiString> BuildingRequired;
    public Percentage RefundPercent;
    public unsafe ObjectFilter* ObjectFilter;
}
