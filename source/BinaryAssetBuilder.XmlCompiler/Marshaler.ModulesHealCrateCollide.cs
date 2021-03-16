using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HealCrateCollideModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HealCrateCollideModuleData.Range), "75"), &objT->Range, state);
        Marshal(node.GetChildNode(nameof(HealCrateCollideModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (CrateCollideModuleData*)objT, state);
    }
}
