using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SkirmishOpeningMoveOrder* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SkirmishOpeningMoveOrder.Time), "0s"), &objT->Time, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishOpeningMoveOrder.Build), ""), &objT->Build, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishOpeningMoveOrder.Account), "SLUSH_FUND"), &objT->Account, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishOpeningMoveOrder.Deposit), "0"), &objT->Deposit, state);
    }

    public static unsafe void Marshal(Node node, SkirmishOpeningMove* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SkirmishOpeningMove.Side), null), &objT->Side, state);
        Marshal(node.GetChildNodes(nameof(SkirmishOpeningMove.Order)), &objT->Order, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
