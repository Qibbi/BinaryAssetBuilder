using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ButtonState* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ButtonState.Image), null), &objT->Image, state);
        Marshal(node.GetAttributeValue(nameof(ButtonState.Title), null), &objT->Title, state);
        Marshal(node.GetAttributeValue(nameof(ButtonState.Description), null), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(ButtonState.TypeDescription), null), &objT->TypeDescription, state);
    }
}
