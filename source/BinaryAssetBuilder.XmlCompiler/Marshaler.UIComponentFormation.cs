using Relo;
using SageBinaryData;
using SageBinaryData.InGameUI;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentFormation* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentFormation.MaxDragLength), null), &objT->MaxDragLength, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}