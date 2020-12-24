using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CommandButton* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CommandButton.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(CommandButton.Index), null), &objT->Index, state);
        Marshal(node.GetChildNode(nameof(CommandButton.InitialDelay), null), &objT->InitialDelay, state);
    }

    public static unsafe void Marshal(Node node, CommandSet* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CommandSet.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(CommandSet.InitialVisible), "32"), &objT->InitialVisible, state);
        Marshal(node.GetChildNodes(nameof(CommandSet.CommandButton)), &objT->CommandButton, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}