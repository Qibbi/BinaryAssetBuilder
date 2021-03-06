using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BootupDisplayItem* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BootupDisplayItem.Type), null), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(BootupDisplayItem.Duration), null), &objT->Duration, state);
        Marshal(node.GetAttributeValue(nameof(BootupDisplayItem.Priority), null), &objT->Priority, state);
        Marshal(node.GetAttributeValue(nameof(BootupDisplayItem.ShowOnReboot), null), &objT->ShowOnReboot, state);
        Marshal(node.GetChildNodes(nameof(BootupDisplayItem.RandomTexture)), &objT->RandomTexture, state);
        Marshal(node.GetChildNode(nameof(BootupDisplayItem.Movie), null), &objT->Movie, state);
    }

    public static unsafe void Marshal(Node node, BootupDisplaySequence* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BootupDisplaySequence.LoadingTextTexture), null), &objT->LoadingTextTexture, state);
        Marshal(node.GetChildNodes(nameof(BootupDisplaySequence.DisplayItem)), &objT->DisplayItem, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}