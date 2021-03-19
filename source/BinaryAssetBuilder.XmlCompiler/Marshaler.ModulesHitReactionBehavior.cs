using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HitReactionBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HitReactionBehaviorModuleData.LightDamageHitReactionLifeTimer), "0"), &objT->LightDamageHitReactionLifeTimer, state);
        Marshal(node.GetAttributeValue(nameof(HitReactionBehaviorModuleData.MediumDamageHitReactionLifeTimer), "0"), &objT->MediumDamageHitReactionLifeTimer, state);
        Marshal(node.GetAttributeValue(nameof(HitReactionBehaviorModuleData.HeavyDamageHitReactionLifeTimer), "0"), &objT->HeavyDamageHitReactionLifeTimer, state);
        Marshal(node.GetAttributeValue(nameof(HitReactionBehaviorModuleData.LightDamageHitReactionThreshold), "0"), &objT->LightDamageHitReactionThreshold, state);
        Marshal(node.GetAttributeValue(nameof(HitReactionBehaviorModuleData.MediumDamageHitReactionThreshold), "0"), &objT->MediumDamageHitReactionThreshold, state);
        Marshal(node.GetAttributeValue(nameof(HitReactionBehaviorModuleData.HeavyDamageHitReactionThreshold), "0"), &objT->HeavyDamageHitReactionThreshold, state);
        Marshal(node.GetAttributeValue(nameof(HitReactionBehaviorModuleData.FastHitsResetReaction), "false"), &objT->FastHitsResetReaction, state);
        Marshal(node.GetAttributeValue(nameof(HitReactionBehaviorModuleData.HitsParalyze), "false"), &objT->HitsParalyze, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
