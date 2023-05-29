using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ClearanceTestingSlowDeathBehaviorModuleData
{
    public SlowDeathBehaviorModuleData Base;
    public float ClearanceMaxHeight;
    public float ClearanceMaxHeightFraction;
    public float ClearanceMinHeight;
    public float ClearanceMinHeightFraction;
    public unsafe GeometryInfo* ClearanceGeometry;
    public unsafe Coord3D* ClearanceGeometryOffset;
}
