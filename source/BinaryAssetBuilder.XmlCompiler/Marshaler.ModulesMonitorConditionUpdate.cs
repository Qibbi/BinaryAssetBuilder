using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MonitorConditionUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MonitorConditionUpdateModuleData.ModelConditionFlags), null), &objT->ModelConditionFlags, state);
        Marshal(node.GetAttributeValue(nameof(MonitorConditionUpdateModuleData.ModelConditionCommandSetString), null), &objT->ModelConditionCommandSetString, state);
        Marshal(node.GetAttributeValue(nameof(MonitorConditionUpdateModuleData.WeaponFlags), null), &objT->WeaponFlags, state);
        Marshal(node.GetAttributeValue(nameof(MonitorConditionUpdateModuleData.WeaponToggleCommandSetString), null), &objT->WeaponToggleCommandSetString, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
