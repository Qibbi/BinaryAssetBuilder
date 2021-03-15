using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, WanderAIUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WanderAIUpdateModuleData.AttackAll), "false"), &objT->AttackAll, state);
        Marshal(node.GetAttributeValue(nameof(WanderAIUpdateModuleData.EntryCondition), null), &objT->EntryCondition, state);
        Marshal(node.GetAttributeValue(nameof(WanderAIUpdateModuleData.Selectable), "false"), &objT->Selectable, state);
        Marshal(node.GetAttributeValue(nameof(WanderAIUpdateModuleData.WanderDistance), "0"), &objT->WanderDistance, state);
        Marshal(node, (AIUpdateModuleData*)objT, state);
    }
}
