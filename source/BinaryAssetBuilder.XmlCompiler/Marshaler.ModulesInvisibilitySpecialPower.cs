using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InvisibilitySpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InvisibilitySpecialPowerModuleData.BroadcastRadius), "0"), &objT->BroadcastRadius, state);
        Marshal(node.GetAttributeValue(nameof(InvisibilitySpecialPowerModuleData.DurationFrames), "0"), &objT->DurationFrames, state);
        Marshal(node.GetChildNode(nameof(InvisibilitySpecialPowerModuleData.InvisibilityNugget), null), &objT->InvisibilityNugget, state);
        Marshal(node.GetChildNode(nameof(InvisibilitySpecialPowerModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
