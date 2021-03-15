using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CreateObjectDieModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CreateObjectDieModuleData.CreationList), null), &objT->CreationList, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectDieModuleData.DebrisPortionOfSelf), null), &objT->DebrisPortionOfSelf, state);
        Marshal(node.GetChildNodes(nameof(CreateObjectDieModuleData.UpgradeRequired)), &objT->UpgradeRequired, state);
        Marshal(node.GetChildNodes(nameof(CreateObjectDieModuleData.UpgradeForbidden)), &objT->UpgradeForbidden, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
