using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ModelConditionUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ModelConditionUpgradeModuleData.AddConditionFlags), null), &objT->AddConditionFlags, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionUpgradeModuleData.RemoveConditionFlags), null), &objT->RemoveConditionFlags, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionUpgradeModuleData.AddTempConditionFlag), null), &objT->AddTempConditionFlag, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionUpgradeModuleData.TempConditionTime), "0.0s"), &objT->TempConditionTime, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
