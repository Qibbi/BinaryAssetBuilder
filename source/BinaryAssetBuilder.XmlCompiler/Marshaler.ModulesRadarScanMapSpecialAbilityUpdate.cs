using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, KindOfAndStatusAndModelConditionType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(KindOfAndStatusAndModelConditionType.ObjectStatus), null), &objT->ObjectStatus, state);
        Marshal(node.GetAttributeValue(nameof(KindOfAndStatusAndModelConditionType.ModelCondition), null), &objT->ModelCondition, state);
        Marshal(node.GetAttributeValue(nameof(KindOfAndStatusAndModelConditionType.KindOf), null), &objT->KindOf, state);
        Marshal(node.GetAttributeValue(nameof(KindOfAndStatusAndModelConditionType.UseLocalPlayerFilter), "true"), &objT->UseLocalPlayerFilter, state);
    }

    public static unsafe void Marshal(Node node, RadarScanMapSpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(RadarScanMapSpecialAbilityUpdateModuleData.IntersectionFlagsFilter)), &objT->IntersectionFlagsFilter, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
