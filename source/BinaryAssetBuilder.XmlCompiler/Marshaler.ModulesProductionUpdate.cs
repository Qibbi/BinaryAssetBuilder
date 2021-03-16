using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, QuantityModifier* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(QuantityModifier.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(QuantityModifier.Count), null), &objT->Count, state);
    }
    public static unsafe void Marshal(Node node, ProductionModifier* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ProductionModifier.RequiredUpgrade), null), &objT->RequiredUpgrade, state);
        Marshal(node.GetAttributeValue(nameof(ProductionModifier.CostMultiplier), "1.0"), &objT->CostMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(ProductionModifier.TimeMultiplier), "1.0"), &objT->TimeMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(ProductionModifier.HeroPurchase), "false"), &objT->HeroPurchase, state);
        Marshal(node.GetAttributeValue(nameof(ProductionModifier.HeroRevive), "false"), &objT->HeroRevive, state);
        Marshal(node.GetChildNode(nameof(ProductionModifier.ModifierFilter), null), &objT->ModifierFilter, state);
    }

    public static unsafe void Marshal(Node node, ProductionUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.MaxQueueEntries), "99"), &objT->MaxQueueEntries, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.NumDoorAnimations), "0"), &objT->NumDoorAnimations, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.DoorOpeningTime), "0s"), &objT->DoorOpeningTime, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.DoorWaitOpenTime), "0s"), &objT->DoorWaitOpenTime, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.DoorCloseTime), "0s"), &objT->DoorCloseTime, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.ConstructionCompleteDuration), "0"), &objT->ConstructionCompleteDuration, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.DisabledTypesToProcess), null), &objT->DisabledTypesToProcess, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.GiveNoXP), "false"), &objT->GiveNoXP, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.UnitInvulnerableTime), "0"), &objT->UnitInvulnerableTime, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.SpecialPrepModelconditionTime), "0"), &objT->SpecialPrepModelconditionTime, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.VeteranUnitsFromVeteranFactory), "false"), &objT->VeteranUnitsFromVeteranFactory, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.SetBonusModelConditionOnSpeedBonus), "false"), &objT->SetBonusModelConditionOnSpeedBonus, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.BonusForType), null), &objT->BonusForType, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.SpeedBonusAudioLoop), null), &objT->SpeedBonusAudioLoop, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.SecondaryQueue), "false"), &objT->SecondaryQueue, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.Type), "INVALID"), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.IgnorePreReqs), "false"), &objT->IgnorePreReqs, state);
        Marshal(node.GetAttributeValue(nameof(ProductionUpdateModuleData.ProductionTimeDelayScalar), "0s"), &objT->ProductionTimeDelayScalar, state);
        Marshal(node.GetChildNodes(nameof(ProductionUpdateModuleData.QuantityModifier)), &objT->QuantityModifier, state);
        Marshal(node.GetChildNodes(nameof(ProductionUpdateModuleData.ProductionModifier)), &objT->ProductionModifier, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
