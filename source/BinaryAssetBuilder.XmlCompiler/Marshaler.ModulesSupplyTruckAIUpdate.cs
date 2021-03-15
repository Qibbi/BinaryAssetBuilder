using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SupplyTruckAIUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.MaxBoxes), null), &objT->MaxBoxes, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.SupplyCenterActionDelay), null), &objT->SupplyCenterActionDelay, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.SupplyWarehouseActionDelay), null), &objT->SupplyWarehouseActionDelay, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.SupplyWarehouseScanDistance), null), &objT->SupplyWarehouseScanDistance, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.DepletedAnnounceDistance), "2000"), &objT->DepletedAnnounceDistance, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.HarvestTrees), null), &objT->HarvestTrees, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.HarvestTiberium), null), &objT->HarvestTiberium, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.HarvestActivationRange), null), &objT->HarvestActivationRange, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.HarvestPreparationTime), null), &objT->HarvestPreparationTime, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.HarvestActionTime), null), &objT->HarvestActionTime, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.HarvestsFromRearEnd), "false"), &objT->HarvestsFromRearEnd, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.CanPathThroughUnitsWhileDocking), "true"), &objT->CanPathThroughUnitsWhileDocking, state);
        Marshal(node.GetAttributeValue(nameof(SupplyTruckAIUpdateModuleData.CanPathThroughUnitsWhileHarvesting), "true"), &objT->CanPathThroughUnitsWhileHarvesting, state);
        Marshal(node, (AIUpdateModuleData*)objT, state);
    }
}
