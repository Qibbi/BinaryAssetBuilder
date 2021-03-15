using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DieModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(DieModuleData.DieMuxData), null), &objT->DieMuxData, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
