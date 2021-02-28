using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, Achievement* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Achievement.XlastID), null), &objT->XlastID, state);
        Marshal(node.GetAttributeValue(nameof(Achievement.TriggerType), null), &objT->TriggerType, state);
        Marshal(node.GetAttributeValue(nameof(Achievement.AchievementValueString), null), &objT->AchievementValueString, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
