using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AIGateUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIGateUpdateModuleData.TriggerWidthX), "0"), &objT->TriggerWidthX, state);
        Marshal(node.GetAttributeValue(nameof(AIGateUpdateModuleData.TriggerWidthY), "0"), &objT->TriggerWidthY, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
