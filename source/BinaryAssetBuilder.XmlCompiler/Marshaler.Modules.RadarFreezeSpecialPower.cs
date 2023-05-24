using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RadarFreezeSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RadarFreezeSpecialPowerModuleData.TargetFilter), null), &objT->TargetFilter, state);
        Marshal(node.GetAttributeValue(nameof(RadarFreezeSpecialPowerModuleData.FreezeDuration), "0s"), &objT->FreezeDuration, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
