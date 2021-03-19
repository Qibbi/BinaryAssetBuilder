using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DBuffDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DBuffDrawModuleData.Model), null), &objT->Model, state);
        Marshal(node.GetAttributeValue(nameof(W3DBuffDrawModuleData.PreDraw), "true"), &objT->PreDraw, state);
        Marshal(node, (DrawModuleData*)objT, state);
    }
}