using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CompositeStructureInfoModuleData
{
    public BehaviorModuleData Base;
    public AssetReference<GameObject> ThingTemplate;
    public uint Count;
    public float BuildableDistance;
    public unsafe ShadowInfo* ConnectionShadowInfo;
}
