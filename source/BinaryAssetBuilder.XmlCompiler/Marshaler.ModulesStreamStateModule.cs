using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StreamStateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StreamStateModuleData.StreamId), "0"), &objT->StreamId, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
