using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RefundDieModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RefundDieModuleData.UpgradeRequired), null), &objT->UpgradeRequired, state);
        Marshal(node.GetAttributeValue(nameof(RefundDieModuleData.BuildingRequired), null), &objT->BuildingRequired, state);
        Marshal(node.GetAttributeValue(nameof(RefundDieModuleData.RefundPercent), "0"), &objT->RefundPercent, state);
        Marshal(node.GetChildNode(nameof(RefundDieModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
