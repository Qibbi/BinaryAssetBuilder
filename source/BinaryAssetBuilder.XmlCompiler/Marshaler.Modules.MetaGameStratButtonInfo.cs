#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MetaPowerDataType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaPowerDataType.Image), ""), &objT->Image, state);
        Marshal(node.GetAttributeValue(nameof(MetaPowerDataType.Title), ""), &objT->Title, state);
        Marshal(node.GetAttributeValue(nameof(MetaPowerDataType.Description), ""), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(MetaPowerDataType.TypeDescription), ""), &objT->TypeDescription, state);
        Marshal(node.GetAttributeValue(nameof(MetaPowerDataType.MetaGameOp), null), &objT->MetaGameOp, state);
    }

    public static unsafe void Marshal(Node node, MetaGameStratButtonInfoModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaGameStratButtonInfoModuleData.MetaGameDescription), null), &objT->MetaGameDescription, state);
        Marshal(node.GetAttributeValue(nameof(MetaGameStratButtonInfoModuleData.MetaGameTypeDescription), null), &objT->MetaGameTypeDescription, state);
        Marshal(node.GetChildNodes(nameof(MetaGameStratButtonInfoModuleData.Powers)), &objT->Powers, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
#endif
