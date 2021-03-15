using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DozerAIUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DozerAIUpdateModuleData.RepairHealthPercentPerSecond), "0"), &objT->RepairHealthPercentPerSecond, state);
        Marshal(node.GetAttributeValue(nameof(DozerAIUpdateModuleData.BoredTime), "0"), &objT->BoredTime, state);
        Marshal(node.GetAttributeValue(nameof(DozerAIUpdateModuleData.BoredRange), "0"), &objT->BoredRange, state);
        Marshal(node, (AIUpdateModuleData*)objT, state);
    }
}
