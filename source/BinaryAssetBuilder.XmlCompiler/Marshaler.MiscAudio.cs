using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MiscAudio* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MiscAudio.RadarNotifyHarvesterUnderAttackSound), null), &objT->RadarNotifyHarvesterUnderAttackSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.RadarNotifyStructureUnderAttackSound), null), &objT->RadarNotifyStructureUnderAttackSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.RadarNotifyInfiltrationSound), null), &objT->RadarNotifyInfiltrationSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.RadarNotifyOnlineSound), null), &objT->RadarNotifyOnlineSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.RadarNotifyOfflineSound), null), &objT->RadarNotifyOfflineSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GenericRadarEvent), null), &objT->GenericRadarEvent, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.BeaconPlacementSound), null), &objT->BeaconPlacementSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.BeaconPlacementFailed), null), &objT->BeaconPlacementFailed, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.DefectorTimerTickSound), null), &objT->DefectorTimerTickSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.DefectorTimerDingSound), null), &objT->DefectorTimerDingSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.AllCheerSound), null), &objT->AllCheerSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.NoCanDoSound), null), &objT->NoCanDoSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.StealthDiscoveredSound), null), &objT->StealthDiscoveredSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.StealthNeutralizedSound), null), &objT->StealthNeutralizedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.MoneyDepositSound), null), &objT->MoneyDepositSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.MoneyWithdrawSound), null), &objT->MoneyWithdrawSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.LowPower), null), &objT->LowPower, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.SufficientPower), null), &objT->SufficientPower, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.BuildingDisabled), null), &objT->BuildingDisabled, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.BuildingReenabled), null), &objT->BuildingReenabled, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.VehicleDisabled), null), &objT->VehicleDisabled, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.VehicleReenabled), null), &objT->VehicleReenabled, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.SplatterVehiclePilotsBrain), null), &objT->SplatterVehiclePilotsBrain, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.CrateHeal), null), &objT->CrateHeal, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.CrateShroud), null), &objT->CrateShroud, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.CrateFreeUnit), null), &objT->CrateFreeUnit, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.CrateMoney), null), &objT->CrateMoney, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.UnitPromoted), null), &objT->UnitPromoted, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.RepairSparks), null), &objT->RepairSparks, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.EnterCloseCombat), null), &objT->EnterCloseCombat, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.ExitCloseCombat), null), &objT->ExitCloseCombat, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.IncomingChatNotification), null), &objT->IncomingChatNotification, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.PrivateMessageNotification), null), &objT->PrivateMessageNotification, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.BuddyMessageNotification), null), &objT->BuddyMessageNotification, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.EnabledHotKeyPressed), null), &objT->EnabledHotKeyPressed, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.DisabledHotKeyPressed), null), &objT->DisabledHotKeyPressed, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.DisabledButtonClicked), null), &objT->DisabledButtonClicked, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.LowLODShellMusic), null), &objT->LowLODShellMusic, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.HighLODShellMusic), null), &objT->HighLODShellMusic, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.ScoreScreenMusic), null), &objT->ScoreScreenMusic, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.ShellMapLoadMusic), null), &objT->ShellMapLoadMusic, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.FullScreenSubMenuMusic), null), &objT->FullScreenSubMenuMusic, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.SaveFileLoadMusic), null), &objT->SaveFileLoadMusic, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.CreditsMusic), null), &objT->CreditsMusic, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.VolumeSampleMusic), null), &objT->VolumeSampleMusic, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.VolumeSampleSoundFX), null), &objT->VolumeSampleSoundFX, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.VolumeSampleVoice), null), &objT->VolumeSampleVoice, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.VolumeSampleAmbient), null), &objT->VolumeSampleAmbient, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.VolumeSampleMovie), null), &objT->VolumeSampleMovie, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.MissionBriefingCharacterClick), null), &objT->MissionBriefingCharacterClick, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.ComboBoxClick), null), &objT->ComboBoxClick, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GameSpyCommunicatorOpen), null), &objT->GameSpyCommunicatorOpen, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.MPSecondsCountdownBeep), null), &objT->MPSecondsCountdownBeep, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.RIFThingTemplateReloadedSound), null), &objT->RIFThingTemplateReloadedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.RIFObjectsRefreshedSound), null), &objT->RIFObjectsRefreshedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.FastForwardModeOn), null), &objT->FastForwardModeOn, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.FastForwardModeOff), null), &objT->FastForwardModeOff, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.RallyPointSet), null), &objT->RallyPointSet, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.UnableToSetRallyPoint), null), &objT->UnableToSetRallyPoint, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.PlanningModeOrderGiven), null), &objT->PlanningModeOrderGiven, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.BuildingPlacementSound), null), &objT->BuildingPlacementSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.BadBuildingPlacementSound), null), &objT->BadBuildingPlacementSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.WallPlacementSound), null), &objT->WallPlacementSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.AircraftWheelScreech), null), &objT->AircraftWheelScreech, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.LockonTickSound), null), &objT->LockonTickSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.TargetObjectWithSpecialPowerSound), null), &objT->TargetObjectWithSpecialPowerSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.ObjectiveCompleteSound), null), &objT->ObjectiveCompleteSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiFixedButtonClickedSound), null), &objT->GuiFixedButtonClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiBuildQueueButtonClickedSound), null), &objT->GuiBuildQueueButtonClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiSelectionRefinementButtonClickedSound), null), &objT->GuiSelectionRefinementButtonClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiFactorySelectionButtonClickedSound), null), &objT->GuiFactorySelectionButtonClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiTogglePowerObjectClickedSound), null), &objT->GuiTogglePowerObjectClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiToggleRepairObjectClickedSound), null), &objT->GuiToggleRepairObjectClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiSellObjectClickedSound), null), &objT->GuiSellObjectClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiCommandButtonClickedSound), null), &objT->GuiCommandButtonClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiCommandButtonRightClickedSound), null), &objT->GuiCommandButtonRightClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiDisabledCommandButtonClickedSound), null), &objT->GuiDisabledCommandButtonClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiDisabledCommandButtonRightClickedSound), null), &objT->GuiDisabledCommandButtonRightClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiPlayerPowerButtonClickedSound), null), &objT->GuiPlayerPowerButtonClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiPauseDialogButtonClickedSound), null), &objT->GuiPauseDialogButtonClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiPauseDialogButtonMouseOverSound), null), &objT->GuiPauseDialogButtonMouseOverSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiPauseDialogButtonMouseOutSound), null), &objT->GuiPauseDialogButtonMouseOutSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiYesNoDialogButtonClickedSound), null), &objT->GuiYesNoDialogButtonClickedSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiYesNoDialogButtonMouseOverSound), null), &objT->GuiYesNoDialogButtonMouseOverSound, state);
        Marshal(node.GetAttributeValue(nameof(MiscAudio.GuiYesNoDialogButtonMouseOutSound), null), &objT->GuiYesNoDialogButtonMouseOutSound, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
