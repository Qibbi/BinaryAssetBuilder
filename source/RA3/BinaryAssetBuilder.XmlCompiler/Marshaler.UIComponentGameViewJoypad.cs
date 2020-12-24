using Relo;
using SageBinaryData;
using SageBinaryData.InGameUI;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentGameViewJoypad* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.LeftStickMultiplier), "100.0"), &objT->LeftStickMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.RightStickMultiplier), "0.25"), &objT->RightStickMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.ObjectAttractivityForce), "20.0"), &objT->ObjectAttractivityForce, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.MinAttractDistance), "40.0"), &objT->MinAttractDistance, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.MinAttractDistanceZoomed), "40.0"), &objT->MinAttractDistanceZoomed, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.MaxAttractiveForce), "0.6"), &objT->MaxAttractiveForce, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.KindOfExemptFromAttraction), null), &objT->KindOfExemptFromAttraction, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.ScrollSpeedMin), null), &objT->ScrollSpeedMin, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.ScrollSpeedMax), null), &objT->ScrollSpeedMax, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.ScrollSpeedMaxCutoff), null), &objT->ScrollSpeedMaxCutoff, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.ScrollSpeedMinCutoff), null), &objT->ScrollSpeedMinCutoff, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.InternalZoomInValue), null), &objT->InternalZoomInValue, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.InternalZoomOutValue), null), &objT->InternalZoomOutValue, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.MagnetismTuning_LOW_Strength), "1.1"), &objT->MagnetismTuning_LOW_Strength, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.MagnetismTuning_LOW_Distance), "0.6"), &objT->MagnetismTuning_LOW_Distance, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.MagnetismTuning_HIGH_Strength), "1.5"), &objT->MagnetismTuning_HIGH_Strength, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameViewJoypad.MagnetismTuning_HIGH_Distance), "1.25"), &objT->MagnetismTuning_HIGH_Distance, state);
        Marshal(node.GetChildNode(nameof(UIComponentGameViewJoypad.MagnetismObjectFilter), null), &objT->MagnetismObjectFilter, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}