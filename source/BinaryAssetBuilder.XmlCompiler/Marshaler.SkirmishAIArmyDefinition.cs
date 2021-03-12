using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ArmyDefinition* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.Side), null), &objT->Side, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.StructureRebuildPriorityModifier), "50"), &objT->StructureRebuildPriorityModifier, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.DefaultUnitPriority), "100.0"), &objT->DefaultUnitPriority, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.FortressRebuildPriority), "1950.0"), &objT->FortressRebuildPriority, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.LowUnitPriorityModifier), "100.0"), &objT->LowUnitPriorityModifier, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.EconomyBuilderMinFarmsOwned), "5"), &objT->EconomyBuilderMinFarmsOwned, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.EconomyBuilderMinMoney), "150"), &objT->EconomyBuilderMinMoney, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.EconomyBuilderPerFarmValue), "70"), &objT->EconomyBuilderPerFarmValue, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.EconomyBuilderPerSecPriorityIncreaseBase), "5.0"), &objT->EconomyBuilderPerSecPriorityIncreaseBase, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.EconomyBuilderMinTimeBetweenFarms_Rush), "10"), &objT->EconomyBuilderMinTimeBetweenFarms_Rush, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.UpgradeSciencePriorityNormalLow), "100.0"), &objT->UpgradeSciencePriorityNormalLow, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.UpgradeSciencePriorityNormalHigh), "200.0"), &objT->UpgradeSciencePriorityNormalHigh, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.UpgradeSciencePriorityImportantLow), "250.0"), &objT->UpgradeSciencePriorityImportantLow, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.UpgradeSciencePriorityImportantHigh), "350.0"), &objT->UpgradeSciencePriorityImportantHigh, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.UnitUpgradePriorityLow), "100.0"), &objT->UnitUpgradePriorityLow, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.UnitUpgradePriorityHigh), "200.0"), &objT->UnitUpgradePriorityHigh, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.MaxThreatForOpportunityTargets), "10.0"), &objT->MaxThreatForOpportunityTargets, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.ValueToSetForMaxOnDefenseTeam), "10"), &objT->ValueToSetForMaxOnDefenseTeam, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.CombatChainSearchDepthForTeamRecruits_AttackTeams), "2"), &objT->CombatChainSearchDepthForTeamRecruits_AttackTeams, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.CombatChainSearchDepthForTeamRecruits_DefenseTeams), "7"), &objT->CombatChainSearchDepthForTeamRecruits_DefenseTeams, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.CombatChainSearchDepthForTeamRecruits_ExploreTeams), "7"), &objT->CombatChainSearchDepthForTeamRecruits_ExploreTeams, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.UnboundedProductionEconomyStructure), null), &objT->UnboundedProductionEconomyStructure, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.LimitedProductionEconomyStructure), null), &objT->LimitedProductionEconomyStructure, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.NeedsDozerToFunction), "false"), &objT->NeedsDozerToFunction, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.WorkerGathererTemplate), "0"), &objT->WorkerGathererTemplate, state);
        Marshal(node.GetAttributeValue(nameof(ArmyDefinition.MCVTemplate), "0"), &objT->MCVTemplate, state);
        Marshal(node.GetChildNodes(nameof(ArmyDefinition.TechStructure)), &objT->TechStructure, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
