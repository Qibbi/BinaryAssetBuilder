using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StatusBitsUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StatusBitsUpgradeModuleData.StatusToSet), null), &objT->StatusToSet, state);
        Marshal(node.GetAttributeValue(nameof(StatusBitsUpgradeModuleData.StatusToClear), null), &objT->StatusToClear, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
