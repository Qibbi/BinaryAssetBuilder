using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, OCLMonitorUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(OCLMonitorUpdateModuleData.Options), null), &objT->Options, state);
        Marshal(node.GetAttributeValue(nameof(OCLMonitorUpdateModuleData.RequiredMasterObjectStatus), null), &objT->RequiredMasterObjectStatus, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
