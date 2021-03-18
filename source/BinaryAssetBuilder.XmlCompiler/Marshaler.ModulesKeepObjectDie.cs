using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, KeepObjectDieModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(KeepObjectDieModuleData.CollapsingTime), "0s"), &objT->CollapsingTime, state);
        Marshal(node.GetAttributeValue(nameof(KeepObjectDieModuleData.StayOnRadar), "false"), &objT->StayOnRadar, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
