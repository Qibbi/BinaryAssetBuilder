using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AutoHealBehaviorModuleData
    {
        public UpgradeModuleData Base;
        public int HealingAmount;
        public Time HealingDelay;
        public Time StartHealingDelay;
        public int Radius;
        public KindOfBitFlags KindOf;
        public AssetReference<FXList> HealFXList;
        public AssetReference<FXList> SpawnFXList;
        public Time RespawnMinimumDelay;
        public SageBool InitiallyActive;
        public SageBool AffectsWholePlayer;
        public SageBool AffectsContained;
        public SageBool HealOnlyIfNotUnderAttack;
        public SageBool HealOnlyIfNotInCombat;
        public SageBool HealOnlyOthers;
        public SageBool NonStackable;
        public SageBool RespawnNearbyHordeMembers;
    }
}
