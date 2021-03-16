using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HordeGarrisonContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HordeGarrisonContainModuleData.ExitDelay), "0"), &objT->ExitDelay, state);
        Marshal(node.GetChildNode(nameof(HordeGarrisonContainModuleData.EntryOffset), null), &objT->EntryOffset, state);
        Marshal(node.GetChildNode(nameof(HordeGarrisonContainModuleData.EntryPosition), null), &objT->EntryPosition, state);
        Marshal(node.GetChildNode(nameof(HordeGarrisonContainModuleData.ExitOffset), null), &objT->ExitOffset, state);
        Marshal(node, (GarrisonContainModuleData*)objT, state);
    }
}
