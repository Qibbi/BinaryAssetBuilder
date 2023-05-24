#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetaSpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaSpecialAbilityUpdateModuleData.TargetSelf), "true"), &objT->TargetSelf, state);
        Marshal(node.GetAttributeValue(nameof(MetaSpecialAbilityUpdateModuleData.TargetKindOf), null), &objT->TargetKindOf, state);
        Marshal(node.GetAttributeValue(nameof(MetaSpecialAbilityUpdateModuleData.SpecialMove), "true"), &objT->SpecialMove, state);
        Marshal(node.GetChildNodes(nameof(MetaSpecialAbilityUpdateModuleData.MetaGameOPtoUse)), &objT->MetaGameOPtoUse, state);
        Marshal(node.GetChildNodes(nameof(MetaSpecialAbilityUpdateModuleData.UpgradeToWatchFor)), &objT->UpgradeToWatchFor, state);
        Marshal(node.GetChildNodes(nameof(MetaSpecialAbilityUpdateModuleData.RadiusOfDropZone)), &objT->RadiusOfDropZone, state);
        Marshal(node.GetChildNodes(nameof(MetaSpecialAbilityUpdateModuleData.ObjectFilter)), &objT->ObjectFilter, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
#endif
