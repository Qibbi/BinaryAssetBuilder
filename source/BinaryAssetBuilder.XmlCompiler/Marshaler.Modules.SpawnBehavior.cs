using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SpawnBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.SpawnNumberData), "0"), &objT->SpawnNumberData, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.SpawnReplaceDelayData), "0s"), &objT->SpawnReplaceDelayData, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.InitialBurst), "0"), &objT->InitialBurst, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.IsOneShotData), "false"), &objT->IsOneShotData, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.CanReclaimOrphans), "false"), &objT->CanReclaimOrphans, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.AggregateHealth), "false"), &objT->AggregateHealth, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.ExitByBudding), "false"), &objT->ExitByBudding, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.SpawnedRequireSpawner), "false"), &objT->SpawnedRequireSpawner, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.RespectCommandLimit), "false"), &objT->RespectCommandLimit, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.DamageTypesToPropagateToSlaves), "ALL"), &objT->DamageTypesToPropagateToSlaves, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.FadeInTime), "0s"), &objT->FadeInTime, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.KillSpawnBasedOnModelConditionState), "false"), &objT->KillSpawnBasedOnModelConditionState, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.ShareUpgrades), "false"), &objT->ShareUpgrades, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.SpawnInsideBuilding), "false"), &objT->SpawnInsideBuilding, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.InitialDelay), "0s"), &objT->InitialDelay, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.CombineOnCreate), "false"), &objT->CombineOnCreate, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.KillSpawnsOnDisabled), "false"), &objT->KillSpawnsOnDisabled, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.PassExperienceToSpawned), "false"), &objT->PassExperienceToSpawned, state);
        Marshal(node.GetAttributeValue(nameof(SpawnBehaviorModuleData.KillSpawnsOnCaptured), "false"), &objT->KillSpawnsOnCaptured, state);
        Marshal(node.GetChildNode(nameof(SpawnBehaviorModuleData.Die), null), &objT->Die, state);
        Marshal(node.GetChildNodes(nameof(SpawnBehaviorModuleData.SpawnTemplate)), &objT->SpawnTemplate, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
