using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SpecialPowerTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.DisplayName), null), &objT->DisplayName, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.Description), null), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.TargetType), null), &objT->TargetType, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.Flags), null), &objT->Flags, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.ReloadTime), null), &objT->ReloadTime, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.InitiateSound), null), &objT->InitiateSound, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.InitiateAtLocationSound), null), &objT->InitiateAtLocationSound, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.ViewObjectDuration), null), &objT->ViewObjectDuration, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.ViewObjectRange), null), &objT->ViewObjectRange, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.RadiusCursorRadius), null), &objT->RadiusCursorRadius, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.PreventConditions), null), &objT->PreventConditions, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.RequiredConditions), null), &objT->RequiredConditions, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.DisallowedTargetModelStates), null), &objT->DisallowedTargetModelStates, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.RequiredTargetObjectStatus), null), &objT->RequiredTargetObjectStatus, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.DisallowedTargetObjectStatus), null), &objT->DisallowedTargetObjectStatus, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.MaxCastRange), "1000000"), &objT->MaxCastRange, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.MinCastRange), null), &objT->MinCastRange, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.ForbiddenObjectRange), null), &objT->ForbiddenObjectRange, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.EvaEventToPlayOnSuccess), null), &objT->EvaEventToPlayOnSuccess, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.EvaEventToPlayWhenSelectingTarget), null), &objT->EvaEventToPlayWhenSelectingTarget, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.EvaEventToPlayOnInitiateOwner), null), &objT->EvaEventToPlayOnInitiateOwner, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.EvaEventToPlayOnInitiateAlly), null), &objT->EvaEventToPlayOnInitiateAlly, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.EvaEventToPlayOnInitiateEnemy), null), &objT->EvaEventToPlayOnInitiateEnemy, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.NameOfVoiceNameToUseAsInitiateIntendToDoVoice), null), &objT->NameOfVoiceNameToUseAsInitiateIntendToDoVoice, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.NameOfVoiceNameToUseAsInitiateIntendToDoAfterMoveVoice), null), &objT->NameOfVoiceNameToUseAsInitiateIntendToDoAfterMoveVoice, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.NameOfVoiceNameToUseAsInitiateIntendToDoWhileUnderAttackVoice), null), &objT->NameOfVoiceNameToUseAsInitiateIntendToDoWhileUnderAttackVoice, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.NameOfVoiceNameToUseAsInitiateIntendToDoAfterMoveWhileUnderAttackVoice), null), &objT->NameOfVoiceNameToUseAsInitiateIntendToDoAfterMoveWhileUnderAttackVoice, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.NameOfVoiceNameToUseAsEnterStateInitiateIntendToDoVoice), null), &objT->NameOfVoiceNameToUseAsEnterStateInitiateIntendToDoVoice, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.NameOfVoiceNameToUseAsEnterStateInitiateIntendToDoAfterMoveVoice), null), &objT->NameOfVoiceNameToUseAsEnterStateInitiateIntendToDoAfterMoveVoice, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.NameOfVoiceNameToUseAsEnterStateInitiateIntendToDoWhileUnderAttackVoice), null), &objT->NameOfVoiceNameToUseAsEnterStateInitiateIntendToDoWhileUnderAttackVoice, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.NameOfVoiceNameToUseAsEnterStateInitiateIntendToDoAfterMoveWhileUnderAttackVoice), null), &objT->NameOfVoiceNameToUseAsEnterStateInitiateIntendToDoAfterMoveWhileUnderAttackVoice, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.RestrictionType), "UNRESTRICTED"), &objT->RestrictionType, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.Money), "0"), &objT->Money, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.WaypointModeTerminal), "true"), &objT->WaypointModeTerminal, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.TimerImage), null), &objT->TimerImage, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.ReachableTargetsCircleDisplayRadius), null), &objT->ReachableTargetsCircleDisplayRadius, state);
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.MetaGameOperation), "INVALID"), &objT->MetaGameOperation, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.ActiveMetaGamePhases), ""), &objT->ActiveMetaGamePhases, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.StrikeForceRejectStatus), ""), &objT->StrikeForceRejectStatus, state);
        Marshal(node.GetAttributeValue(nameof(SpecialPowerTemplate.StrikeForceRejectMatchAll), "false"), &objT->StrikeForceRejectMatchAll, state);
#endif
        Marshal(node.GetChildNode(nameof(SpecialPowerTemplate.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node.GetChildNode(nameof(SpecialPowerTemplate.ForbiddenObjectFilter), null), &objT->ForbiddenObjectFilter, state);
        Marshal(node.GetChildNode(nameof(SpecialPowerTemplate.GameDependency), null), &objT->GameDependency, state);
#if KANESWRATH
        Marshal(node.GetChildNode(nameof(SpecialPowerTemplate.MetaGameDependencies), null), &objT->MetaGameDependencies, state);
        Marshal(node.GetChildNode(nameof(SpecialPowerTemplate.MetaUpgradeToGrant), null), &objT->MetaUpgradeToGrant, state);
#endif
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
