using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LocomotorSetModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LocomotorSetModuleData.KillLocomotorUpgrade), "false"), &objT->KillLocomotorUpgrade, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
