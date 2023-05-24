using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DominateEnemySpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DominateEnemySpecialPowerModuleData.DominateRadius), null), &objT->DominateRadius, state);
        Marshal(node.GetAttributeValue(nameof(DominateEnemySpecialPowerModuleData.TriggerFX), null), &objT->TriggerFX, state);
        Marshal(node.GetAttributeValue(nameof(DominateEnemySpecialPowerModuleData.DominatedFX), null), &objT->DominatedFX, state);
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(DominateEnemySpecialPowerModuleData.FiringFX), null), &objT->FiringFX, state);
#endif
        Marshal(node.GetAttributeValue(nameof(DominateEnemySpecialPowerModuleData.PermanentlyConvert), "false"), &objT->PermanentlyConvert, state);
        Marshal(node.GetChildNode(nameof(DominateEnemySpecialPowerModuleData.AttributeModifierAffects), null), &objT->AttributeModifierAffects, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
