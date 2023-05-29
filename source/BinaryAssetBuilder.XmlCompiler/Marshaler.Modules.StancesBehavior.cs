using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StancesBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StancesBehaviorModuleData.StanceTemplate), null), &objT->StanceTemplate, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
