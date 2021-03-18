using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TunnelContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TunnelContainModuleData.DeleteRemoved), "false"), &objT->DeleteRemoved, state);
        Marshal(node.GetAttributeValue(nameof(TunnelContainModuleData.TunnelMasterObject), null), &objT->TunnelMasterObject, state);
        Marshal(node, (HordeGarrisonContainModuleData*)objT, state);
    }
}
