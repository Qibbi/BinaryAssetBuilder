using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, WallHubBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.HubCapTemplateId), null), &objT->HubCapTemplateId, state);
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.DefaultSegmentTemplateId), null), &objT->DefaultSegmentTemplateId, state);
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.CliffCapTemplateId), null), &objT->CliffCapTemplateId, state);
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.ShoreCapTemplateId), null), &objT->ShoreCapTemplateId, state);
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.BorderCapTemplateId), null), &objT->BorderCapTemplateId, state);
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.ElevatedSegmentTemplateId), null), &objT->ElevatedSegmentTemplateId, state);
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.BuilderRadius), "0"), &objT->BuilderRadius, state);
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.MaxBuildoutDistance), "0"), &objT->MaxBuildoutDistance, state);
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.Options), "0"), &objT->Options, state);
        Marshal(node.GetAttributeValue(nameof(WallHubBehaviorModuleData.StaggeredBuildFactor), "0"), &objT->StaggeredBuildFactor, state);
        Marshal(node.GetChildNodes(nameof(WallHubBehaviorModuleData.SegmentPattern)), &objT->SegmentPattern, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
