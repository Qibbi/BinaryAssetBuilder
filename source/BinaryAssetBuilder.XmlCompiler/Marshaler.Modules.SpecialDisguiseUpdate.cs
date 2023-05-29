#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SpecialDisguiseUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpecialDisguiseUpdateModuleData.TriggerInstantlyOnCreate), "false"), &objT->TriggerInstantlyOnCreate, state);
        Marshal(node.GetAttributeValue(nameof(SpecialDisguiseUpdateModuleData.OpacityTarget), "0"), &objT->OpacityTarget, state);
        Marshal(node.GetAttributeValue(nameof(SpecialDisguiseUpdateModuleData.DisguiseAsTemplateId), null), &objT->DisguiseAsTemplateId, state);
        Marshal(node.GetAttributeValue(nameof(SpecialDisguiseUpdateModuleData.EnemyPerspectiveDisguisedTemplateId), null), &objT->EnemyPerspectiveDisguisedTemplateId, state);
        Marshal(node.GetAttributeValue(nameof(SpecialDisguiseUpdateModuleData.DisguiseFX), null), &objT->DisguiseFX, state);
        Marshal(node.GetAttributeValue(nameof(SpecialDisguiseUpdateModuleData.ForceMountedWhenDisguising), "false"), &objT->ForceMountedWhenDisguising, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
#endif
