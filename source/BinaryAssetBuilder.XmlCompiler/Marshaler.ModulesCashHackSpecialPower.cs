using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CashHackSpecialPowerUpgrades* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CashHackSpecialPowerUpgrades.Science), null), &objT->Science, state);
        Marshal(node.GetAttributeValue(nameof(CashHackSpecialPowerUpgrades.AmountToSteal), "0"), &objT->AmountToSteal, state);
    }

    public static unsafe void Marshal(Node node, CashHackSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CashHackSpecialPowerModuleData.DefaultAmountToSteal), "0"), &objT->DefaultAmountToSteal, state);
        Marshal(node.GetChildNodes(nameof(CashHackSpecialPowerModuleData.Upgrades)), &objT->Upgrades, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
