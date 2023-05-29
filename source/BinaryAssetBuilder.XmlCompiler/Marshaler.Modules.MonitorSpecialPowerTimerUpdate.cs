using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MonitorSpecialPowerTimerUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MonitorSpecialPowerTimerUpdateModuleData.SpecialPowerTemplate), null), &objT->SpecialPowerTemplate, state);
        Marshal(node.GetAttributeValue(nameof(MonitorSpecialPowerTimerUpdateModuleData.ReadyCondition), null), &objT->ReadyCondition, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
