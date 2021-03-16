using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CrateCollideModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.KindOf), null), &objT->KindOf, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.KindOfNot), null), &objT->KindOfNot, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.IsForbidOwnerPlayer), "false"), &objT->IsForbidOwnerPlayer, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.IsBuildingPickup), "false"), &objT->IsBuildingPickup, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.IsHumanOnlyPickup), "false"), &objT->IsHumanOnlyPickup, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.IsHumanOnlyPickupInSinglePlayerCampaign), "true"), &objT->IsHumanOnlyPickupInSinglePlayerCampaign, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.PickupScience), null), &objT->PickupScience, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.ExecuteFX), null), &objT->ExecuteFX, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.ExecutionAnimationTemplate), null), &objT->ExecutionAnimationTemplate, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.ExecuteAnimationDisplayTimeInSeconds), "0"), &objT->ExecuteAnimationDisplayTimeInSeconds, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.ExecuteAnimationZRisePerSecond), "0"), &objT->ExecuteAnimationZRisePerSecond, state);
        Marshal(node.GetAttributeValue(nameof(CrateCollideModuleData.ExecuteAnimationFades), "false"), &objT->ExecuteAnimationFades, state);
        Marshal(node, (CollideModuleData*)objT, state);
    }
}
