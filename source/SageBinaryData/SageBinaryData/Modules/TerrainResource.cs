using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TerrainResourceBehaviorModuleData
    {
        public UpdateModuleData Base;
        public float Radius;
        public int MaxIncome;
        public uint IncomeInterval;
        public AssetReference<UpgradeTemplate> Upgrade;
        public List<AnsiString> UpgradeMustBePresent;
        public Percentage UpgradeBonusPercent;
        public unsafe ObjectFilter* ObjectFilter;
        public SageBool HighPriority;
        public SageBool Visible;
    }
}
