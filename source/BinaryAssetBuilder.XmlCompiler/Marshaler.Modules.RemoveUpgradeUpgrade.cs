using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RemoveUpgradeUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RemoveUpgradeUpgradeModuleData.UpradesGroupsToRemove), null), &objT->UpradesGroupsToRemove, state);
        Marshal(node.GetAttributeValue(nameof(RemoveUpgradeUpgradeModuleData.SuppressEvaEventForRemoval), "false"), &objT->SuppressEvaEventForRemoval, state);
        Marshal(node.GetAttributeValue(nameof(RemoveUpgradeUpgradeModuleData.RemoveFromAllPlayerObjects), "false"), &objT->RemoveFromAllPlayerObjects, state);
        Marshal(node.GetChildNodes(nameof(RemoveUpgradeUpgradeModuleData.UpgradeToRemove)), &objT->UpgradeToRemove, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
