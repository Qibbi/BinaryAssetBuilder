using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GameStatsModeData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(GameStatsModeData.AvailableMapName)), &objT->AvailableMapName, state);
        Marshal(node.GetAttributeValue(nameof(GameStatsModeData.GameStatsMode), null), &objT->GameStatsMode, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, MultiplayerSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.InitialCreditsVeryLow), null), &objT->InitialCreditsVeryLow, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.InitialCreditsLow), null), &objT->InitialCreditsLow, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.InitialCreditsMedium), null), &objT->InitialCreditsMedium, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.InitialCreditsHigh), null), &objT->InitialCreditsHigh, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.InitialCreditsVeryHigh), null), &objT->InitialCreditsVeryHigh, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.StartCountdownTimer), null), &objT->StartCountdownTimer, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.MaxBeaconsPerPlayer), null), &objT->MaxBeaconsPerPlayer, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.UseShroud), null), &objT->UseShroud, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.ShowRandomPlayerTemplate), null), &objT->ShowRandomPlayerTemplate, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.ShowRandomStartPos), null), &objT->ShowRandomStartPos, state);
        Marshal(node.GetChildNode(nameof(MultiplayerSettings.ShowRandomColor), null), &objT->ShowRandomColor, state);
        Marshal(node.GetChildNodes(nameof(MultiplayerSettings.GameStatsModeData)), &objT->GameStatsModeData, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}