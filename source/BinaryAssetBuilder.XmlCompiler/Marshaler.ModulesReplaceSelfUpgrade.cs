using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ReplaceSelfUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ReplaceSelfUpgradeModuleData.NewObjectUnpackTime), "0s"), &objT->NewObjectUnpackTime, state);
        Marshal(node.GetAttributeValue(nameof(ReplaceSelfUpgradeModuleData.DisabledDuringUnpack), "true"), &objT->DisabledDuringUnpack, state);
        Marshal(node.GetAttributeValue(nameof(ReplaceSelfUpgradeModuleData.CheckBuildAssistant), "false"), &objT->CheckBuildAssistant, state);
        Marshal(node.GetChildNodes(nameof(ReplaceSelfUpgradeModuleData.ReplacementTemplate)), &objT->ReplacementTemplate, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
