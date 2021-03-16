using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StructureToppleUpdateFXBoneInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateFXBoneInfo.BoneName), null), &objT->BoneName, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateFXBoneInfo.ParticleSystemTemplate), null), &objT->ParticleSystemTemplate, state);
    }

    public static unsafe void Marshal(Node node, StructureToppleUpdateAngleFXInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateAngleFXInfo.Angle), null), &objT->Angle, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateAngleFXInfo.FXList), null), &objT->FXList, state);
    }

    public static unsafe void Marshal(Node node, StructureToppleUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.MinToppleDelay), "0s"), &objT->MinToppleDelay, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.MaxToppleDelay), "0s"), &objT->MaxToppleDelay, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.StructuralIntegrity), "0.1"), &objT->StructuralIntegrity, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.StructuralDecay), "0"), &objT->StructuralDecay, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.ToppleAccelerationFactor), "0.06"), &objT->ToppleAccelerationFactor, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.DamageFXTypes), null), &objT->DamageFXTypes, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.ToppleStartFXList), null), &objT->ToppleStartFXList, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.ToppleDelayFXList), null), &objT->ToppleDelayFXList, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.ToppleFXList), null), &objT->ToppleFXList, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.ToppleDoneFXList), null), &objT->ToppleDoneFXList, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.CrushingFXList), null), &objT->CrushingFXList, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.CrushingWeaponName), null), &objT->CrushingWeaponName, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.MinToppleBurstDelay), "0s"), &objT->MinToppleBurstDelay, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.MaxToppleBurstDelay), "0s"), &objT->MaxToppleBurstDelay, state);
        Marshal(node.GetAttributeValue(nameof(StructureToppleUpdateModuleData.ForceToppleAngle), "0"), &objT->ForceToppleAngle, state);
        Marshal(node.GetChildNodes(nameof(StructureToppleUpdateModuleData.OCLs)), &objT->OCLs, state);
        Marshal(node.GetChildNodes(nameof(StructureToppleUpdateModuleData.OCLCount)), &objT->OCLCount, state);
        Marshal(node.GetChildNodes(nameof(StructureToppleUpdateModuleData.FXBones)), &objT->FXBones, state);
        Marshal(node.GetChildNodes(nameof(StructureToppleUpdateModuleData.AngleFX)), &objT->AngleFX, state);
        Marshal(node.GetChildNode(nameof(StructureToppleUpdateModuleData.Die), null), &objT->Die, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
