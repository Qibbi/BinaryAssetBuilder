using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SupplyTruckAIUpdateModuleData
    {
        public AIUpdateModuleData Base;
        public uint MaxBoxes;
        public Time SupplyCenterActionDelay;
        public Time SupplyWarehouseActionDelay;
        public float SupplyWarehouseScanDistance;
        public float DepletedAnnounceDistance;
        public float HarvestActivationRange;
        public Time HarvestPreparationTime;
        public Time HarvestActionTime;
        public SageBool HarvestTrees;
        public SageBool HarvestTiberium;
        public SageBool HarvestsFromRearEnd;
        public SageBool CanPathThroughUnitsWhileDocking;
        public SageBool CanPathThroughUnitsWhileHarvesting;
    }
}
