using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AIUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.AttackPriority), null), &objT->AttackPriority, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.AutoAcquireEnemiesWhenIdle), null), &objT->AutoAcquireEnemiesWhenIdle, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.StopChaseDistance), "500.0"), &objT->StopChaseDistance, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.StandGround), "false"), &objT->StandGround, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.CanAttackWhileContained), "false"), &objT->CanAttackWhileContained, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.HoldGroundCloseRangeDistance), "0.0"), &objT->HoldGroundCloseRangeDistance, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.AILuaEventsList), null), &objT->AILuaEventsList, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.MinCowerTime), "0s"), &objT->MinCowerTime, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.MaxCowerTime), "0s"), &objT->MaxCowerTime, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.RampageTime), "0s"), &objT->RampageTime, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.RampageRequiresAflame), "false"), &objT->RampageRequiresAflame, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.BurningDeathTime), null), &objT->BurningDeathTime, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.TimeToEjectPassengersOnRampage), "0"), &objT->TimeToEjectPassengersOnRampage, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.ComboLocomotorSet), null), &objT->ComboLocomotorSet, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.ComboLocoAttackDistance), "80"), &objT->ComboLocoAttackDistance, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.SpecialContactPoints), null), &objT->SpecialContactPoints, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.FadeOnPortals), "false"), &objT->FadeOnPortals, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.IdleTargetTime), "0s"), &objT->IdleTargetTime, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.MaxCombineChildren), "1"), &objT->MaxCombineChildren, state);
        Marshal(node.GetAttributeValue(nameof(AIUpdateModuleData.SpawnOffsetRadius), "0.0"), &objT->SpawnOffsetRadius, state);
        Marshal(node.GetChildNode(nameof(AIUpdateModuleData.UnitAITargetChooserData), null), &objT->UnitAITargetChooserData, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
