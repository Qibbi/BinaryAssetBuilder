using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LogicCommand* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LogicCommand.Type), "NONE"), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(LogicCommand.Options), null), &objT->Options, state);
        Marshal(node.GetChildNode(nameof(LogicCommand.SpecialPower), null), &objT->SpecialPower, state);
        Marshal(node.GetChildNode(nameof(LogicCommand.Upgrade), null), &objT->Upgrade, state);
        Marshal(node.GetChildNode(nameof(LogicCommand.Object), null), &objT->Object, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}