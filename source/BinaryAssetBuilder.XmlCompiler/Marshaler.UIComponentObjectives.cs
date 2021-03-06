using Relo;
using SageBinaryData;
using SageBinaryData.InGameUI;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentObjectives* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectives.AptStringNewBonusObjective), ""), &objT->AptStringNewBonusObjective, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentObjectives.AptStringObjectiveCompleted), ""), &objT->AptStringObjectiveCompleted, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}