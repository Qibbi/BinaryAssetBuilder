#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AuraObjectDataType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AuraObjectDataType.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(AuraObjectDataType.StatusToSet), null), &objT->StatusToSet, state);
        Marshal(node.GetAttributeValue(nameof(AuraObjectDataType.StatusToClear), null), &objT->StatusToClear, state);
        Marshal(node.GetChildNode(nameof(AuraObjectDataType.Filter), null), &objT->Filter, state);
        Marshal(node.GetChildNodes(nameof(AuraObjectDataType.Upgrade)), &objT->Upgrade, state);
    }

    public static unsafe void Marshal(Node node, MetaUpgradeAuraBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MetaUpgradeAuraBehaviorModuleData.AuraObject)), &objT->AuraObject, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
#endif
