using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ClearanceTestingSlowDeathBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ClearanceTestingSlowDeathBehaviorModuleData.ClearanceMaxHeight), "0"), &objT->ClearanceMaxHeight, state);
        Marshal(node.GetAttributeValue(nameof(ClearanceTestingSlowDeathBehaviorModuleData.ClearanceMaxHeightFraction), "0"), &objT->ClearanceMaxHeightFraction, state);
        Marshal(node.GetAttributeValue(nameof(ClearanceTestingSlowDeathBehaviorModuleData.ClearanceMinHeight), "0"), &objT->ClearanceMinHeight, state);
        Marshal(node.GetAttributeValue(nameof(ClearanceTestingSlowDeathBehaviorModuleData.ClearanceMinHeightFraction), "0"), &objT->ClearanceMinHeightFraction, state);
        Marshal(node.GetChildNode(nameof(ClearanceTestingSlowDeathBehaviorModuleData.ClearanceGeometry), null), &objT->ClearanceGeometry, state);
        Marshal(node.GetChildNode(nameof(ClearanceTestingSlowDeathBehaviorModuleData.ClearanceGeometryOffset), null), &objT->ClearanceGeometryOffset, state);
        Marshal(node, (SlowDeathBehaviorModuleData*)objT, state);
    }
}
