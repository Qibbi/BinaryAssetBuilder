using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct HighlightReachableTargetsSpecialAbilityUpdateModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public AssetReference<FXList> HighlightFX;
    public TypedAssetId<ModuleData> ModuleId;
}
