#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UpgradeContainerOnContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UpgradeContainerOnContainModuleData.ID), null), &objT->ID, state);
        Marshal(node.GetChildNodes(nameof(UpgradeContainerOnContainModuleData.UnitFilter)), &objT->UnitFilter, state);
        Marshal(node.GetChildNodes(nameof(UpgradeContainerOnContainModuleData.UpgradeList)), &objT->UpgradeList, state);
    }
}
#endif
