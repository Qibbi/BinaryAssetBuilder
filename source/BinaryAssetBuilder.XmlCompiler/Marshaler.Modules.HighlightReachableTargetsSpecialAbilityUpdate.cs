using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HighlightReachableTargetsSpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HighlightReachableTargetsSpecialAbilityUpdateModuleData.HighlightFX), null), &objT->HighlightFX, state);
        Marshal(node.GetAttributeValue(nameof(HighlightReachableTargetsSpecialAbilityUpdateModuleData.ModuleId), null), &objT->ModuleId, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
