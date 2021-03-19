using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ShroudClearBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ShroudClearBehaviorModuleData.ShroudClearOptions), null), &objT->ShroudClearOptions, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
