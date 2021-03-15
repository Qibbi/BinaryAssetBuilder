using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DelayedDeathBodyModuleData
    {
        public RespawnBodyModuleData Base;
        public Time DeathDelay;
        public AssetReference<FXList> DeathFX;
        public AssetReference<UpgradeTemplate> DelayedDeathPrerequisiteUpgrade;
        public SageBool ImmortalUntilDeathTime;
        public SageBool DoHealthCheck;
    }
}
