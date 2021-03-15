using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InfiltratorContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InfiltratorContainModuleData.ImmediatelyEnabled), "false"), &objT->ImmediatelyEnabled, state);
        Marshal(node.GetAttributeValue(nameof(InfiltratorContainModuleData.ReplaceWith), null), &objT->ReplaceWith, state);
        Marshal(node.GetAttributeValue(nameof(InfiltratorContainModuleData.Duration), "0s"), &objT->Duration, state);
        Marshal(node.GetAttributeValue(nameof(InfiltratorContainModuleData.Effect), "false"), &objT->Effect, state);
        Marshal(node.GetChildNode(nameof(InfiltratorContainModuleData.CanEnterFilter), null), &objT->CanEnterFilter, state);
        Marshal(node, (ContainModuleData*)objT, state);
    }
}
