using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FontDesc* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FontDesc.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(FontDesc.Size), null), &objT->Size, state);
        Marshal(node.GetAttributeValue(nameof(FontDesc.Bold), null), &objT->Bold, state);
    }
}