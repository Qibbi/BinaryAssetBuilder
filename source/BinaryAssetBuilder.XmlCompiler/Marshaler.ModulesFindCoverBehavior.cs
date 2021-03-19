using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FindCoverBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FindCoverBehaviorModuleData.AttributeModifierInCover), null), &objT->AttributeModifierInCover, state);
        Marshal(node.GetAttributeValue(nameof(FindCoverBehaviorModuleData.CoverScanRange), null), &objT->CoverScanRange, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
