using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, OnlineChatColors* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(OnlineChatColors.Default), null), &objT->Default, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.CurrentRoom), null), &objT->CurrentRoom, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatRoom), null), &objT->ChatRoom, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.Game), null), &objT->Game, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.GameFull), null), &objT->GameFull, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.GameCRCMismatch), null), &objT->GameCRCMismatch, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.PlayerNormal), null), &objT->PlayerNormal, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.PlayerBuddy), null), &objT->PlayerBuddy, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.PlayerOwner), null), &objT->PlayerOwner, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.OfflinePlayerBuddy), null), &objT->OfflinePlayerBuddy, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.PlayerSelf), null), &objT->PlayerSelf, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.PlayerIgnored), null), &objT->PlayerIgnored, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.OfflinePlayerIgnored), null), &objT->OfflinePlayerIgnored, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatNormal), null), &objT->ChatNormal, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatEmote), null), &objT->ChatEmote, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatOwner), null), &objT->ChatOwner, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatOwnerEmote), null), &objT->ChatOwnerEmote, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatPrivate), null), &objT->ChatPrivate, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatPrivateEmote), null), &objT->ChatPrivateEmote, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatPrivateOwner), null), &objT->ChatPrivateOwner, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatPrivateOwnerEmote), null), &objT->ChatPrivateOwnerEmote, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatBuddy), null), &objT->ChatBuddy, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.ChatSelf), null), &objT->ChatSelf, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.AcceptTrue), null), &objT->AcceptTrue, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.AcceptFalse), null), &objT->AcceptFalse, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.MapSelected), null), &objT->MapSelected, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.MapUnselected), null), &objT->MapUnselected, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.MessageOfTheDay), null), &objT->MessageOfTheDay, state);
        Marshal(node.GetChildNode(nameof(OnlineChatColors.MessageOfTheDayHeading), null), &objT->MessageOfTheDayHeading, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}