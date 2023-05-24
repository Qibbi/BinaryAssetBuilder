using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct QueueProductionExitUpdateModuleData
{
    public UpdateModuleData Base;
    public Angle PlacementViewAngle;
    public uint ExitDelay;
    public uint InitialBurst;
    public Coord3D UnitCreatePoint;
    public Coord3D NaturalRallyPoint;
    public SageBool AllowAirborneCreation;
    public SageBool NoExitPath;
    public SageBool CanRallyToSlaughter;
    public SageBool ClearAlliesFromDestination;
}
