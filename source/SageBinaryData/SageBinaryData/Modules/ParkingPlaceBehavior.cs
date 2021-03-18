using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ParkingPlaceBehaviorModuleData
    {
        public UpdateModuleData Base;
        public float HealAmount;
        public int NumRows;
        public int NumCols;
        public float ApproachHeight;
        public Time DoorOpenTime;
        public Time DoorCloseTime;
        public unsafe ObjectFilter* CanParkHereFilter;
        public unsafe Coord3D* DefaultRallyPointOffset;
        public SageBool ParkInHangars;
        public SageBool LowersOntoParkingPlaceOnProduction;
        public SageBool CanSetRallyPoint;
    }
}
