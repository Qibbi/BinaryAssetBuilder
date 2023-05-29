using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, PassiveAreaEffectBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.EffectRadius), "0"), &objT->EffectRadius, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.MaxBeneficiaries), "0"), &objT->MaxBeneficiaries, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.HealingPercentPerSecond), "0"), &objT->HealingPercentPerSecond, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.HealingPointsPerSecond), "0"), &objT->HealingPointsPerSecond, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.SurveyDelayFrames), "20"), &objT->SurveyDelayFrames, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.UpgradeRequired), null), &objT->UpgradeRequired, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.NonStackable), "false"), &objT->NonStackable, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.AntiCategoryMask), null), &objT->AntiCategoryMask, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.AntiFX), null), &objT->AntiFX, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.HealFX), null), &objT->HealFX, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.AffectAttached), "false"), &objT->AffectAttached, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.AffectWoundedOnly), "false"), &objT->AffectWoundedOnly, state);
        Marshal(node.GetAttributeValue(nameof(PassiveAreaEffectBehaviorModuleData.AffectUnderAttack), "false"), &objT->AffectUnderAttack, state);
        Marshal(node.GetChildNodes(nameof(PassiveAreaEffectBehaviorModuleData.Modifier)), &objT->Modifier, state);
        Marshal(node.GetChildNode(nameof(PassiveAreaEffectBehaviorModuleData.AllowFilter), null), &objT->AllowFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
