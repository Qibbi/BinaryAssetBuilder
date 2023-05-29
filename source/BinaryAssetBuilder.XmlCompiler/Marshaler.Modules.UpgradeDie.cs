using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UpgradeDieModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UpgradeDieModuleData.UpgradeId), null), &objT->UpgradeId, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
