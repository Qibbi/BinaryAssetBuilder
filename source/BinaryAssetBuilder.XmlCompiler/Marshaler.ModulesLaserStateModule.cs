using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LaserStateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LaserStateModuleData.LaserId), "0"), &objT->LaserId, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
