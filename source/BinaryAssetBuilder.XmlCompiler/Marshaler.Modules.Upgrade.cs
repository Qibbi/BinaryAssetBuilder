using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UpgradeModuleData.RequiresAllTriggers), "false"), &objT->RequiresAllTriggers, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeModuleData.RequiresAllConflictingTriggers), "false"), &objT->RequiresAllConflictingTriggers, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeModuleData.Permanent), "false"), &objT->Permanent, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeModuleData.WaypointMode), "false"), &objT->WaypointMode, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeModuleData.WaypointModeTerminal), "true"), &objT->WaypointModeTerminal, state);
        Marshal(node.GetChildNode(nameof(UpgradeModuleData.CustomAnimAndDuration), null), &objT->CustomAnimAndDuration, state);
        Marshal(node.GetChildNodes(nameof(UpgradeModuleData.TriggeredBy)), &objT->TriggeredBy, state);
        Marshal(node.GetChildNodes(nameof(UpgradeModuleData.ConflictsWith)), &objT->ConflictsWith, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
