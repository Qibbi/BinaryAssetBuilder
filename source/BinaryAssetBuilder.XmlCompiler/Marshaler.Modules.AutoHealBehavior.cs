using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AutoHealBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.InitiallyActive), "false"), &objT->InitiallyActive, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.HealingAmount), "0"), &objT->HealingAmount, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.HealingDelay), "0s"), &objT->HealingDelay, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.StartHealingDelay), "0s"), &objT->StartHealingDelay, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.AffectsWholePlayer), "false"), &objT->AffectsWholePlayer, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.AffectsContained), "false"), &objT->AffectsContained, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.HealOnlyIfNotUnderAttack), "false"), &objT->HealOnlyIfNotUnderAttack, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.HealOnlyIfNotInCombat), "false"), &objT->HealOnlyIfNotInCombat, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.KindOf), null), &objT->KindOf, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.HealOnlyOthers), "false"), &objT->HealOnlyOthers, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.HealFXList), null), &objT->HealFXList, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.SpawnFXList), null), &objT->SpawnFXList, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.NonStackable), "false"), &objT->NonStackable, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.RespawnNearbyHordeMembers), "false"), &objT->RespawnNearbyHordeMembers, state);
        Marshal(node.GetAttributeValue(nameof(AutoHealBehaviorModuleData.RespawnMinimumDelay), "0s"), &objT->RespawnMinimumDelay, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
