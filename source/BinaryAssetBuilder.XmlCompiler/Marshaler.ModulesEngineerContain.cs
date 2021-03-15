using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, EngineerContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.ImmediatelyEnabled), "false"), &objT->ImmediatelyEnabled, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.ReplaceWith), null), &objT->ReplaceWith, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.NameOfVoiceToUseForFriendlyEnter), null), &objT->NameOfVoiceToUseForFriendlyEnter, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.NameOfVoiceToUseForHostileEnter), null), &objT->NameOfVoiceToUseForHostileEnter, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.FXForRepair), null), &objT->FXForRepair, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.FXForCapture), null), &objT->FXForCapture, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.FXForReplace), null), &objT->FXForReplace, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.FXForCaptureAndReplace), null), &objT->FXForCaptureAndReplace, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.EvaEventForRepair), null), &objT->EvaEventForRepair, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.EvaEventForCapture), null), &objT->EvaEventForCapture, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.EvaEventForReplace), null), &objT->EvaEventForReplace, state);
        Marshal(node.GetAttributeValue(nameof(EngineerContainModuleData.EvaEventForCaptureAndReplace), null), &objT->EvaEventForCaptureAndReplace, state);
        Marshal(node.GetChildNode(nameof(EngineerContainModuleData.CanEnterFilter), null), &objT->CanEnterFilter, state);
        Marshal(node, (ContainModuleData*)objT, state);
    }
}
