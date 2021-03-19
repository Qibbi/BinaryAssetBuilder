using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BeaconClientUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BeaconClientUpdateModuleData.FramesBetweenRadarPulses), "0"), &objT->FramesBetweenRadarPulses, state);
        Marshal(node.GetAttributeValue(nameof(BeaconClientUpdateModuleData.RadarPulseDuration), "0"), &objT->RadarPulseDuration, state);
        Marshal(node, (ClientUpdateModuleData*)objT, state);
    }
}
