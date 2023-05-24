using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HordeTransportContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HordeTransportContainModuleData.FlyOffMapOnEmpty), "false"), &objT->FlyOffMapOnEmpty, state);
        Marshal(node, (TransportContainModuleData*)objT, state);
    }
}
