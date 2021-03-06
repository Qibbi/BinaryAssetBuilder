using Relo;
using SageBinaryData;
using SageBinaryData.Shell;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SlotState* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SlotState.Label), null), &objT->Label, state);
        Marshal(node.GetAttributeValue(nameof(SlotState.Value), null), &objT->Value, state);
        Marshal(node.GetAttributeValue(nameof(SlotState.AvailableInRanked), "true"), &objT->AvailableInRanked, state);
        Marshal(node.GetAttributeValue(nameof(SlotState.AvailableInModerated), "true"), &objT->AvailableInModerated, state);
    }

    public static unsafe void Marshal(Node node, AIDifficultySetting* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AIDifficultySetting.Label), null), &objT->Label, state);
        Marshal(node.GetAttributeValue(nameof(AIDifficultySetting.Value), null), &objT->Value, state);
    }

    public static unsafe void Marshal(Node node, TeamSetting* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TeamSetting.Label), null), &objT->Label, state);
        Marshal(node.GetAttributeValue(nameof(TeamSetting.Value), null), &objT->Value, state);
    }

    public static unsafe void Marshal(Node node, GameTimeSetting* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameTimeSetting.Label), null), &objT->Label, state);
        Marshal(node.GetAttributeValue(nameof(GameTimeSetting.Value), null), &objT->Value, state);
        Marshal(node.GetAttributeValue(nameof(GameTimeSetting.Default), "false"), &objT->Default, state);
    }

    public static unsafe void Marshal(Node node, GameResourcesSetting* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameResourcesSetting.Value), null), &objT->Value, state);
        Marshal(node.GetAttributeValue(nameof(GameResourcesSetting.Default), "false"), &objT->Default, state);
    }

    public static unsafe void Marshal(Node node, GamePointsSetting* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GamePointsSetting.Value), null), &objT->Value, state);
        Marshal(node.GetAttributeValue(nameof(GamePointsSetting.Default), "false"), &objT->Default, state);
    }

    public static unsafe void Marshal(Node node, GameFlagsSetting* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameFlagsSetting.Value), null), &objT->Value, state);
        Marshal(node.GetAttributeValue(nameof(GameFlagsSetting.Default), "false"), &objT->Default, state);
    }

    public static unsafe void Marshal(Node node, MultiplayerLobbyData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(MultiplayerLobbyData.LobbyTitleLabelSpec), null), &objT->LobbyTitleLabelSpec, state);
        Marshal(node.GetChildNode(nameof(MultiplayerLobbyData.UnmoderatedLobbyTitleTemplateSpec), null), &objT->UnmoderatedLobbyTitleTemplateSpec, state);
        Marshal(node.GetChildNode(nameof(MultiplayerLobbyData.ModeratedLobbyTitleTemplateSpec), null), &objT->ModeratedLobbyTitleTemplateSpec, state);
        Marshal(node.GetChildNode(nameof(MultiplayerLobbyData.PlayerNameLabelSpec), null), &objT->PlayerNameLabelSpec, state);
        Marshal(node.GetChildNode(nameof(MultiplayerLobbyData.SlotLabelSpec), null), &objT->SlotLabelSpec, state);
        Marshal(node.GetChildNodes(nameof(MultiplayerLobbyData.SlotState)), &objT->SlotState, state);
    }

    public static unsafe void Marshal(Node node, SkirmishLobbyData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(SkirmishLobbyData.LoadMusic), null), &objT->LoadMusic, state);
        Marshal(node.GetChildNode(nameof(SkirmishLobbyData.SlotLabelSpec), null), &objT->SlotLabelSpec, state);
        Marshal(node.GetChildNodes(nameof(SkirmishLobbyData.SlotState)), &objT->SlotState, state);
    }

    public static unsafe void Marshal(Node node, UIComponentLobby* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(UIComponentLobby.RandomStringLabel), null), &objT->RandomStringLabel, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.FactionLabelSpec), null), &objT->FactionLabelSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.AIPersonalityLabelSpec), null), &objT->AIPersonalityLabelSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.AIDifficultyLabelSpec), null), &objT->AIDifficultyLabelSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.TeamLabelSpec), null), &objT->TeamLabelSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.MapListSpec), null), &objT->MapListSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.GameplayTypeSpec), null), &objT->GameplayTypeSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.GameTimeLimitSpec), null), &objT->GameTimeLimitSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.GameResourcesSpec), null), &objT->GameResourcesSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.HillTimeSpec), null), &objT->HillTimeSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.CapturePointsSpec), null), &objT->CapturePointsSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.BarrierTimeSpec), null), &objT->BarrierTimeSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.CaptureFlagsSpec), null), &objT->CaptureFlagsSpec, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.FactionValue)), &objT->FactionValue, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.AIDifficulty)), &objT->AIDifficulty, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.Team)), &objT->Team, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.GameType)), &objT->GameType, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.GameTime)), &objT->GameTime, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.GameResources)), &objT->GameResources, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.HillTime)), &objT->HillTime, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.BarrierTime)), &objT->BarrierTime, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.CapturePoints)), &objT->CapturePoints, state);
        Marshal(node.GetChildNodes(nameof(UIComponentLobby.CaptureFlags)), &objT->CaptureFlags, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.MultiplayerLobbySettings), null), &objT->MultiplayerLobbySettings, state);
        Marshal(node.GetChildNode(nameof(UIComponentLobby.SkirmishLobbySettings), null), &objT->SkirmishLobbySettings, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}