using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AIStateHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    public static unsafe void Marshal(Node node, AIStateConstantHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateConstantHeuristic.Weight), "1.0"), &objT->Weight, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateTimerHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateTimerHeuristic.StartTime), "0s"), &objT->StartTime, state);
        Marshal(node.GetAttributeValue(nameof(AIStateTimerHeuristic.EndTime), "20s"), &objT->EndTime, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateIntervalHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateIntervalHeuristic.IntervalTime), "60s"), &objT->IntervalTime, state);
        Marshal(node.GetAttributeValue(nameof(AIStateIntervalHeuristic.ActiveTime), "30s"), &objT->ActiveTime, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateOpeningMoveHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateOpeningMoveHeuristic.Complete), "true"), &objT->Complete, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateHarvesterCapHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateHarvesterCapHeuristic.MaxHarvesters), "5"), &objT->MaxHarvesters, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateMoneyHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateMoneyHeuristic.Money), "1000"), &objT->Money, state);
        Marshal(node.GetAttributeValue(nameof(AIStateMoneyHeuristic.Above), "true"), &objT->Above, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateFullInvestmentHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateFullInvestmentHeuristic.Threshold), "1000"), &objT->Threshold, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateFullTechHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateFullTechHeuristic.Threshold), "1000"), &objT->Threshold, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateAntiGarrisonTechHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateAntiGarrisonTechHeuristic.EnemyGarrisons), "4"), &objT->EnemyGarrisons, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStatePathToTargetHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStatePathToTargetHeuristic.PathExists), "true"), &objT->PathExists, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateCounterattackHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateCounterattackHeuristic.Threshold), "1.0"), &objT->Threshold, state);
        Marshal(node.GetAttributeValue(nameof(AIStateCounterattackHeuristic.AttackerKindOf), null), &objT->AttackerKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AIStateCounterattackHeuristic.DefenderKindOf), null), &objT->DefenderKindOf, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateEnemyNearbyHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateEnemyNearbyHeuristic.Distance), "1000.0"), &objT->Distance, state);
        Marshal(node.GetAttributeValue(nameof(AIStateEnemyNearbyHeuristic.EnemyNearby), "true"), &objT->EnemyNearby, state);
        Marshal(node.GetAttributeValue(nameof(AIStateEnemyNearbyHeuristic.AttackerKindOf), null), &objT->AttackerKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AIStateEnemyNearbyHeuristic.DefenderKindOf), null), &objT->DefenderKindOf, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateFocusedThresholdHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateFocusedThresholdHeuristic.AttackerKindOf), null), &objT->AttackerKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AIStateFocusedThresholdHeuristic.DefenderKindOf), null), &objT->DefenderKindOf, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateSpreadThresholdHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateSpreadThresholdHeuristic.AttackerKindOf), null), &objT->AttackerKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AIStateSpreadThresholdHeuristic.DefenderKindOf), null), &objT->DefenderKindOf, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateSiegeThresholdHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateSiegeThresholdHeuristic.SiegeMode), "true"), &objT->SiegeMode, state);
        Marshal(node.GetAttributeValue(nameof(AIStateSiegeThresholdHeuristic.Threshold), "1.0"), &objT->Threshold, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateBalanceOfPowerHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateBalanceOfPowerHeuristic.AttackerKindOf), null), &objT->AttackerKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AIStateBalanceOfPowerHeuristic.DefenderKindOf), null), &objT->DefenderKindOf, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStatePowerAdvantageHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStatePowerAdvantageHeuristic.AttackerKindOf), null), &objT->AttackerKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AIStatePowerAdvantageHeuristic.DefenderKindOf), null), &objT->DefenderKindOf, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStatePenetrabilityHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStatePenetrabilityHeuristic.AttackerKindOf), null), &objT->AttackerKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AIStatePenetrabilityHeuristic.DefenderKindOf), null), &objT->DefenderKindOf, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateVulnerabilityHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateVulnerabilityHeuristic.AttackerKindOf), null), &objT->AttackerKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AIStateVulnerabilityHeuristic.DefenderKindOf), null), &objT->DefenderKindOf, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateOpponentAAPowerHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateOpponentAAPowerHeuristic.AttackerKindOf), null), &objT->AttackerKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AIStateOpponentAAPowerHeuristic.DefenderKindOf), null), &objT->DefenderKindOf, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateOpponentFundsHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateOpponentPowerThresholdHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateMiddleGameHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateLateGameHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateProductionAdvantageHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateBridgeExistsHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateBridgeExistsHeuristic.BridgeHealthMinimumPercentage), "50%"), &objT->BridgeHealthMinimumPercentage, state);
        Marshal(node.GetAttributeValue(nameof(AIStateBridgeExistsHeuristic.BridgeHealthMaximumPercentage), "100%"), &objT->BridgeHealthMaximumPercentage, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateSuperweaponHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateOverpowerHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateOverpowerHeuristic.PowerAdvantageWeight), null), &objT->PowerAdvantageWeight, state);
        Marshal(node.GetAttributeValue(nameof(AIStateOverpowerHeuristic.PenetrabilityWeight), null), &objT->PenetrabilityWeight, state);
        Marshal(node.GetChildNode(nameof(AIStateOverpowerHeuristic.PowerAdvantageHeuristic), null), &objT->PowerAdvantageHeuristic, state);
        Marshal(node.GetChildNode(nameof(AIStateOverpowerHeuristic.PenetrabilityHeuristic), null), &objT->PenetrabilityHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateResourceSqueezeHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateResourceSqueezeHeuristic.PenetrabilityWeight), null), &objT->PenetrabilityWeight, state);
        Marshal(node.GetAttributeValue(nameof(AIStateResourceSqueezeHeuristic.OpponentFundsWeight), null), &objT->OpponentFundsWeight, state);
        Marshal(node.GetChildNode(nameof(AIStateResourceSqueezeHeuristic.PenetrabilityHeuristic), null), &objT->PenetrabilityHeuristic, state);
        Marshal(node.GetChildNode(nameof(AIStateResourceSqueezeHeuristic.OpponentFundsHeuristic), null), &objT->OpponentFundsHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateProductionHaltHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateProductionHaltHeuristic.PenetrabilityWeight), null), &objT->PenetrabilityWeight, state);
        Marshal(node.GetAttributeValue(nameof(AIStateProductionHaltHeuristic.BalanceOfPowerWeight), null), &objT->BalanceOfPowerWeight, state);
        Marshal(node.GetChildNode(nameof(AIStateProductionHaltHeuristic.PenetrabilityHeuristic), null), &objT->PenetrabilityHeuristic, state);
        Marshal(node.GetChildNode(nameof(AIStateProductionHaltHeuristic.BalanceOfPowerHeuristic), null), &objT->BalanceOfPowerHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateBaseCrackHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(AIStateBaseCrackHeuristic.LateGameHeuristic), null), &objT->LateGameHeuristic, state);
        Marshal(node.GetChildNode(nameof(AIStateBaseCrackHeuristic.PenetrabilityHeuristic), null), &objT->PenetrabilityHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateOverrunEarlyHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(AIStateOverrunEarlyHeuristic.MiddleGameHeuristic), null), &objT->MiddleGameHeuristic, state);
        Marshal(node.GetChildNode(nameof(AIStateOverrunEarlyHeuristic.LateGameHeuristic), null), &objT->LateGameHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateOverrunMiddleHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(AIStateOverrunMiddleHeuristic.MiddleGameHeuristic), null), &objT->MiddleGameHeuristic, state);
        Marshal(node.GetChildNode(nameof(AIStateOverrunMiddleHeuristic.LateGameHeuristic), null), &objT->LateGameHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateOverrunLateHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(AIStateOverrunLateHeuristic.LateGameHeuristic), null), &objT->LateGameHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStatePowerCutHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(AIStatePowerCutHeuristic.OpponentPowerThresholdHeuristic), null), &objT->OpponentPowerThresholdHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateEmergencyHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateEmergencyHeuristic.Threshold), null), &objT->Threshold, state);
        Marshal(node.GetChildNode(nameof(AIStateEmergencyHeuristic.VulnerabilityHeuristic), null), &objT->VulnerabilityHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateScriptedFlagHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateScriptedFlagHeuristic.FlagName), null), &objT->FlagName, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIAlliedBeaconExistsHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateLinearCombinationHeuristicWeightedHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateLinearCombinationHeuristicWeightedHeuristic.Weight), "0.5"), &objT->Weight, state);
        Marshal(node.GetChildNode(nameof(AIStateLinearCombinationHeuristicWeightedHeuristic.Heuristic), null), &objT->Heuristic, state);
    }

    public static unsafe void Marshal(Node node, AIStateLinearCombinationHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(AIStateLinearCombinationHeuristic.WeightedHeuristic)), &objT->WeightedHeuristic, state);
        Marshal(node, (AIStateHeuristic*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateHeuristic** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x0742367Au:
                MarshalPolymorphicType<AIStateLinearCombinationHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x7E198900u:
                MarshalPolymorphicType<AIAlliedBeaconExistsHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x809071B7u:
                MarshalPolymorphicType<AIStateScriptedFlagHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x40ACAEB1u:
                MarshalPolymorphicType<AIStateEmergencyHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x6DCD6804u:
                MarshalPolymorphicType<AIStatePowerCutHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x9A81B1C2u:
                MarshalPolymorphicType<AIStateOverrunLateHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x838D8D60u:
                MarshalPolymorphicType<AIStateOverrunMiddleHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x454F1B57u:
                MarshalPolymorphicType<AIStateOverrunEarlyHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xDDA88778u:
                MarshalPolymorphicType<AIStateBaseCrackHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xAAB3B590u:
                MarshalPolymorphicType<AIStateProductionHaltHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x5F4CFC12u:
                MarshalPolymorphicType<AIStateResourceSqueezeHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x63E499EAu:
                MarshalPolymorphicType<AIStateOverpowerHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x5737AD52u:
                MarshalPolymorphicType<AIStateSuperweaponHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xBBE510A3u:
                MarshalPolymorphicType<AIStateBridgeExistsHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x4B9B49C6u:
                MarshalPolymorphicType<AIStateProductionAdvantageHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xD5C158B4u:
                MarshalPolymorphicType<AIStateLateGameHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x9AA43A61u:
                MarshalPolymorphicType<AIStateMiddleGameHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x2499489Bu:
                MarshalPolymorphicType<AIStateOpponentPowerThresholdHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xF0AA4D07u:
                MarshalPolymorphicType<AIStateOpponentFundsHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x15BD7C6Au:
                MarshalPolymorphicType<AIStateOpponentAAPowerHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x2178871Au:
                MarshalPolymorphicType<AIStateVulnerabilityHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x72938ABFu:
                MarshalPolymorphicType<AIStatePenetrabilityHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xADC0BB89u:
                MarshalPolymorphicType<AIStatePowerAdvantageHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xB13353A0u:
                MarshalPolymorphicType<AIStateBalanceOfPowerHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x436ADF4Bu:
                MarshalPolymorphicType<AIStateSiegeThresholdHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xDAD3D523u:
                MarshalPolymorphicType<AIStateSpreadThresholdHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x3945A4A3u:
                MarshalPolymorphicType<AIStateFocusedThresholdHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x67B985A7u:
                MarshalPolymorphicType<AIStateEnemyNearbyHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xED25898Du:
                MarshalPolymorphicType<AIStateCounterattackHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0xF1B0E2B3u:
                MarshalPolymorphicType<AIStatePathToTargetHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x1623F8FCu:
                MarshalPolymorphicType<AIStateAntiGarrisonTechHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x76575914u:
                MarshalPolymorphicType<AIStateFullTechHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x572376ABu:
                MarshalPolymorphicType<AIStateFullInvestmentHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x0482969Eu:
                MarshalPolymorphicType<AIStateMoneyHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x8E448434u:
                MarshalPolymorphicType<AIStateHarvesterCapHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x7EE4C9B4u:
                MarshalPolymorphicType<AIStateOpeningMoveHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x8199E979u:
                MarshalPolymorphicType<AIStateIntervalHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x51FB6D92u:
                MarshalPolymorphicType<AIStateConstantHeuristic, AIStateHeuristic>(node, objT, state);
                break;
            case 0x10A03AC0u:
                MarshalPolymorphicType<AIStateTimerHeuristic, AIStateHeuristic>(node, objT, state);
                break;
        }
    }

    public static unsafe void Marshal(Node node, AIStateDefinition* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(AIStateDefinition.Heuristic), null), &objT->Heuristic, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, StateTargetHeuristic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StateTargetHeuristic.TargetHeuristic), null), &objT->TargetHeuristic, state);
        Marshal(node.GetAttributeValue(nameof(StateTargetHeuristic.WeightMultiplier), "1.0"), &objT->WeightMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(StateTargetHeuristic.TargetType), null), &objT->TargetType, state);
    }

    public static unsafe void Marshal(Node node, AIStateTactic* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateTactic.Tactic), null), &objT->Tactic, state);
        Marshal(node.GetAttributeValue(nameof(AIStateTactic.TargetType), null), &objT->TargetType, state);
        Marshal(node.GetAttributeValue(nameof(AIStateTactic.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
        Marshal(node.GetChildNodes(nameof(AIStateTactic.TeamTemplate)), &objT->TeamTemplate, state);
    }

    public static unsafe void Marshal(Node node, AIStateUnitBuilderModifier* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateUnitBuilderModifier.UnitBonus), "10"), &objT->UnitBonus, state);
        Marshal(node.GetAttributeValue(nameof(AIStateUnitBuilderModifier.UnitPreferenceOffensiveModifier), "100%"), &objT->UnitPreferenceOffensiveModifier, state);
        Marshal(node.GetAttributeValue(nameof(AIStateUnitBuilderModifier.UnitPreferenceDefensiveModifier), "100%"), &objT->UnitPreferenceDefensiveModifier, state);
        Marshal(node.GetAttributeValue(nameof(AIStateUnitBuilderModifier.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIStateUnitKindofModifier* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateUnitKindofModifier.UnitKind), null), &objT->UnitKind, state);
        Marshal(node, (AIStateUnitBuilderModifier*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateUnitModifier* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateUnitModifier.UnitName), null), &objT->UnitName, state);
        Marshal(node, (AIStateUnitBuilderModifier*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIStateUnitOverride* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStateUnitOverride.UnitName), null), &objT->UnitName, state);
        Marshal(node.GetAttributeValue(nameof(AIStateUnitOverride.Percentage), "100%"), &objT->Percentage, state);
        Marshal(node.GetAttributeValue(nameof(AIStateUnitOverride.Difficulty), "EASY MEDIUM HARD BRUTAL"), &objT->Difficulty, state);
    }

    public static unsafe void Marshal(Node node, AIStrategicStateDefinition* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIStrategicStateDefinition.UnitUpgradeMultiplier), "1.0"), &objT->UnitUpgradeMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(AIStrategicStateDefinition.UnitBuilderCostEffectivenessWeight), null), &objT->UnitBuilderCostEffectivenessWeight, state);
        Marshal(node.GetAttributeValue(nameof(AIStrategicStateDefinition.UnitBuilderMoneyVersusTimePreference), null), &objT->UnitBuilderMoneyVersusTimePreference, state);
        Marshal(node.GetAttributeValue(nameof(AIStrategicStateDefinition.UnitBuilderOverallOffensivePreference), null), &objT->UnitBuilderOverallOffensivePreference, state);
        Marshal(node.GetAttributeValue(nameof(AIStrategicStateDefinition.UnitBuilderOverallDefensivePreference), null), &objT->UnitBuilderOverallDefensivePreference, state);
        Marshal(node.GetAttributeValue(nameof(AIStrategicStateDefinition.UnitBuilderEnemyTowerWeight), null), &objT->UnitBuilderEnemyTowerWeight, state);
        Marshal(node.GetAttributeValue(nameof(AIStrategicStateDefinition.UnitBuilderSimpleUnitCap), null), &objT->UnitBuilderSimpleUnitCap, state);
        Marshal(node.GetChildNodes(nameof(AIStrategicStateDefinition.TargetHeuristic)), &objT->TargetHeuristic, state);
        Marshal(node.GetChildNodes(nameof(AIStrategicStateDefinition.Tactic)), &objT->Tactic, state);
        Marshal(node.GetChildNodes(nameof(AIStrategicStateDefinition.UnitModifierByKind)), &objT->UnitModifierByKind, state);
        Marshal(node.GetChildNodes(nameof(AIStrategicStateDefinition.UnitModifierByName)), &objT->UnitModifierByName, state);
        Marshal(node.GetChildNodes(nameof(AIStrategicStateDefinition.UnitOverride)), &objT->UnitOverride, state);
        Marshal(node, (AIStateDefinition*)objT, state);
    }

    public static unsafe void Marshal(Node node, AIBudgetStateDefinition* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(AIBudgetStateDefinition.Budget), null), &objT->Budget, state);
        Marshal(node, (AIStateDefinition*)objT, state);
    }
}
