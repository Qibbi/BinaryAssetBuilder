using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
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
}
