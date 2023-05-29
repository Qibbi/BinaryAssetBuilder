using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ParkingPlaceBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ParkingPlaceBehaviorModuleData.HealAmount), null), &objT->HealAmount, state);
        Marshal(node.GetAttributeValue(nameof(ParkingPlaceBehaviorModuleData.NumRows), null), &objT->NumRows, state);
        Marshal(node.GetAttributeValue(nameof(ParkingPlaceBehaviorModuleData.NumCols), null), &objT->NumCols, state);
        Marshal(node.GetAttributeValue(nameof(ParkingPlaceBehaviorModuleData.ApproachHeight), null), &objT->ApproachHeight, state);
        Marshal(node.GetAttributeValue(nameof(ParkingPlaceBehaviorModuleData.ParkInHangars), null), &objT->ParkInHangars, state);
        Marshal(node.GetAttributeValue(nameof(ParkingPlaceBehaviorModuleData.DoorOpenTime), "0s"), &objT->DoorOpenTime, state);
        Marshal(node.GetAttributeValue(nameof(ParkingPlaceBehaviorModuleData.DoorCloseTime), "0s"), &objT->DoorCloseTime, state);
        Marshal(node.GetAttributeValue(nameof(ParkingPlaceBehaviorModuleData.LowersOntoParkingPlaceOnProduction), "false"), &objT->LowersOntoParkingPlaceOnProduction, state);
        Marshal(node.GetAttributeValue(nameof(ParkingPlaceBehaviorModuleData.CanSetRallyPoint), "true"), &objT->CanSetRallyPoint, state);
        Marshal(node.GetChildNode(nameof(ParkingPlaceBehaviorModuleData.CanParkHereFilter), null), &objT->CanParkHereFilter, state);
        Marshal(node.GetChildNode(nameof(ParkingPlaceBehaviorModuleData.DefaultRallyPointOffset), null), &objT->DefaultRallyPointOffset, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
