using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TransportHelicopterAIUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TransportHelicopterAIUpdateModuleData.FlyOffMapOnUnload), "false"), &objT->FlyOffMapOnUnload, state);
        Marshal(node.GetAttributeValue(nameof(TransportHelicopterAIUpdateModuleData.FlyOffMap), "REVERSE_DIRECTION"), &objT->FlyOffMap, state);
        Marshal(node.GetAttributeValue(nameof(TransportHelicopterAIUpdateModuleData.DelayAFterLoadingOrUnloading), "0s"), &objT->DelayAFterLoadingOrUnloading, state);
        Marshal(node, (SupplyTruckAIUpdateModuleData*)objT, state);
    }
}
