using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DTracerDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.MinLength), null), &objT->MinLength, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.MaxLength), null), &objT->MaxLength, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.Width), null), &objT->Width, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.MinSpeed), null), &objT->MinSpeed, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.MaxSpeed), null), &objT->MaxSpeed, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.SweepSpeed), "1.0"), &objT->SweepSpeed, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.SpreadAngle), null), &objT->SpreadAngle, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.MinTracersPerFrame), null), &objT->MinTracersPerFrame, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.MaxTracersPerFrame), null), &objT->MaxTracersPerFrame, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.FrameLifeTime), null), &objT->FrameLifeTime, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.WeaponSlotType), null), &objT->WeaponSlotType, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.WeaponSlotID), "1"), &objT->WeaponSlotID, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.Texture), null), &objT->Texture, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.UseAdditiveBlending), "false"), &objT->UseAdditiveBlending, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.TracerHitFx), null), &objT->TracerHitFx, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.TracerEmitFx), null), &objT->TracerEmitFx, state);
        Marshal(node.GetAttributeValue(nameof(W3DTracerDrawModuleData.TextureIndex), null), &objT->TextureIndex, state);
        Marshal(node.GetChildNode(nameof(W3DTracerDrawModuleData.HeadColor), null), &objT->HeadColor, state);
        Marshal(node.GetChildNode(nameof(W3DTracerDrawModuleData.TailColor), null), &objT->TailColor, state);
        Marshal(node.GetChildNode(nameof(W3DTracerDrawModuleData.ObjectStatusValidation), null), &objT->ObjectStatusValidation, state);
        Marshal(node, (DrawModuleData*)objT, state);
    }
}