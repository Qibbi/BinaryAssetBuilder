using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GrantUpgradeCreateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GrantUpgradeCreateModuleData.UpgradeToGrant), null), &objT->UpgradeToGrant, state);
        Marshal(node.GetAttributeValue(nameof(GrantUpgradeCreateModuleData.ExemptStatus), null), &objT->ExemptStatus, state);
        Marshal(node.GetAttributeValue(nameof(GrantUpgradeCreateModuleData.GiveOnBuildComplete), "false"), &objT->GiveOnBuildComplete, state);
        Marshal(node, (CreateModuleData*)objT, state);
    }
}
