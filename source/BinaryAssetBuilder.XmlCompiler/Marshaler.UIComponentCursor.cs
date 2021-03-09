using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentCursor* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentCursor.AptEventCursorChanged), null), &objT->AptEventCursorChanged, state);
        Marshal(node.GetChildNode(nameof(UIComponentCursor.DecalCloud), null), &objT->DecalCloud, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}