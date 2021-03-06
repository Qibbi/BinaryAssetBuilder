using Relo;
using SageBinaryData;
using SageBinaryData.InGameUI;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentInGameShowHide* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}