using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DHordeModelDrawModuleDataLodOptions* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DHordeModelDrawModuleDataLodOptions.MultipleModels), "false"), &objT->MultipleModels, state);
        Marshal(node.GetAttributeValue(nameof(W3DHordeModelDrawModuleDataLodOptions.MaxRandomTextures), "0"), &objT->MaxRandomTextures, state);
        Marshal(node.GetAttributeValue(nameof(W3DHordeModelDrawModuleDataLodOptions.MaxRandomAnimations), "0"), &objT->MaxRandomAnimations, state);
        Marshal(node.GetAttributeValue(nameof(W3DHordeModelDrawModuleDataLodOptions.MaxFrameDelta), "0"), &objT->MaxFrameDelta, state);
        Marshal(node.GetAttributeValue(nameof(W3DHordeModelDrawModuleDataLodOptions.RandomStartFramePercent), "0"), &objT->RandomStartFramePercent, state);
    }

    public static unsafe void Marshal(Node node, W3DHordeModelDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(W3DHordeModelDrawModuleData.LodOptions)), &objT->LodOptions, state);
        Marshal(node, (W3DScriptedModelDrawModuleData*)objT, state);
    }
}