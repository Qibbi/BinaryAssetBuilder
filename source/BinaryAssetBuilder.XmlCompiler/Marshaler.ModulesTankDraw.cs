using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ArticulationBone* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ArticulationBone.ArticulationBoneName), null), &objT->ArticulationBoneName, state);
        Marshal(node.GetAttributeValue(nameof(ArticulationBone.ArticulationHelperBoneName), null), &objT->ArticulationHelperBoneName, state);
    }

    public static unsafe void Marshal(Node node, W3DTankDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DTankDrawModuleData.TreadAnimationRate), "0"), &objT->TreadAnimationRate, state);
        Marshal(node.GetAttributeValue(nameof(W3DTankDrawModuleData.TreadPivotSpeedFraction), "0.6"), &objT->TreadPivotSpeedFraction, state);
        Marshal(node.GetAttributeValue(nameof(W3DTankDrawModuleData.TreadDriveSpeedFraction), "0.3"), &objT->TreadDriveSpeedFraction, state);
        Marshal(node.GetAttributeValue(nameof(W3DTankDrawModuleData.TreadDebrisRight), null), &objT->TreadDebrisRight, state);
        Marshal(node.GetAttributeValue(nameof(W3DTankDrawModuleData.TreadDebrisLeft), null), &objT->TreadDebrisLeft, state);
        Marshal(node.GetChildNodes(nameof(W3DTankDrawModuleData.LeftTread)), &objT->LeftTread, state);
        Marshal(node.GetChildNodes(nameof(W3DTankDrawModuleData.RightTread)), &objT->RightTread, state);
        Marshal(node.GetChildNodes(nameof(W3DTankDrawModuleData.ArticulationBone)), &objT->ArticulationBone, state);
        Marshal(node, (W3DScriptedModelDrawModuleData*)objT, state);
    }
}