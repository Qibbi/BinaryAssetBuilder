using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UpgradeTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.DisplayName), null), &objT->DisplayName, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.Description), null), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.TypeDescription), null), &objT->TypeDescription, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.AcquireHint), null), &objT->AcquireHint, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.Type), null), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.BuildTime), null), &objT->BuildTime, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.BuildCost), null), &objT->BuildCost, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.ResearchSound), null), &objT->ResearchSound, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.ResearchCompleteEvaEvent), null), &objT->ResearchCompleteEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.UnitSpecificSound), null), &objT->UnitSpecificSound, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.UpgradeFX), null), &objT->UpgradeFX, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.LocalPlayerGainsUpgradeEvaEvent), null), &objT->LocalPlayerGainsUpgradeEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.AlliedPlayerGainsUpgradeEvaEvent), null), &objT->AlliedPlayerGainsUpgradeEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.EnemyPlayerGainsUpgradeEvaEvent), null), &objT->EnemyPlayerGainsUpgradeEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.LocalPlayerLosesUpgradeEvaEvent), null), &objT->LocalPlayerLosesUpgradeEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.AlliedPlayerLosesUpgradeEvaEvent), null), &objT->AlliedPlayerLosesUpgradeEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.EnemyPlayerLosesUpgradeEvaEvent), null), &objT->EnemyPlayerLosesUpgradeEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.LocalPlayerProductionStartedEvaEvent), null), &objT->LocalPlayerProductionStartedEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.LocalPlayerBuildOnHoldEvaEvent), null), &objT->LocalPlayerBuildOnHoldEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.LocalPlayerBuildCancelledEvaEvent), null), &objT->LocalPlayerBuildCancelledEvaEvent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.UseObjectTemplateForCostDiscount), null), &objT->UseObjectTemplateForCostDiscount, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.GroupName), null), &objT->GroupName, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.GroupOrder), null), &objT->GroupOrder, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.SkirmishAIHeuristic), null), &objT->SkirmishAIHeuristic, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.Options), null), &objT->Options, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.IconImage), null), &objT->IconImage, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeTemplate.WaypointQueueable), null), &objT->WaypointQueueable, state);
        Marshal(node.GetChildNode(nameof(UpgradeTemplate.GameDependency), null), &objT->GameDependency, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
