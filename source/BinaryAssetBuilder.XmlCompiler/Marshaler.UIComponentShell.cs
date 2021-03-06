using Relo;
using SageBinaryData;
using SageBinaryData.Shell;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentShell* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentShell.LoadMusic), null), &objT->LoadMusic, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}