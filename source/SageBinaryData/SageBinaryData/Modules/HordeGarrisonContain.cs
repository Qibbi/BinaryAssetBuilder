using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct HordeGarrisonContainModuleData
{
    public GarrisonContainModuleData Base;
    public uint ExitDelay;
    public unsafe Coord3D* EntryOffset;
    public unsafe Coord3D* EntryPosition;
    public unsafe Coord3D* ExitOffset;
}
