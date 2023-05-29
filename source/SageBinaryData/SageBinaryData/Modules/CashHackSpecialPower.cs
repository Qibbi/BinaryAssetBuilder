#if TIBERIUMWARS
using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CashHackSpecialPowerUpgrades
{
    public ScienceType Science;
    public int AmountToSteal;
}

[StructLayout(LayoutKind.Sequential)]
public struct CashHackSpecialPowerModuleData
{
    public SpecialPowerModuleData Base;
    public int DefaultAmountToSteal;
    public List<CashHackSpecialPowerUpgrades> Upgrades;
}
#endif
