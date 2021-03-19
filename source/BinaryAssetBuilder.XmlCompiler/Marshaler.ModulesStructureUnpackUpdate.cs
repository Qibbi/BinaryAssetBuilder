using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StructureUnpackUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StructureUnpackUpdateModuleData.UnpackTime), "0s"), &objT->UnpackTime, state);
        Marshal(node.GetAttributeValue(nameof(StructureUnpackUpdateModuleData.UnpackCompleteSound), null), &objT->UnpackCompleteSound, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
