using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HotKeyDef* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HotKeyDef.Slot), null), &objT->Slot, state);
        Marshal(node.GetAttributeValue(nameof(HotKeyDef.Key), null), &objT->Key, state);
        Marshal(node.GetAttributeValue(nameof(HotKeyDef.Modifiers), null), &objT->Modifiers, state);
    }

    public static unsafe void Marshal(Node node, HotKeyMap* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(HotKeyMap.HotKey)), &objT->HotKey, state);
    }

    public static unsafe void Marshal(Node node, DefaultHotKeys* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(DefaultHotKeys.Map), null), &objT->Map, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
