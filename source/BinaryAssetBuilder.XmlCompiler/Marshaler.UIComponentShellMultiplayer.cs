using Relo;
using SageBinaryData;
using SageBinaryData.Shell;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RankedOptionSetting* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RankedOptionSetting.Label), null), &objT->Label, state);
        Marshal(node.GetAttributeValue(nameof(RankedOptionSetting.Value), null), &objT->Value, state);
    }

    public static unsafe void Marshal(Node node, UIComponentShellMultiplayer* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(UIComponentShellMultiplayer.MatchOptionsRankedLabelSpec), null), &objT->MatchOptionsRankedLabelSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentShellMultiplayer.MatchOptionsMatchTypeLabelSpec), null), &objT->MatchOptionsMatchTypeLabelSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentShellMultiplayer.MatchOptionsPlayersLabelSpec), null), &objT->MatchOptionsPlayersLabelSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentShellMultiplayer.AnyOptionLabelSpec), null), &objT->AnyOptionLabelSpec, state);
        Marshal(node.GetChildNode(nameof(UIComponentShellMultiplayer.TACLineLabelSpec), null), &objT->TACLineLabelSpec, state);
        Marshal(node.GetChildNodes(nameof(UIComponentShellMultiplayer.GameType)), &objT->GameType, state);
        Marshal(node.GetChildNodes(nameof(UIComponentShellMultiplayer.RankedOption)), &objT->RankedOption, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}