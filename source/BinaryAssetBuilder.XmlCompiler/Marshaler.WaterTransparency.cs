using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, WaterTransparency* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WaterTransparency.TransparentWaterDepth), "3.0"), &objT->TransparentWaterDepth, state);
        Marshal(node.GetAttributeValue(nameof(WaterTransparency.TransparentWaterMinOpacity), "1.0"), &objT->TransparentWaterMinOpacity, state);
        Marshal(node.GetAttributeValue(nameof(WaterTransparency.StandingWaterTexture), null), &objT->StandingWaterTexture, state);
        Marshal(node.GetAttributeValue(nameof(WaterTransparency.AdditiveBlending), "false"), &objT->AdditiveBlending, state);
        Marshal(node.GetAttributeValue(nameof(WaterTransparency.RiverTransparencyMultiplier), "1.0"), &objT->RiverTransparencyMultiplier, state);
        Marshal(node.GetChildNode(nameof(WaterTransparency.StandingWaterColor), null), &objT->StandingWaterColor, state);
        Marshal(node.GetChildNode(nameof(WaterTransparency.RadarWaterColor), null), &objT->RadarWaterColor, state);
        Marshal(node.GetChildNode(nameof(WaterTransparency.ReflectionGuard), null), &objT->ReflectionGuard, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
