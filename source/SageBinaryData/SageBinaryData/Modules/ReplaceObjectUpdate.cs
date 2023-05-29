using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ReplaceObjectNugget
{
    public unsafe ObjectFilter* TargetObjectFilter;
    public List<TypedAssetId<GameObject>> ReplacementObject;
}

[StructLayout(LayoutKind.Sequential)]
public struct ReplaceObjectUpdateModuleData
{
    public SpecialAbilityUpdateModuleData Base;
    public float ReplaceRadius;
    public AssetReference<FXList> ReplaceFX;
    public List<ReplaceObjectNugget> ReplaceObjectNugget;
    public SageBool Scatter;
}
