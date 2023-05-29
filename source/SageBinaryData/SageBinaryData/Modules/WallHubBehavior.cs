using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct WallHubBehaviorModuleData
{
    public UpdateModuleData Base;
    public TypedAssetId<GameObject> HubCapTemplateId;
    public TypedAssetId<GameObject> DefaultSegmentTemplateId;
    public TypedAssetId<GameObject> CliffCapTemplateId;
    public TypedAssetId<GameObject> ShoreCapTemplateId;
    public TypedAssetId<GameObject> BorderCapTemplateId;
    public TypedAssetId<GameObject> ElevatedSegmentTemplateId;
    public float BuilderRadius;
    public float MaxBuildoutDistance;
    public uint Options;
    public int StaggeredBuildFactor;
    public List<TypedAssetId<GameObject>> SegmentPattern;
}
