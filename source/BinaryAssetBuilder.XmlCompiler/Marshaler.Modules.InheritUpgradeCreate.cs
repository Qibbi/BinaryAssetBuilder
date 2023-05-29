using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InheritUpgradeCreateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InheritUpgradeCreateModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetChildNode(nameof(InheritUpgradeCreateModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node.GetChildNodes(nameof(InheritUpgradeCreateModuleData.Upgrade)), &objT->Upgrade, state);
        Marshal(node, (CreateModuleData*)objT, state);
    }
}
