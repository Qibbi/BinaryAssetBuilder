using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.SpecialPowerTemplate), null), &objT->SpecialPowerTemplate, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.UpdateModuleStartsAttack), "false"), &objT->UpdateModuleStartsAttack, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.StartsPaused), "false"), &objT->StartsPaused, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.ReEnableAntiCategory), "false"), &objT->ReEnableAntiCategory, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AntiCategory), null), &objT->AntiCategory, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AntiFX), null), &objT->AntiFX, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AttributeModifier), null), &objT->AttributeModifier, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AttributeModifierRange), "0.0"), &objT->AttributeModifierRange, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AttributeModifierAffectsSelf), "false"), &objT->AttributeModifierAffectsSelf, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AttributeModifierFX), null), &objT->AttributeModifierFX, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AttributeModifierWeatherBased), "false"), &objT->AttributeModifierWeatherBased, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.WeatherDuration), "0"), &objT->WeatherDuration, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.RequirementsFilterMPSkirmish), null), &objT->RequirementsFilterMPSkirmish, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.TargetEnemy), "false"), &objT->TargetEnemy, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.TargetAllSides), "false"), &objT->TargetAllSides, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.InitiateFX), null), &objT->InitiateFX, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.TriggerFX), null), &objT->TriggerFX, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.SetModelCondition), null), &objT->SetModelCondition, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.SetModelConditionTime), "0s"), &objT->SetModelConditionTime, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.GiveLevels), "0"), &objT->GiveLevels, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.DisableDuringAnimDuration), "false"), &objT->DisableDuringAnimDuration, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.IdleWhenStartingPower), "false"), &objT->IdleWhenStartingPower, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AffectGood), "false"), &objT->AffectGood, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AffectEvil), "false"), &objT->AffectEvil, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AffectAllies), "true"), &objT->AffectAllies, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AvailableAtStart), "true"), &objT->AvailableAtStart, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.ChangeWeather), null), &objT->ChangeWeather, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.AdjustVictim), "false"), &objT->AdjustVictim, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.OnTriggerRechargeSpecialPower), null), &objT->OnTriggerRechargeSpecialPower, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.BurnDecayModifier), "0"), &objT->BurnDecayModifier, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.UseDistanceFromCommandCenter), "false"), &objT->UseDistanceFromCommandCenter, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.MaxDistanceFromCommandCenter), "0"), &objT->MaxDistanceFromCommandCenter, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerModuleData.ChildModuleHandlesFX), "false"), &objT->ChildModuleHandlesFX, state);
        Marshal(node.GetChildNode(nameof(SpecialPowerModuleData.AttributeModifierAffects), null), &objT->AttributeModifierAffects, state);
        Marshal(node.GetChildNode(nameof(SpecialPowerModuleData.RequirementsFilterMP), null), &objT->RequirementsFilterMP, state);
        Marshal(node.GetChildNode(nameof(SpecialPowerModuleData.RequirementsFilterStrategic), null), &objT->RequirementsFilterStrategic, state);
        Marshal(node.GetChildNode(nameof(SpecialPowerModuleData.InitiateSound), null), &objT->InitiateSound, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
