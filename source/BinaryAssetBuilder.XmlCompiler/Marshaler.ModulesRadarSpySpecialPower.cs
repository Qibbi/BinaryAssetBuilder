using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RadarSpySpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RadarSpySpecialPowerModuleData.TargetFilter), null), &objT->TargetFilter, state);
        Marshal(node.GetAttributeValue(nameof(RadarSpySpecialPowerModuleData.SpyDuration), "0s"), &objT->SpyDuration, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
