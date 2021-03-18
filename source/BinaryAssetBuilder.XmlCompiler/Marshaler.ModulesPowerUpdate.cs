using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, PowerUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PowerUpdateModuleData.UpdatePeriod), "1s"), &objT->UpdatePeriod, state);
        Marshal(node.GetAttributeValue(nameof(PowerUpdateModuleData.ReloadTime), "0s"), &objT->ReloadTime, state);
        Marshal(node.GetAttributeValue(nameof(PowerUpdateModuleData.Duration), "0s"), &objT->Duration, state);
        Marshal(node.GetAttributeValue(nameof(PowerUpdateModuleData.Type), "INVALID"), &objT->Type, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
