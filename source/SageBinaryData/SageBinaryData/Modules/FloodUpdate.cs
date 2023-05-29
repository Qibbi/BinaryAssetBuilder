#if KANESWRATH
using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FloodMemberData
{
    public TypedAssetId<GameObject> UnitType;
    public float Speed;
    public Coord3D ControlPointOffsetOne;
    public Coord3D ControlPointOffsetTwo;
    public Coord3D ControlPointOffsetThree;
    public Coord3D ControlPointOffsetFour;
}

[StructLayout(LayoutKind.Sequential)]
public struct FloodUpdateModuleData
{
    public UpdateModuleData Base;
    public float AngleOfFlow;
    public List<FloodUpdateModuleData> DataList;
    public SageBool IsDirectionRelative;
}
#endif
