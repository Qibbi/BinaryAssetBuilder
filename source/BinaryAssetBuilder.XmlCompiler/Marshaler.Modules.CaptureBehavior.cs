using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CaptureBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CaptureBehaviorModuleData.GrantMoney), "0"), &objT->GrantMoney, state);
        Marshal(node.GetAttributeValue(nameof(CaptureBehaviorModuleData.GrantMoneyOneTime), "false"), &objT->GrantMoneyOneTime, state);
        Marshal(node.GetAttributeValue(nameof(CaptureBehaviorModuleData.SlavedCaptureObject), null), &objT->SlavedCaptureObject, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
