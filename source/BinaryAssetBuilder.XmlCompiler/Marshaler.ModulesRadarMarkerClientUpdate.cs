using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RadarMarkerClientUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RadarMarkerClientUpdateModuleData.TypeName), null), &objT->TypeName, state);
        Marshal(node, (ClientUpdateModuleData*)objT, state);
    }
}
