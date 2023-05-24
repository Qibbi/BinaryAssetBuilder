using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, QueueProductionExitUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(QueueProductionExitUpdateModuleData.PlacementViewAngle), null), &objT->PlacementViewAngle, state);
        Marshal(node.GetAttributeValue(nameof(QueueProductionExitUpdateModuleData.ExitDelay), "0"), &objT->ExitDelay, state);
        Marshal(node.GetAttributeValue(nameof(QueueProductionExitUpdateModuleData.AllowAirborneCreation), "false"), &objT->AllowAirborneCreation, state);
        Marshal(node.GetAttributeValue(nameof(QueueProductionExitUpdateModuleData.InitialBurst), "0"), &objT->InitialBurst, state);
        Marshal(node.GetAttributeValue(nameof(QueueProductionExitUpdateModuleData.NoExitPath), "false"), &objT->NoExitPath, state);
        Marshal(node.GetAttributeValue(nameof(QueueProductionExitUpdateModuleData.CanRallyToSlaughter), "false"), &objT->CanRallyToSlaughter, state);
        Marshal(node.GetAttributeValue(nameof(QueueProductionExitUpdateModuleData.ClearAlliesFromDestination), "true"), &objT->ClearAlliesFromDestination, state);
        Marshal(node.GetChildNode(nameof(QueueProductionExitUpdateModuleData.UnitCreatePoint), null), &objT->UnitCreatePoint, state);
        Marshal(node.GetChildNode(nameof(QueueProductionExitUpdateModuleData.NaturalRallyPoint), null), &objT->NaturalRallyPoint, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
