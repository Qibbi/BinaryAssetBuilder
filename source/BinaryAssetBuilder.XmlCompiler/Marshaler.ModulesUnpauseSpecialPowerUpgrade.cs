using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UnpauseSpecialPowerUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UnpauseSpecialPowerUpgradeModuleData.SpecialPowerTemplate), null), &objT->SpecialPowerTemplate, state);
        Marshal(node.GetAttributeValue(nameof(UnpauseSpecialPowerUpgradeModuleData.ObeyRechageOnTrigger), "false"), &objT->ObeyRechageOnTrigger, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
