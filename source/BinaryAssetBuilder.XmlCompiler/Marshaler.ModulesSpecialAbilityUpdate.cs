using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.GrabPassengerHealGain), null), &objT->GrabPassengerHealGain, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.SpecialPowerTemplate), null), &objT->SpecialPowerTemplate, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.StartAbilityRange), "10000000.0"), &objT->StartAbilityRange, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.AbilityAbortRange), "10000000.0"), &objT->AbilityAbortRange, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.PreparationTime), "0s"), &objT->PreparationTime, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.PersistentPrepTime), "0s"), &objT->PersistentPrepTime, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.PersistentCount), "-1"), &objT->PersistentCount, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.PackTime), "0s"), &objT->PackTime, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.UnpackTime), "0s"), &objT->UnpackTime, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.PreTriggerUnstealthTime), "0s"), &objT->PreTriggerUnstealthTime, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.Options), null), &objT->Options, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.PackUnpackVariationFactor), "0.0"), &objT->PackUnpackVariationFactor, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.ParalyzeDurationWhenCompleted), "0s"), &objT->ParalyzeDurationWhenCompleted, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.ParalyzeDurationWhenAborted), "0s"), &objT->ParalyzeDurationWhenAborted, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.SpecialObject), null), &objT->SpecialObject, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.SpecialObjectAttachToBone), null), &objT->SpecialObjectAttachToBone, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.MaxSpecialObjects), "1"), &objT->MaxSpecialObjects, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.EffectDuration), "0s"), &objT->EffectDuration, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.EffectValue), "1"), &objT->EffectValue, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.EffectRange), "0"), &objT->EffectRange, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.FleeRangeAfterCompletion), "0.0"), &objT->FleeRangeAfterCompletion, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.DisableFXParticleSystem), null), &objT->DisableFXParticleSystem, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.PackSound), null), &objT->PackSound, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.UnpackSound), null), &objT->UnpackSound, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.PrepSoundLoop), null), &objT->PrepSoundLoop, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.TriggerSound), null), &objT->TriggerSound, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.ActiveLoopSound), null), &objT->ActiveLoopSound, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.AwardXPForTriggering), "0"), &objT->AwardXPForTriggering, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.SkillPointsForTriggering), "-1"), &objT->SkillPointsForTriggering, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.UnpackingVariation), "0"), &objT->UnpackingVariation, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.FreezeAfterTriggerDuration), "0s"), &objT->FreezeAfterTriggerDuration, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.RequiredConditions), null), &objT->RequiredConditions, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.RejectedConditions), null), &objT->RejectedConditions, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.SetObjectStatusOnTrigger), null), &objT->SetObjectStatusOnTrigger, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.ClearObjectStatusOnExit), null), &objT->ClearObjectStatusOnExit, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.ContactPointOverride), null), &objT->ContactPointOverride, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.TriggerAttributeModifier), null), &objT->TriggerAttributeModifier, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.AttributeModifierDuration), "0s"), &objT->AttributeModifierDuration, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.ChainedButton), null), &objT->ChainedButton, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.StartRechargeOnExit), "false"), &objT->StartRechargeOnExit, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.RequireAndSpendTiberiumOnCaster), "0"), &objT->RequireAndSpendTiberiumOnCaster, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.GoIdleInStartPreparation), "true"), &objT->GoIdleInStartPreparation, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.FaceTarget), "true"), &objT->FaceTarget, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.DisabledTypesToProcess), "HELD"), &objT->DisabledTypesToProcess, state);
        Marshal(node.GetAttributeValue(nameof(SpecialAbilityUpdateModuleData.DisabledTypesToContinueSoundsFor), "HELD"), &objT->DisabledTypesToContinueSoundsFor, state);
        Marshal(node.GetChildNode(nameof(SpecialAbilityUpdateModuleData.CustomAnimAndDuration), null), &objT->CustomAnimAndDuration, state);
        Marshal(node.GetChildNode(nameof(SpecialAbilityUpdateModuleData.GrabPassengerAnimAndDuration), null), &objT->GrabPassengerAnimAndDuration, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
