using Relo;
using SageBinaryData;
using SageBinaryData.Shell;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentMovie* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentMovie.MovieComponentName), null), &objT->MovieComponentName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMovie.MaxNumberOfStream), "3"), &objT->MaxNumberOfStream, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}