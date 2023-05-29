using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SetLocomotorSpeedUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SetLocomotorSpeedUpdateModuleData.Type), nameof(SetLocomotorSpeedUpdateType.INVALID)), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(SetLocomotorSpeedUpdateModuleData.LocomotorSpeedToSet), "0.0"), &objT->LocomotorSpeedToSet, state);
        Marshal(node.GetAttributeValue(nameof(SetLocomotorSpeedUpdateModuleData.LocomotorDeltaPerUpdate), "0.0"), &objT->LocomotorDeltaPerUpdate, state);
        Marshal(node.GetAttributeValue(nameof(SetLocomotorSpeedUpdateModuleData.OtherScaredScanRangeMultiplier), "0.0"), &objT->OtherScaredScanRangeMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(SetLocomotorSpeedUpdateModuleData.ObjectFilterRange), "0.0"), &objT->ObjectFilterRange, state);
        Marshal(node.GetAttributeValue(nameof(SetLocomotorSpeedUpdateModuleData.UpdatePeriod), "1.0s"), &objT->UpdatePeriod, state);
        Marshal(node.GetAttributeValue(nameof(SetLocomotorSpeedUpdateModuleData.VisionArc), "180d"), &objT->VisionArc, state);
        Marshal(node.GetChildNode(nameof(SetLocomotorSpeedUpdateModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
