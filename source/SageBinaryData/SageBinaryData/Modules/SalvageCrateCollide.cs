using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SalvageCrateCollideModuleData
    {
        public CrateCollideModuleData Base;
        public float PorterChance;
        public float BannerChance;
        public float LevelUpChance;
        public float LevelUpRadius;
        public float ResourceChance;
        public int MinimumResource;
        public int MaximumResource;
        public AssetReference<UpgradeTemplate> Upgrade;
        public SageBool AllowAIPickup;
    }
}
