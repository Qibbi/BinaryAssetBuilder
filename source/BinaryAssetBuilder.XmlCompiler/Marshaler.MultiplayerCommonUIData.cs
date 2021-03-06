using Relo;
using SageBinaryData.Shell;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GameplayTypeSetting* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameplayTypeSetting.Label), null), &objT->Label, state);
        Marshal(node.GetAttributeValue(nameof(GameplayTypeSetting.Value), null), &objT->Value, state);
        Marshal(node.GetAttributeValue(nameof(GameplayTypeSetting.AvailableWithAI), "false"), &objT->AvailableWithAI, state);
    }
}