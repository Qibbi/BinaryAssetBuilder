using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ShadowInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.Type), null), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.Texture), null), &objT->Texture, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.AdditionalTexture), null), &objT->AdditionalTexture, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.SizeX), "0.0"), &objT->SizeX, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.SizeY), "0.0"), &objT->SizeY, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.OffsetX), "0.0"), &objT->OffsetX, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.OffsetY), "0.0"), &objT->OffsetY, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.OpacityStart), "0"), &objT->OpacityStart, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.OpacityFadeInTime), "0s"), &objT->OpacityFadeInTime, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.OpacityPeak), "1"), &objT->OpacityPeak, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.OpacityFadeOutTime), "0s"), &objT->OpacityFadeOutTime, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.OpacityEnd), "0"), &objT->OpacityEnd, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.MaxHeight), "20"), &objT->MaxHeight, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.OverrideLODVisibility), "false"), &objT->OverrideLODVisibility, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.UseHouseColor), "false"), &objT->UseHouseColor, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.IsRotatingWithObject), "true"), &objT->IsRotatingWithObject, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.LocalPlayerOnly), "false"), &objT->LocalPlayerOnly, state);
        Marshal(node.GetAttributeValue(nameof(ShadowInfo.SunAngle), "0.0"), &objT->SunAngle, state);
    }

    public static unsafe void Marshal(Node node, RadiusDecalTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.Texture), null), &objT->Texture, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.Texture2), null), &objT->Texture2, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.Style), null), &objT->Style, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.OpacityMin), "1.0"), &objT->OpacityMin, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.OpacityMax), "1.0"), &objT->OpacityMax, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.OpacityThrobTime), "1000"), &objT->OpacityThrobTime, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.RotationsPerMinute), "0.0"), &objT->RotationsPerMinute, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.OnlyVisibleToOwningPlayer), "false"), &objT->OnlyVisibleToOwningPlayer, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.MaxRadius), "0.0"), &objT->MaxRadius, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.MinRadius), "0.0"), &objT->MinRadius, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.MaxSelectedUnits), "0"), &objT->MaxSelectedUnits, state);
        Marshal(node.GetAttributeValue(nameof(RadiusDecalTemplate.SpiralAcceleration), "0.0"), &objT->SpiralAcceleration, state);
    }
}
