using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GatherSlavesUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GatherSlavesUpdateModuleData.SlaveTemplate), null), &objT->SlaveTemplate, state);
        Marshal(node.GetAttributeValue(nameof(GatherSlavesUpdateModuleData.Radius), null), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(GatherSlavesUpdateModuleData.Amount), null), &objT->Amount, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
