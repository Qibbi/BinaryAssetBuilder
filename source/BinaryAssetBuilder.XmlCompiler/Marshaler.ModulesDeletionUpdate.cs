using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DeletionUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DeletionUpdateModuleData.MinFrames), "0"), &objT->MinFrames, state);
        Marshal(node.GetAttributeValue(nameof(DeletionUpdateModuleData.MaxFrames), "1"), &objT->MaxFrames, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
