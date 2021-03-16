using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpawnBehaviorModuleData
    {
        public UpgradeModuleData Base;
        public int SpawnNumberData;
        public Time SpawnReplaceDelayData;
        public int InitialBurst;
        public DamageBitFlags DamageTypesToPropagateToSlaves;
        public Time FadeInTime;
        public Time InitialDelay;
        public unsafe DieMuxDataType* Die;
        public List<TypedAssetId<GameObject>> SpawnTemplate;
        public SageBool IsOneShotData;
        public SageBool CanReclaimOrphans;
        public SageBool AggregateHealth;
        public SageBool ExitByBudding;
        public SageBool SpawnedRequireSpawner;
        public SageBool RespectCommandLimit;
        public SageBool KillSpawnBasedOnModelConditionState;
        public SageBool ShareUpgrades;
        public SageBool SpawnInsideBuilding;
        public SageBool CombineOnCreate;
        public SageBool KillSpawnsOnDisabled;
        public SageBool PassExperienceToSpawned;
        public SageBool KillSpawnsOnCaptured;
    }
}
