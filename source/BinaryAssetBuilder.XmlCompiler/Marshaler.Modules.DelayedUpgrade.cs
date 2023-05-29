using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DelayedUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DelayedUpgradeModuleData.DelayTime), "0"), &objT->DelayTime, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
