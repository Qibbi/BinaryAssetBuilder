using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AITarget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AITarget.TacticalAITarget), null), &objT->TacticalAITarget, state);
        Marshal(node.GetAttributeValue(nameof(AITarget.MaxTeamsPerTarget), "1"), &objT->MaxTeamsPerTarget, state);
        Marshal(node.GetAttributeValue(nameof(AITarget.UpdateTime), "1s"), &objT->UpdateTime, state);
    }

    public static unsafe void Marshal(Node node, AIStrategicState* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStrategicState.State), null), &objT->State, state);
        Marshal(node.GetAttributeValue(nameof(AIStrategicState.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIBudgetState* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIBudgetState.State), null), &objT->State, state);
        Marshal(node.GetAttributeValue(nameof(AIBudgetState.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIBuildDelay* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIBuildDelay.Delay), "0s"), &objT->Delay, state);
        Marshal(node.GetAttributeValue(nameof(AIBuildDelay.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIResourceMultiplierCheat* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIResourceMultiplierCheat.Percentage), "100%"), &objT->Percentage, state);
        Marshal(node.GetAttributeValue(nameof(AIResourceMultiplierCheat.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIBuildDelayRange* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIBuildDelayRange.MinDelay), "0s"), &objT->MinDelay, state);
        Marshal(node.GetAttributeValue(nameof(AIBuildDelayRange.MaxDelay), "0s"), &objT->MaxDelay, state);
        Marshal(node.GetAttributeValue(nameof(AIBuildDelayRange.MinTTKRatio), "1"), &objT->MinTTKRatio, state);
        Marshal(node.GetAttributeValue(nameof(AIBuildDelayRange.MaxTTKRatio), "1"), &objT->MaxTTKRatio, state);
        Marshal(node.GetAttributeValue(nameof(AIBuildDelayRange.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIUnitBuilderUnitChoiceStrategy* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategy.Shape), "FLAT"), &objT->Shape, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategy.StandardDeviation), "1"), &objT->StandardDeviation, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategy.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIUnitBuilderUnitChoiceStrategyAdaptive* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategyAdaptive.MinEffectiveness), "0.5"), &objT->MinEffectiveness, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategyAdaptive.MaxEffectiveness), "0.5"), &objT->MaxEffectiveness, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategyAdaptive.MinStandardDeviation), "0.5"), &objT->MinStandardDeviation, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategyAdaptive.MaxStandardDeviation), "0.5"), &objT->MaxStandardDeviation, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategyAdaptive.MinEfficiency), "1"), &objT->MinEfficiency, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategyAdaptive.MaxEfficiency), "1"), &objT->MaxEfficiency, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderUnitChoiceStrategyAdaptive.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIUnitBuilderEvaluationDelayRange* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderEvaluationDelayRange.UseAllAvailableQueues), "true"), &objT->UseAllAvailableQueues, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderEvaluationDelayRange.MinDelay), "0s"), &objT->MinDelay, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderEvaluationDelayRange.MaxDelay), "0s"), &objT->MaxDelay, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderEvaluationDelayRange.MinEfficiency), "1"), &objT->MinEfficiency, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderEvaluationDelayRange.MaxEfficiency), "1"), &objT->MaxEfficiency, state);
        Marshal(node.GetAttributeValue(nameof(AIUnitBuilderEvaluationDelayRange.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIPersonalityDefMap* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefMap.Side), null), &objT->Side, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefMap.Personality), null), &objT->Personality, state);
    }

    public static unsafe void Marshal(Node node, AIWeightedOpeningMove* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIWeightedOpeningMove.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(AIWeightedOpeningMove.Weight), "100%"), &objT->Weight, state);
        Marshal(node.GetAttributeValue(nameof(AIWeightedOpeningMove.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AISpecificUnitCap* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AISpecificUnitCap.Unit), null), &objT->Unit, state);
        Marshal(node.GetAttributeValue(nameof(AISpecificUnitCap.Cap), "1"), &objT->Cap, state);
    }

    public static unsafe void Marshal(Node node, AIPersonalityDefinition* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.PersonalityType), null), &objT->PersonalityType, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.PersonalityUIName), null), &objT->PersonalityUIName, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.SkirmishPersonality), "false"), &objT->SkirmishPersonality, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.SecondsTillTargetsCanExpire), "15.0"), &objT->SecondsTillTargetsCanExpire, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.ChanceForTargetToExpire), "50"), &objT->ChanceForTargetToExpire, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.ChanceForUnitsToUpgrade), "50"), &objT->ChanceForUnitsToUpgrade, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.MaxBuildingsToBeDefensiveTarget_Small), "1"), &objT->MaxBuildingsToBeDefensiveTarget_Small, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.MaxBuildingsToBeDefensiveTarget_Med), "4"), &objT->MaxBuildingsToBeDefensiveTarget_Med, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.ChanceToUseAllUnitsForDefenseTarget_Small), "10"), &objT->ChanceToUseAllUnitsForDefenseTarget_Small, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.ChanceToUseAllUnitsForDefenseTarget_Med), "25"), &objT->ChanceToUseAllUnitsForDefenseTarget_Med, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.ChanceToUseAllUnitsForDefenseTarget_Large), "75"), &objT->ChanceToUseAllUnitsForDefenseTarget_Large, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.DesiredExcessPowerBuffer), "0"), &objT->DesiredExcessPowerBuffer, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.BaseCompactness), "0.5"), &objT->BaseCompactness, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.DefaultThreatFindRadius), "300.0"), &objT->DefaultThreatFindRadius, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.UnitBuilderCostEffectivenessWeight), "1.0"), &objT->UnitBuilderCostEffectivenessWeight, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.UnitBuilderMoneyVersusTimePreference), "0.5"), &objT->UnitBuilderMoneyVersusTimePreference, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.UnitBuilderOverallOffensivePreference), "100%"), &objT->UnitBuilderOverallOffensivePreference, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.UnitBuilderOverallDefensivePreference), "100%"), &objT->UnitBuilderOverallDefensivePreference, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.UnitBuilderEnemyTowerWeight), "100%"), &objT->UnitBuilderEnemyTowerWeight, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.Expansion_TiberiumSearchRadius), "500.0"), &objT->Expansion_TiberiumSearchRadius, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.Expansion_MaxTiberiumRemaining), "3000"), &objT->Expansion_MaxTiberiumRemaining, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.ReactiveDefenseRadius), "1200.0"), &objT->ReactiveDefenseRadius, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.RepairBuildingsAtDifficulty), "EASY MEDIUM HARD BRUTAL"), &objT->RepairBuildingsAtDifficulty, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.EmergencyManagerHandleNoPowerAtDifficulty), ""), &objT->EmergencyManagerHandleNoPowerAtDifficulty, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.EmergencyManagerHandleNoIncomeAtDifficulty), ""), &objT->EmergencyManagerHandleNoIncomeAtDifficulty, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.EmergencyManagerHandleNoConyardAtDifficulty), ""), &objT->EmergencyManagerHandleNoConyardAtDifficulty, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.StructureSaveChanceEasy), "0.0"), &objT->StructureSaveChanceEasy, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.StructureSaveChanceMedium), "0.0"), &objT->StructureSaveChanceMedium, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.StructureSaveChanceHard), "0.0"), &objT->StructureSaveChanceHard, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.MinHarvesters), "0"), &objT->MinHarvesters, state);
        Marshal(node.GetAttributeValue(nameof(AIPersonalityDefinition.TimeToBeConsideredIdle), "1.0"), &objT->TimeToBeConsideredIdle, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.Side)), &objT->Side, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.PersonalityMap)), &objT->PersonalityMap, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.BuildDelay)), &objT->BuildDelay, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.BuildDelayRange)), &objT->BuildDelayRange, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.UnitBuilderUnitChoiceStrategy)), &objT->UnitBuilderUnitChoiceStrategy, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.UnitBuilderUnitChoiceStrategyAdaptive)), &objT->UnitBuilderUnitChoiceStrategyAdaptive, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.UnitBuilderEvaluationDelayRange)), &objT->UnitBuilderEvaluationDelayRange, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.ResourceMultiplierCheat)), &objT->ResourceMultiplierCheat, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.TacticalTarget)), &objT->TacticalTarget, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.SpecificUnitCap)), &objT->SpecificUnitCap, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.OpeningMoves)), &objT->OpeningMoves, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.OpeningMove)), &objT->OpeningMove, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.States)), &objT->States, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.BudgetStates)), &objT->BudgetStates, state);
        Marshal(node.GetChildNodes(nameof(AIPersonalityDefinition.UnitOverride)), &objT->UnitOverride, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
