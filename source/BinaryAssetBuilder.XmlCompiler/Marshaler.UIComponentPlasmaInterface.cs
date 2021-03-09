using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentPlasmaInterface* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}