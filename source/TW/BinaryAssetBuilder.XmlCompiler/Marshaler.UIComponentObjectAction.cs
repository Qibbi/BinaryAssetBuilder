using Relo;
using SageBinaryData;
using SageBinaryData.InGameUI;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentObjectAction* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(UIComponentObjectAction.AttackMoveColor), null), &objT->AttackMoveColor, state);
        Marshal(node.GetChildNode(nameof(UIComponentObjectAction.MoveColor), null), &objT->MoveColor, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}