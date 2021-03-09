using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DefaultValues* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DefaultValues.Difficulty), "1"), &objT->Difficulty, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.Gamma), "1.30"), &objT->Gamma, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.Brightness), "0.50"), &objT->Brightness, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.Contrast), "1.30"), &objT->Contrast, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.VolumeMusic), "0.45"), &objT->VolumeMusic, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.VolumeFX), "0.70"), &objT->VolumeFX, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.VolumeVoice), "0.70"), &objT->VolumeVoice, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.VolumeAmbient), "0.50"), &objT->VolumeAmbient, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.VolumeMovie), "0.70"), &objT->VolumeMovie, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.ScrollSpeed), "1.00"), &objT->ScrollSpeed, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.ScrollMagnetism), "2"), &objT->ScrollMagnetism, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.ButtonIcon), "true"), &objT->ButtonIcon, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.HealthBars), "true"), &objT->HealthBars, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.HighlightPads), "true"), &objT->HighlightPads, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.ToolTips), "true"), &objT->ToolTips, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.InvertRotate), "true"), &objT->InvertRotate, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.DefaultFaction), "-1"), &objT->DefaultFaction, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.VisionCamVisible), "true"), &objT->VisionCamVisible, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.VisionCamZoom), "1"), &objT->VisionCamZoom, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.ScrollSpeedMin), "0.2"), &objT->ScrollSpeedMin, state);
        Marshal(node.GetAttributeValue(nameof(DefaultValues.ScrollSpeedMax), "2.0"), &objT->ScrollSpeedMax, state);
    }

    public static unsafe void Marshal(Node node, UIComponentOptions* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentOptions.ControlsToken), null), &objT->ControlsToken, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentOptions.SaveFileName), null), &objT->SaveFileName, state);
        Marshal(node.GetChildNodes(nameof(UIComponentOptions.ControlsText)), &objT->ControlsText, state);
        Marshal(node.GetChildNode(nameof(UIComponentOptions.DefaultValues), null), &objT->DefaultValues, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}