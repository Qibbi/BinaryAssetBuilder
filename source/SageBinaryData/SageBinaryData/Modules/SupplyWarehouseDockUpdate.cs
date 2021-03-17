using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SupplyWarehouseDockUpdateModuleData
    {
        public DockUpdateModuleData Base;
        public int StartingBoxes;
        public SageBool DeleteWhenEmpty;
    }
}
