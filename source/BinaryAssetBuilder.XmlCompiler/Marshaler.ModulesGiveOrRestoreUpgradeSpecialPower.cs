using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GiveOrRestoreUpgradeSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GiveOrRestoreUpgradeSpecialPowerModuleData.CommandButton), null), &objT->CommandButton, state);
        Marshal(node.GetAttributeValue(nameof(GiveOrRestoreUpgradeSpecialPowerModuleData.UpgradeToGive), null), &objT->UpgradeToGive, state);
        Marshal(node.GetAttributeValue(nameof(GiveOrRestoreUpgradeSpecialPowerModuleData.WeaponFlags), null), &objT->WeaponFlags, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
