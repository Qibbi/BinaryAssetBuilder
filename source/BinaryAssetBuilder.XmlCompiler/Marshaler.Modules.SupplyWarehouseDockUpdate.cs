using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SupplyWarehouseDockUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SupplyWarehouseDockUpdateModuleData.StartingBoxes), "1"), &objT->StartingBoxes, state);
        Marshal(node.GetAttributeValue(nameof(SupplyWarehouseDockUpdateModuleData.DeleteWhenEmpty), "false"), &objT->DeleteWhenEmpty, state);
        Marshal(node, (DockUpdateModuleData*)objT, state);
    }
}
