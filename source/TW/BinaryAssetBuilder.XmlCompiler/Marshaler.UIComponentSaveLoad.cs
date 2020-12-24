using Relo;
using SageBinaryData;
using SageBinaryData.Shell;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentSaveLoad* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentSaveLoad.FileToken), null), &objT->FileToken, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}