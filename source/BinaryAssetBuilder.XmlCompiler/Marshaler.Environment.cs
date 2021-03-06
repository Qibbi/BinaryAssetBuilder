using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CloudEffectType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.CloudTexture), null), &objT->CloudTexture, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.DarkCloudTexture), null), &objT->DarkCloudTexture, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.AlphaTexture), null), &objT->AlphaTexture, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.PropagateSpeed), null), &objT->PropagateSpeed, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.Angle), null), &objT->Angle, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.DarkeningRate), null), &objT->DarkeningRate, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.LighteningRate), null), &objT->LighteningRate, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.CloudScrollSpeed), null), &objT->CloudScrollSpeed, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.DissipateTexture), null), &objT->DissipateTexture, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.DissipateStartLevel), null), &objT->DissipateStartLevel, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.DissipateSpeed), null), &objT->DissipateSpeed, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.DissipateRateScale), null), &objT->DissipateRateScale, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.LightningShadows), null), &objT->LightningShadows, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.JitterLightningLightIntensity), null), &objT->JitterLightningLightIntensity, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.JitterLightningLightPosition), null), &objT->JitterLightningLightPosition, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.LightningChance), null), &objT->LightningChance, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.LightningFrequency), null), &objT->LightningFrequency, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.LightningShadowIntensity), null), &objT->LightningShadowIntensity, state);
        Marshal(node.GetAttributeValue(nameof(CloudEffectType.LightningFX), null), &objT->LightningFX, state);
        Marshal(node.GetChildNode(nameof(CloudEffectType.DarkeningFactor), null), &objT->DarkeningFactor, state);
        Marshal(node.GetChildNode(nameof(CloudEffectType.DarkeningFactorRain), null), &objT->DarkeningFactorRain, state);
        Marshal(node.GetChildNode(nameof(CloudEffectType.LightningShadowColor), null), &objT->LightningShadowColor, state);
        Marshal(node.GetChildNode(nameof(CloudEffectType.LightningLightPosition1), null), &objT->LightningLightPosition1, state);
        Marshal(node.GetChildNode(nameof(CloudEffectType.LightningLightPosition2), null), &objT->LightningLightPosition2, state);
        Marshal(node.GetChildNode(nameof(CloudEffectType.LightningLightPosition3), null), &objT->LightningLightPosition3, state);
        Marshal(node.GetChildNode(nameof(CloudEffectType.LightningIntensity), null), &objT->LightningIntensity, state);
        Marshal(node.GetChildNode(nameof(CloudEffectType.LightningDuration), null), &objT->LightningDuration, state);
    }

    public static unsafe void Marshal(Node node, Environment* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(Environment.CloudEffect), null), &objT->CloudEffect, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}