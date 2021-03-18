using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SpecialPowerModuleInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleInfo.ModuleId), null), &objT->ModuleId, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleInfo.TriggerAtTargetPosition), "true"), &objT->TriggerAtTargetPosition, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleInfo.TriggerType), "TARGET_POSITION"), &objT->TriggerType, state);
    }

    public static unsafe void Marshal(Node node, ActivateModuleSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(ActivateModuleSpecialPowerModuleData.SpecialPowerModules)), &objT->SpecialPowerModules, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
