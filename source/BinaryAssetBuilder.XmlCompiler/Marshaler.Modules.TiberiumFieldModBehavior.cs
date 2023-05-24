#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TiberiumFieldModBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldModBehaviorModuleData.ObjectStatus), null), &objT->ObjectStatus, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumFieldModBehaviorModuleData.ModelCondition), null), &objT->ModelCondition, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
#endif
