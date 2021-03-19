using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DPropDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DPropDrawModuleData.Model), null), &objT->Model, state);
        Marshal(node.GetAttributeValue(nameof(W3DPropDrawModuleData.DistanceFog), "true"), &objT->DistanceFog, state);
        Marshal(node, (DrawModuleData*)objT, state);
    }
}