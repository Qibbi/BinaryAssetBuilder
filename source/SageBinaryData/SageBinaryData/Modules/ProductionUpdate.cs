using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct QuantityModifier
    {
        public TypedAssetId<GameObject> Name;
        public int Count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProductionModifier
    {
        public AssetReference<UpgradeTemplate> RequiredUpgrade;
        public float CostMultiplier;
        public float TimeMultiplier;
        public ObjectFilter ModifierFilter;
        public SageBool HeroPurchase;
        public SageBool HeroRevive;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProductionUpdateModuleData
    {
        public UpdateModuleData Base;
        public uint MaxQueueEntries;
        public int NumDoorAnimations;
        public Time DoorOpeningTime;
        public Time DoorWaitOpenTime;
        public Time DoorCloseTime;
        public uint ConstructionCompleteDuration;
        public DisabledBitFlags DisabledTypesToProcess;
        public uint UnitInvulnerableTime;
        public uint SpecialPrepModelconditionTime;
        public TypedAssetId<GameObject> BonusForType;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> SpeedBonusAudioLoop;
        public ProductionQueueType Type;
        public Time ProductionTimeDelayScalar;
        public List<QuantityModifier> QuantityModifier;
        public List<ProductionModifier> ProductionModifier;
        public SageBool GiveNoXP;
        public SageBool VeteranUnitsFromVeteranFactory;
        public SageBool SetBonusModelConditionOnSpeedBonus;
        public SageBool SecondaryQueue;
        public SageBool IgnorePreReqs;

    }
}
