using Relo;
using SageBinaryData;
using SageBinaryData.Shell;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentBootup* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentBootup.RenderImageName), null), &objT->RenderImageName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentBootup.LoadingTextImageName), null), &objT->LoadingTextImageName, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}