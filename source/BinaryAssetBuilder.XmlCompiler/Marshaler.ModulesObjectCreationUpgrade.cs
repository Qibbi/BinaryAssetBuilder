using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ObjectCreationUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ObjectCreationUpgradeModuleData.UpgradeObject), null), &objT->UpgradeObject, state);
        Marshal(node.GetAttributeValue(nameof(ObjectCreationUpgradeModuleData.Delay), "0"), &objT->Delay, state);
        Marshal(node.GetAttributeValue(nameof(ObjectCreationUpgradeModuleData.RemoveUpgrade), null), &objT->RemoveUpgrade, state);
        Marshal(node.GetAttributeValue(nameof(ObjectCreationUpgradeModuleData.GrantUpgrade), null), &objT->GrantUpgrade, state);
        Marshal(node.GetAttributeValue(nameof(ObjectCreationUpgradeModuleData.ThingToSpawn), null), &objT->ThingToSpawn, state);
        Marshal(node.GetAttributeValue(nameof(ObjectCreationUpgradeModuleData.Angle), null), &objT->Angle, state);
        Marshal(node.GetAttributeValue(nameof(ObjectCreationUpgradeModuleData.DestroyWhenSold), "false"), &objT->DestroyWhenSold, state);
        Marshal(node.GetAttributeValue(nameof(ObjectCreationUpgradeModuleData.FadeInTime), "0"), &objT->FadeInTime, state);
        Marshal(node.GetAttributeValue(nameof(ObjectCreationUpgradeModuleData.UseBuildingProduction), "false"), &objT->UseBuildingProduction, state);
        Marshal(node.GetChildNode(nameof(ObjectCreationUpgradeModuleData.Offset), null), &objT->Offset, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
