using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GeometryUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GeometryUpgradeModuleData.ShowGeometry), null), &objT->ShowGeometry, state);
        Marshal(node.GetAttributeValue(nameof(GeometryUpgradeModuleData.HideGeometry), null), &objT->HideGeometry, state);
        Marshal(node.GetAttributeValue(nameof(GeometryUpgradeModuleData.WallBoundsMesh), null), &objT->WallBoundsMesh, state);
        Marshal(node.GetAttributeValue(nameof(GeometryUpgradeModuleData.RampMesh1), null), &objT->RampMesh1, state);
        Marshal(node.GetAttributeValue(nameof(GeometryUpgradeModuleData.RampMesh2), null), &objT->RampMesh2, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
