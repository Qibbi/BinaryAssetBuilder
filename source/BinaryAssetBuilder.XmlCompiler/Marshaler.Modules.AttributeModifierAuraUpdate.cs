using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AttributeModifierAuraUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.AttributeModifierName), null), &objT->AttributeModifierName, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.RefreshDelay), null), &objT->RefreshDelay, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.Range), null), &objT->Range, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.TargetEnemy), null), &objT->TargetEnemy, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.AllowPowerWhenAttacking), "true"), &objT->AllowPowerWhenAttacking, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.InitiallyActive), "false"), &objT->InitiallyActive, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.RequiredConditions), null), &objT->RequiredConditions, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.AntiCategory), null), &objT->AntiCategory, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.AntiFX), null), &objT->AntiFX, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.AffectGood), null), &objT->AffectGood, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.AffectEvil), null), &objT->AffectEvil, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.RunWhileDead), null), &objT->RunWhileDead, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.AllowSelf), null), &objT->AllowSelf, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.AffectContainedOnly), null), &objT->AffectContainedOnly, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.AffectHordeMembersOnly), null), &objT->AffectHordeMembersOnly, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.MaxActiveRank), null), &objT->MaxActiveRank, state);
        Marshal(node.GetAttributeValue(nameof(AttributeModifierAuraUpdateModuleData.RequiredObjectStatusFlags), null), &objT->RequiredObjectStatusFlags, state);
        Marshal(node.GetChildNode(nameof(AttributeModifierAuraUpdateModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
