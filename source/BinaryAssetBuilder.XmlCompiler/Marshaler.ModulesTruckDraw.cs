using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DTruckDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.Dust), null), &objT->Dust, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.DirtSpray), null), &objT->DirtSpray, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.PowerslideSpray), null), &objT->PowerslideSpray, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.LeftFrontTireBone), null), &objT->LeftFrontTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.RightFrontTireBone), null), &objT->RightFrontTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.LeftRearTireBone), null), &objT->LeftRearTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.RightRearTireBone), null), &objT->RightRearTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.MidLeftFrontTireBone), null), &objT->MidLeftFrontTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.MidRightFrontTireBone), null), &objT->MidRightFrontTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.MidLeftRearTireBone), null), &objT->MidLeftRearTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.MidRightRearTireBone), null), &objT->MidRightRearTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.MidLeftMidTireBone), null), &objT->MidLeftMidTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.MidRightMidTireBone), null), &objT->MidRightMidTireBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.LeftFrontTireBone2), null), &objT->LeftFrontTireBone2, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.RightFrontTireBone2), null), &objT->RightFrontTireBone2, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.LeftRearTireBone2), null), &objT->LeftRearTireBone2, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.RightRearTireBone2), null), &objT->RightRearTireBone2, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.MidLeftMidTireBone2), null), &objT->MidLeftMidTireBone2, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.MidRightMidTireBone2), null), &objT->MidRightMidTireBone2, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.TireRotationMultiplier), "1.0"), &objT->TireRotationMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.TireRotationMultiplierFront), "1.0"), &objT->TireRotationMultiplierFront, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.PowerslideRotationAddition), "0"), &objT->PowerslideRotationAddition, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.CabBone), null), &objT->CabBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.TrailerBone), null), &objT->TrailerBone, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.CabRotationMultiplier), "1.0"), &objT->CabRotationMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.TrailerRotationMultiplier), "1.0"), &objT->TrailerRotationMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(W3DTruckDrawModuleData.RotationDamping), "1.0"), &objT->RotationDamping, state);
        Marshal(node, (W3DScriptedModelDrawModuleData*)objT, state);
    }
}