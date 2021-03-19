using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DFloorDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DFloorDrawModuleData.StaticModelLODMode), "false"), &objT->StaticModelLODMode, state);
        Marshal(node.GetAttributeValue(nameof(W3DFloorDrawModuleData.ForceToBack), "false"), &objT->ForceToBack, state);
        Marshal(node.GetAttributeValue(nameof(W3DFloorDrawModuleData.StartHidden), "false"), &objT->StartHidden, state);
        Marshal(node.GetAttributeValue(nameof(W3DFloorDrawModuleData.FloorFadeRateOnObjectDeath), "0"), &objT->FloorFadeRateOnObjectDeath, state);
        Marshal(node.GetChildNodes(nameof(W3DFloorDrawModuleData.WeatherTexture)), &objT->WeatherTexture, state);
        Marshal(node.GetChildNodes(nameof(W3DFloorDrawModuleData.HideIfModelConditions)), &objT->HideIfModelConditions, state);
        Marshal(node, (W3DPropDrawModuleData*)objT, state);
    }
}