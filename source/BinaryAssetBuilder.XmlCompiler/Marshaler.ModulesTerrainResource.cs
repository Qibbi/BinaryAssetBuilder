using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TerrainResourceBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TerrainResourceBehaviorModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(TerrainResourceBehaviorModuleData.MaxIncome), "0"), &objT->MaxIncome, state);
        Marshal(node.GetAttributeValue(nameof(TerrainResourceBehaviorModuleData.IncomeInterval), "0xffffffff"), &objT->IncomeInterval, state);
        Marshal(node.GetAttributeValue(nameof(TerrainResourceBehaviorModuleData.HighPriority), "false"), &objT->HighPriority, state);
        Marshal(node.GetAttributeValue(nameof(TerrainResourceBehaviorModuleData.Visible), "true"), &objT->Visible, state);
        Marshal(node.GetAttributeValue(nameof(TerrainResourceBehaviorModuleData.Upgrade), null), &objT->Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(TerrainResourceBehaviorModuleData.UpgradeMustBePresent), null), &objT->UpgradeMustBePresent, state);
        Marshal(node.GetAttributeValue(nameof(TerrainResourceBehaviorModuleData.UpgradeBonusPercent), "100"), &objT->UpgradeBonusPercent, state);
        Marshal(node.GetChildNode(nameof(TerrainResourceBehaviorModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
