using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CostModifierUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CostModifierUpgradeModuleData.Percentages), null), &objT->Percentages, state);
        Marshal(node.GetAttributeValue(nameof(CostModifierUpgradeModuleData.IsUpgradeDiscountUpgrade), "false"), &objT->IsUpgradeDiscountUpgrade, state);
        Marshal(node.GetAttributeValue(nameof(CostModifierUpgradeModuleData.StartsActive), "false"), &objT->StartsActive, state);
        Marshal(node.GetAttributeValue(nameof(CostModifierUpgradeModuleData.Slaughter), "false"), &objT->Slaughter, state);
        Marshal(node.GetAttributeValue(nameof(CostModifierUpgradeModuleData.UILabel), null), &objT->UILabel, state);
        Marshal(node.GetChildNode(nameof(CostModifierUpgradeModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node.GetChildNodes(nameof(CostModifierUpgradeModuleData.ApplyToUpgrade)), &objT->ApplyToUpgrade, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
