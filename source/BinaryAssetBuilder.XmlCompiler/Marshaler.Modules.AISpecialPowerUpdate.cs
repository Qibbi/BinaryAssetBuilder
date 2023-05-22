using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AISpecialPowerUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.CommandButtonName), null), &objT->CommandButtonName, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.SecondaryCommandButtonName), null), &objT->SecondaryCommandButtonName, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.SpecialPowerAIType), nameof(AISpecialPowerInstanceType.SPECIAL_POWER_BASIC_SELF_BUFF)), &objT->SpecialPowerAIType, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.SpecialPowerRadius), "-1.0"), &objT->SpecialPowerRadius, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.ReinforceDistance), "0.0"), &objT->ReinforceDistance, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.RandomizeTargetLocation), "false"), &objT->RandomizeTargetLocation, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.SpellMakesAStructure), null), &objT->SpellMakesAStructure, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.SpecificUnit), null), &objT->SpecificUnit, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.UnitKindOf), null), &objT->UnitKindOf, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.AllyUnitInclude), null), &objT->AllyUnitInclude, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.AllyUnitExclude), null), &objT->AllyUnitExclude, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.EnemyUnitInclude), null), &objT->EnemyUnitInclude, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.EnemyUnitExclude), null), &objT->EnemyUnitExclude, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.MinimumCutoff), null), &objT->MinimumCutoff, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.UpdateTime), "1.0s"), &objT->UpdateTime, state);
        Marshal(node.GetAttributeValue(nameof(AISpecialPowerUpdateModuleData.MaxFrequency), "0"), &objT->MaxFrequency, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
