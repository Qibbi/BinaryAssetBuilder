using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RadarHackSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RadarHackSpecialPowerModuleData.NumFalseReturns), "0"), &objT->NumFalseReturns, state);
        Marshal(node.GetAttributeValue(nameof(RadarHackSpecialPowerModuleData.Radius), "0.0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(RadarHackSpecialPowerModuleData.HackDuration), "0s"), &objT->HackDuration, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
