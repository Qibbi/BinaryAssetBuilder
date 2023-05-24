using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, PlayerUpgradeSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(PlayerUpgradeSpecialPowerModuleData.Upgrade)), &objT->Upgrade, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
