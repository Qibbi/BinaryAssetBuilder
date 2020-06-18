using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InGameUIFixedElementHotKeySlotMapEntry* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIFixedElementHotKeySlotMapEntry.ElementId), null), &objT->ElementId, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIFixedElementHotKeySlotMapEntry.HotKeySlot), null), &objT->HotKeySlot, state);
    }

    public static unsafe void Marshal(Node node, InGameUIFixedElementHotKeySlotMap* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(InGameUIFixedElementHotKeySlotMap.Entry)), &objT->Entry, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}