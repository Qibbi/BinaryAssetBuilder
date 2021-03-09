using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentStats* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentStats.PlayerToken), null), &objT->PlayerToken, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentStats.TitleToken), null), &objT->TitleToken, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentStats.DataToken), null), &objT->DataToken, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}