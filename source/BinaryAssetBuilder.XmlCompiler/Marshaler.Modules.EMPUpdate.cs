using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, EMPUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(EMPUpdateModuleData.Lifetime), "0s"), &objT->Lifetime, state);
        Marshal(node.GetAttributeValue(nameof(EMPUpdateModuleData.StartFadeDelay), "0s"), &objT->StartFadeDelay, state);
        Marshal(node.GetAttributeValue(nameof(EMPUpdateModuleData.DisabledDuration), "0s"), &objT->DisabledDuration, state);
        Marshal(node.GetAttributeValue(nameof(EMPUpdateModuleData.StartScale), "1"), &objT->StartScale, state);
        Marshal(node.GetAttributeValue(nameof(EMPUpdateModuleData.TargetScaleMin), "1"), &objT->TargetScaleMin, state);
        Marshal(node.GetAttributeValue(nameof(EMPUpdateModuleData.TargetScaleMax), "1"), &objT->TargetScaleMax, state);
        Marshal(node.GetAttributeValue(nameof(EMPUpdateModuleData.DisableFXParticleSystem), null), &objT->DisableFXParticleSystem, state);
        Marshal(node.GetAttributeValue(nameof(EMPUpdateModuleData.SparksPerCubicFoot), "0"), &objT->SparksPerCubicFoot, state);
        Marshal(node.GetChildNode(nameof(EMPUpdateModuleData.StartColor), null), &objT->StartColor, state);
        Marshal(node.GetChildNode(nameof(EMPUpdateModuleData.EndColor), null), &objT->EndColor, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
