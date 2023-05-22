using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DefaultProductionExitUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(DefaultProductionExitUpdateModuleData.UnitCreatePoint), null), &objT->UnitCreatePoint, state);
        Marshal(node.GetChildNode(nameof(DefaultProductionExitUpdateModuleData.NaturalRallyPoint), null), &objT->NaturalRallyPoint, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
