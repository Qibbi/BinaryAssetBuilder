using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentGameInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.GameScoreDisplayToken), null), &objT->GameScoreDisplayToken, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.ScorePlayerToken), null), &objT->ScorePlayerToken, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.GameScoreXLocWS), null), &objT->GameScoreXLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.GameScoreXLoc), null), &objT->GameScoreXLoc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.GameScoreYLocWS), null), &objT->GameScoreYLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.GameScoreYLoc), null), &objT->GameScoreYLoc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player1ScoreXLocWS), null), &objT->Player1ScoreXLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player1ScoreXLoc), null), &objT->Player1ScoreXLoc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player1ScoreYLocWS), null), &objT->Player1ScoreYLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player1ScoreYLoc), null), &objT->Player1ScoreYLoc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player2ScoreXLocWS), null), &objT->Player2ScoreXLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player2ScoreXLoc), null), &objT->Player2ScoreXLoc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player2ScoreYLocWS), null), &objT->Player2ScoreYLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player2ScoreYLoc), null), &objT->Player2ScoreYLoc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player3ScoreXLocWS), null), &objT->Player3ScoreXLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player3ScoreXLoc), null), &objT->Player3ScoreXLoc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player3ScoreYLocWS), null), &objT->Player3ScoreYLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player3ScoreYLoc), null), &objT->Player3ScoreYLoc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player4ScoreXLocWS), null), &objT->Player4ScoreXLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player4ScoreXLoc), null), &objT->Player4ScoreXLoc, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player4ScoreYLocWS), null), &objT->Player4ScoreYLocWS, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentGameInfo.Player4ScoreYLoc), null), &objT->Player4ScoreYLoc, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}