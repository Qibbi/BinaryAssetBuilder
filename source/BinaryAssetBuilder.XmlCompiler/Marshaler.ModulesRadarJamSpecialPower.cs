using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RadarJamSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RadarJamSpecialPowerModuleData.JamRadius), "0.0"), &objT->JamRadius, state);
        Marshal(node.GetAttributeValue(nameof(RadarJamSpecialPowerModuleData.JamDuration), "0s"), &objT->JamDuration, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
