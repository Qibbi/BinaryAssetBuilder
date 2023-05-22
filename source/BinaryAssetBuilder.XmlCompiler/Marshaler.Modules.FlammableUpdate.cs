using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXCreationList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXCreationList.Bone), null), &objT->Bone, state);
        Marshal(node.GetAttributeValue(nameof(FXCreationList.FX), null), &objT->FX, state);
    }

    public static unsafe void Marshal(Node node, FXCreationList** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(FXCreationList), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, FlammableUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.BurnedDelay), "0s"), &objT->BurnedDelay, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.AflameDuration), "0s"), &objT->AflameDuration, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.AflameDamageAmount), "0"), &objT->AflameDamageAmount, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.AflameDamageDelay), "0s"), &objT->AflameDamageDelay, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.BurningSoundName), null), &objT->BurningSoundName, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.FlameDamageLimit), "20"), &objT->FlameDamageLimit, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.FlameDamageExpiration), "10s"), &objT->FlameDamageExpiration, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.SetBurnedStatus), "true"), &objT->SetBurnedStatus, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.SwapModelWhenAflame), "false"), &objT->SwapModelWhenAflame, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.SwapModelWhenQuenched), "false"), &objT->SwapModelWhenQuenched, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.SwapTextureWhenAflame), "false"), &objT->SwapTextureWhenAflame, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.SwapTextureWhenQuenhed), "false"), &objT->SwapTextureWhenQuenhed, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.BurnContained), "false"), &objT->BurnContained, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.RunToWater), "false"), &objT->RunToWater, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.RunToWaterDepth), "0.0"), &objT->RunToWaterDepth, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.RunToWaterSearchRadius), "200.0"), &objT->RunToWaterSearchRadius, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.RunToWaterSearchIncrement), "60.0"), &objT->RunToWaterSearchIncrement, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.PanicLocomotorWhileAflame), "false"), &objT->PanicLocomotorWhileAflame, state);
        Marshal(node.GetAttributeValue(nameof(FlammableUpdateModuleData.DamageType), null), &objT->DamageType, state);
        Marshal(node.GetChildNode(nameof(FlammableUpdateModuleData.FireFXList), null), &objT->FireFXList, state);
        Marshal(node.GetChildNode(nameof(FlammableUpdateModuleData.CustomAnimAndDuration), null), &objT->CustomAnimAndDuration, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
