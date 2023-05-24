using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TemporarilyDefectUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TemporarilyDefectUpdateModuleData.DefectionFrameCount), "0"), &objT->DefectionFrameCount, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
