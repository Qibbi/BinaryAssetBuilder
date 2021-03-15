using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DefaultProductionExitUpdateModuleData
    {
        public UpdateModuleData Base;
        public unsafe Coord3D* UnitCreatePoint;
        public unsafe Coord3D* NaturalRallyPoint;
    }
}
