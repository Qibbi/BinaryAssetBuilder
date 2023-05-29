#if KANESWRATH
using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct AuraObjectDataType
{
    public float Radius;
    public ObjectStatusBitFlags StatusToSet;
    public ObjectStatusBitFlags StatusToClear;
    public ObjectFilter Filter;
    public List<TypedAssetId<UpgradeTemplate>> Upgrade;
}

[StructLayout(LayoutKind.Sequential)]
public struct MetaUpgradeAuraBehaviorModuleData
{
    public BehaviorModuleData Base;
    public List<AuraObjectDataType> AuraObject;
}
#endif
