using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UnitCrateCollideModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UnitCrateCollideModuleData.UnitCount), "0"), &objT->UnitCount, state);
        Marshal(node.GetAttributeValue(nameof(UnitCrateCollideModuleData.UnitType), null), &objT->UnitType, state);
        Marshal(node, (CrateCollideModuleData*)objT, state);
    }
}
