using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ArmyDefinition
    {
        public BaseAssetType Base;
        public AnsiString Side;
        public Percentage StructureRebuildPriorityModifier;
        public float DefaultUnitPriority;
        public float FortressRebuildPriority;
        public float LowUnitPriorityModifier;
        public int EconomyBuilderMinFarmsOwned;
        public int EconomyBuilderMinMoney;
        public int EconomyBuilderPerFarmValue;
        public float EconomyBuilderPerSecPriorityIncreaseBase;
        public int EconomyBuilderMinTimeBetweenFarms_Rush;
        public float UpgradeSciencePriorityNormalLow;
        public float UpgradeSciencePriorityNormalHigh;
        public float UpgradeSciencePriorityImportantLow;
        public float UpgradeSciencePriorityImportantHigh;
        public float UnitUpgradePriorityLow;
        public float UnitUpgradePriorityHigh;
        public float MaxThreatForOpportunityTargets;
        public int ValueToSetForMaxOnDefenseTeam;
        public int CombatChainSearchDepthForTeamRecruits_AttackTeams;
        public int CombatChainSearchDepthForTeamRecruits_DefenseTeams;
        public int CombatChainSearchDepthForTeamRecruits_ExploreTeams;
        public TypedAssetId<GameObject> UnboundedProductionEconomyStructure;
        public TypedAssetId<GameObject> LimitedProductionEconomyStructure;
        public TypedAssetId<GameObject> WorkerGathererTemplate;
        public TypedAssetId<GameObject> MCVTemplate;
        public List<TypedAssetId<GameObject>> TechStructure;
        public SageBool NeedsDozerToFunction;
    }
}
