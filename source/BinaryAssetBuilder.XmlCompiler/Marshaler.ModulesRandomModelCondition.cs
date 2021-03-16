using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RandomModelConditionBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RandomModelConditionBehaviorModuleData.Conditions), null), &objT->Conditions, state);
        Marshal(node, (CreateModuleData*)objT, state);
    }
}
