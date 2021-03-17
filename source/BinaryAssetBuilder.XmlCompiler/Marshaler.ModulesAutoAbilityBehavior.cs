using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, Query* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Query.EMax), "6"), &objT->EMax, state);
        Marshal(node.GetAttributeValue(nameof(Query.Value), "-1"), &objT->Value, state);
        Marshal(node.GetChildNode(nameof(Query.ObjectFilter), null), &objT->ObjectFilter, state);
    }

    public static unsafe void Marshal(Node node, AutoAbilityBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.MaxScanRange), "1"), &objT->MaxScanRange, state);
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.MinScanRange), "0"), &objT->MinScanRange, state);
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.IdleSeconds), "0s"), &objT->IdleSeconds, state);
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.SpecialAbilityName), null), &objT->SpecialAbilityName, state);
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.ForbiddenStatus), null), &objT->ForbiddenStatus, state);
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.StartsActive), "false"), &objT->StartsActive, state);
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.UseStartPosition), "false"), &objT->UseStartPosition, state);
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.AdjustAttackPos), "false"), &objT->AdjustAttackPos, state);
        Marshal(node.GetAttributeValue(nameof(AutoAbilityBehaviorModuleData.AllowSelf), "false"), &objT->AllowSelf, state);
        Marshal(node.GetChildNodes(nameof(AutoAbilityBehaviorModuleData.Queries)), &objT->Queries, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
