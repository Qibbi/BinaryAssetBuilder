using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HotKeySlot* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HotKeySlot.Group), null), &objT->Group, state);
        Marshal(node.GetAttributeValue(nameof(HotKeySlot.Index), null), &objT->Index, state);
        Marshal(node.GetAttributeValue(nameof(HotKeySlot.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(HotKeySlot.VersionAdded), "1"), &objT->VersionAdded, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
