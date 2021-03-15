using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ArmorUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ArmorUpgradeModuleData.KillArmorUpgrade), "false"), &objT->KillArmorUpgrade, state);
        Marshal(node.GetAttributeValue(nameof(ArmorUpgradeModuleData.IgnoreArmorUpgrade), "false"), &objT->IgnoreArmorUpgrade, state);
        Marshal(node.GetAttributeValue(nameof(ArmorUpgradeModuleData.ArmorSetFlag), null), &objT->ArmorSetFlag, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
