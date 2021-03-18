using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StorePurchasedUpgradeBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StorePurchasedUpgradeBehaviorModuleData.MaxPlayerUpgrades), "9999"), &objT->MaxPlayerUpgrades, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
