using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InGameUICommandButtonFactionSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUICommandButtonFactionSettings.Faction), null), &objT->Faction, state);
        Marshal(node.GetAttributeValue(nameof(InGameUICommandButtonFactionSettings.LockedImage), null), &objT->LockedImage, state);
        Marshal(node.GetChildNode(nameof(InGameUICommandButtonFactionSettings.ImageTintColor), null), &objT->ImageTintColor, state);
    }

    public static unsafe void Marshal(Node node, InGameUICommandButtonSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(InGameUICommandButtonSettings.FactionSettings)), &objT->FactionSettings, state);
    }

    public static unsafe void Marshal(Node node, InGameUIDrawableCaptionSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(InGameUIDrawableCaptionSettings.Font), null), &objT->Font, state);
        Marshal(node.GetChildNode(nameof(InGameUIDrawableCaptionSettings.Color), null), &objT->Color, state);
    }

    public static unsafe void Marshal(Node node, InGameUIExitContainerButtonSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIExitContainerButtonSettings.HelpTitleFormat), null), &objT->HelpTitleFormat, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIExitContainerButtonSettings.HelpDescription), null), &objT->HelpDescription, state);
    }

    public static unsafe void Marshal(Node node, InGameUISimpleHelpTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUISimpleHelpTemplate.Title), null), &objT->Title, state);
        Marshal(node.GetAttributeValue(nameof(InGameUISimpleHelpTemplate.Description), null), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(InGameUISimpleHelpTemplate.TypeDescription), null), &objT->TypeDescription, state);
        Marshal(node.GetAttributeValue(nameof(InGameUISimpleHelpTemplate.Instructions), null), &objT->Instructions, state);
    }

    public static unsafe void Marshal(Node node, InGameUISimpleHelpTemplate** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(InGameUISimpleHelpTemplate), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, InGameUIFixedButtonHelp* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.AggressiveStance), null), &objT->AggressiveStance, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.AircraftTab), null), &objT->AircraftTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.AircraftTypeTab), null), &objT->AircraftTypeTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.AttackMove), null), &objT->AttackMove, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.ForceAttack), null), &objT->ForceAttack, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.ForceMove), null), &objT->ForceMove, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.GuardStance), null), &objT->GuardStance, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.HoldGroundStance), null), &objT->HoldGroundStance, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.HoldFireStance), null), &objT->HoldFireStance, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.InfantryTab), null), &objT->InfantryTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.InfantryTypeTab), null), &objT->InfantryTypeTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.IntelligenceDatabase), null), &objT->IntelligenceDatabase, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.MainStructureTab), null), &objT->MainStructureTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.MainStructureTypeTab), null), &objT->MainStructureTypeTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.Messenger), null), &objT->Messenger, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.Objectives), null), &objT->Objectives, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.OtherStructureTab), null), &objT->OtherStructureTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.OtherStructureTypeTab), null), &objT->OtherStructureTypeTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.PlanningMode), null), &objT->PlanningMode, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.PlayerStatus), null), &objT->PlayerStatus, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.ReplayFastForward), null), &objT->ReplayFastForward, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.ReverseMove), null), &objT->ReverseMove, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.SelectionRefinementTab), null), &objT->SelectionRefinementTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.SellMode), null), &objT->SellMode, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.Stop), null), &objT->Stop, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.TogglePowerMode), null), &objT->TogglePowerMode, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.ToggleRepairMode), null), &objT->ToggleRepairMode, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.VehicleTab), null), &objT->VehicleTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.VehicleTypeTab), null), &objT->VehicleTypeTab, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.VoiceChatMode), null), &objT->VoiceChatMode, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.VoiceChatTalk), null), &objT->VoiceChatTalk, state);
        Marshal(node.GetChildNode(nameof(InGameUIFixedButtonHelp.WaypointMode), null), &objT->WaypointMode, state);
    }

    public static unsafe void Marshal(Node node, InGameUIFloatingTextSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIFloatingTextSettings.TimeOut), "333ms"), &objT->TimeOut, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIFloatingTextSettings.MoveUpSpeed), "1.0"), &objT->MoveUpSpeed, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIFloatingTextSettings.MoveVanishRate), "0.1"), &objT->MoveVanishRate, state);
        Marshal(node.GetChildNode(nameof(InGameUIFloatingTextSettings.Font), null), &objT->Font, state);
    }

    public static unsafe void Marshal(Node node, InGameUIMessageSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIMessageSettings.Delay), "5s"), &objT->Delay, state);
        Marshal(node.GetChildNode(nameof(InGameUIMessageSettings.Color1), null), &objT->Color1, state);
        Marshal(node.GetChildNode(nameof(InGameUIMessageSettings.Color2), null), &objT->Color2, state);
        Marshal(node.GetChildNode(nameof(InGameUIMessageSettings.Font), null), &objT->Font, state);
    }

    public static unsafe void Marshal(Node node, InGameUIMilitaryCaptionSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIMilitaryCaptionSettings.Delay), "750ms"), &objT->Delay, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIMilitaryCaptionSettings.Centered), "false"), &objT->Centered, state);
        Marshal(node.GetChildNode(nameof(InGameUIMilitaryCaptionSettings.Color), null), &objT->Color, state);
        Marshal(node.GetChildNode(nameof(InGameUIMilitaryCaptionSettings.Position), null), &objT->Position, state);
        Marshal(node.GetChildNode(nameof(InGameUIMilitaryCaptionSettings.TitleFont), null), &objT->TitleFont, state);
        Marshal(node.GetChildNode(nameof(InGameUIMilitaryCaptionSettings.Font), null), &objT->Font, state);
    }

    public static unsafe void Marshal(Node node, InGameUIObjectivePresentationSettingsZoom* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.InitialChangePerSecond), "1.8"), &objT->InitialChangePerSecond, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.Overshoot), "15"), &objT->Overshoot, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.ChangePerSecond), "0.4"), &objT->ChangePerSecond, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.InitialFOV), "100"), &objT->InitialFOV, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.MidPointFOV), "70"), &objT->MidPointFOV, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.MinimumFOV), "50"), &objT->MinimumFOV, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.MidPointOfs), "5"), &objT->MidPointOfs, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.ZoomCount), "3"), &objT->ZoomCount, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.DurationMin), "1s"), &objT->DurationMin, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.DurationMax), "3s"), &objT->DurationMax, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.ZoomOutSound), ""), &objT->ZoomOutSound, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.ZoomInSound), ""), &objT->ZoomInSound, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.MinFOVChangeForZoomOutSound), "110%"), &objT->MinFOVChangeForZoomOutSound, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsZoom.MaxFOVChangeForZoomInSound), "90%"), &objT->MaxFOVChangeForZoomInSound, state);
    }

    public static unsafe void Marshal(Node node, InGameUIObjectivePresentationSettingsMove* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsMove.Acceleration), "150.0"), &objT->Acceleration, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsMove.MaxSpeed), "500.0"), &objT->MaxSpeed, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsMove.JitterXY), "3.0"), &objT->JitterXY, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsMove.JitterZ), "1.0"), &objT->JitterZ, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsMove.MinHardCutDistance), "500.0"), &objT->MinHardCutDistance, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsMove.HardCutSound), ""), &objT->HardCutSound, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettingsMove.MoveSound), ""), &objT->MoveSound, state);
    }

    public static unsafe void Marshal(Node node, InGameUIObjectivePresentationSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettings.StartObjectiveSound), ""), &objT->StartObjectiveSound, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettings.SatelliteViewFinishSound), ""), &objT->SatelliteViewFinishSound, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettings.SatelliteViewAmbientLoop), ""), &objT->SatelliteViewAmbientLoop, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettings.DefaultTimePerTarget), "5s"), &objT->DefaultTimePerTarget, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettings.DefaultCameraStartAngle), "0d"), &objT->DefaultCameraStartAngle, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettings.DefaultCameraEndAngle), "180d"), &objT->DefaultCameraEndAngle, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettings.DefaultCameraFieldOfView), "25d"), &objT->DefaultCameraFieldOfView, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIObjectivePresentationSettings.DefaultCameraFieldOfViewVariance), "0"), &objT->DefaultCameraFieldOfViewVariance, state);
        Marshal(node.GetChildNode(nameof(InGameUIObjectivePresentationSettings.Zoom), null), &objT->Zoom, state);
        Marshal(node.GetChildNode(nameof(InGameUIObjectivePresentationSettings.Move), null), &objT->Move, state);
    }

    public static unsafe void Marshal(Node node, InGameUISubtitleSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUISubtitleSettings.HoldTime), "20s"), &objT->HoldTime, state);
        Marshal(node.GetAttributeValue(nameof(InGameUISubtitleSettings.LineCount), "8"), &objT->LineCount, state);
        Marshal(node.GetChildNode(nameof(InGameUISubtitleSettings.Font), null), &objT->Font, state);
        Marshal(node.GetChildNode(nameof(InGameUISubtitleSettings.PanelColor), null), &objT->PanelColor, state);
        Marshal(node.GetChildNode(nameof(InGameUISubtitleSettings.TextColor), null), &objT->TextColor, state);
        Marshal(node.GetChildNode(nameof(InGameUISubtitleSettings.Position), null), &objT->Position, state);
        Marshal(node.GetChildNode(nameof(InGameUISubtitleSettings.Size), null), &objT->Size, state);
    }

    public static unsafe void Marshal(Node node, InGameUITimerSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUITimerSettings.FlashDuration), "1s"), &objT->FlashDuration, state);
        Marshal(node.GetAttributeValue(nameof(InGameUITimerSettings.Centered), "false"), &objT->Centered, state);
        Marshal(node.GetChildNode(nameof(InGameUITimerSettings.Position), null), &objT->Position, state);
        Marshal(node.GetChildNode(nameof(InGameUITimerSettings.FlashColor), null), &objT->FlashColor, state);
        Marshal(node.GetChildNode(nameof(InGameUITimerSettings.NormalFont), null), &objT->NormalFont, state);
        Marshal(node.GetChildNode(nameof(InGameUITimerSettings.NormalColor), null), &objT->NormalColor, state);
        Marshal(node.GetChildNode(nameof(InGameUITimerSettings.ReadyFont), null), &objT->ReadyFont, state);
        Marshal(node.GetChildNode(nameof(InGameUITimerSettings.ReadyColor), null), &objT->ReadyColor, state);
    }

    public static unsafe void Marshal(Node node, InGameUISettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUISettings.CommandLimitReachedText), ""), &objT->CommandLimitReachedText, state);
        Marshal(node.GetAttributeValue(nameof(InGameUISettings.ObjectivesButtonFlashDuration), "30s"), &objT->ObjectivesButtonFlashDuration, state);
        Marshal(node.GetAttributeValue(nameof(InGameUISettings.IntelligenceDatabaseButtonFlashDuration), "15s"), &objT->IntelligenceDatabaseButtonFlashDuration, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.CommandButton), null), &objT->CommandButton, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.AttackMoveMarkerColor), null), &objT->AttackMoveMarkerColor, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.DecalCloud), null), &objT->DecalCloud, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.DrawableCaption), null), &objT->DrawableCaption, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.ExitContainerButton), null), &objT->ExitContainerButton, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.FixedButtonHelp), null), &objT->FixedButtonHelp, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.FloatingText), null), &objT->FloatingText, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.Message), null), &objT->Message, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.MilitaryCaption), null), &objT->MilitaryCaption, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.MoveMarkerColor), null), &objT->MoveMarkerColor, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.ObjectivePresentation), null), &objT->ObjectivePresentation, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.Subtitle), null), &objT->Subtitle, state);
        Marshal(node.GetChildNode(nameof(InGameUISettings.Timer), null), &objT->Timer, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
