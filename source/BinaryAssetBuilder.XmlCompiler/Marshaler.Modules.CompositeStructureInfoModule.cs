using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CompositeStructureInfoModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CompositeStructureInfoModuleData.ThingTemplate), null), &objT->ThingTemplate, state);
        Marshal(node.GetAttributeValue(nameof(CompositeStructureInfoModuleData.Count), null), &objT->Count, state);
        Marshal(node.GetAttributeValue(nameof(CompositeStructureInfoModuleData.BuildableDistance), null), &objT->BuildableDistance, state);
        Marshal(node.GetChildNode(nameof(CompositeStructureInfoModuleData.ConnectionShadowInfo), null), &objT->ConnectionShadowInfo, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
