using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DLaserDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.UseDistortionShader), "false"), &objT->UseDistortionShader, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture1_UTile), "1.0"), &objT->Texture1_UTile, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture1_VTile), "1.0"), &objT->Texture1_VTile, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture2_UTile), "1.0"), &objT->Texture2_UTile, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture2_VTile), "1.0"), &objT->Texture2_VTile, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture1_UScrollRate), "0.0"), &objT->Texture1_UScrollRate, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture1_VScrollRate), "0.0"), &objT->Texture1_VScrollRate, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture2_UScrollRate), "0.0"), &objT->Texture2_UScrollRate, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture2_VScrollRate), "0.0"), &objT->Texture2_VScrollRate, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture1_NumFrames), "1"), &objT->Texture1_NumFrames, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture1_FrameRate), "30.0"), &objT->Texture1_FrameRate, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture2_NumFrames), "1"), &objT->Texture2_NumFrames, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.Texture2_FrameRate), "30.0"), &objT->Texture2_FrameRate, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.LaserWidth), "5.0"), &objT->LaserWidth, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.WeaponSlotID), "-1"), &objT->WeaponSlotID, state);
        Marshal(node.GetAttributeValue(nameof(W3DLaserDrawModuleData.LaserStateID), "0"), &objT->LaserStateID, state);
        Marshal(node.GetChildNode(nameof(W3DLaserDrawModuleData.FXShader), null), &objT->FXShader, state);
        Marshal(node.GetChildNode(nameof(W3DLaserDrawModuleData.ObjectStatusValidation), null), &objT->ObjectStatusValidation, state);
        Marshal(node, (DrawModuleData*)objT, state);
    }
}