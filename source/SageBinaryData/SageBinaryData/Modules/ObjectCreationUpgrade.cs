using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ObjectCreationUpgradeModuleData
{
    public UpgradeModuleData Base;
    public AssetReference<ObjectCreationList> UpgradeObject;
    public uint Delay;
    public AssetReference<UpgradeTemplate> RemoveUpgrade;
    public AssetReference<UpgradeTemplate> GrantUpgrade;
    public TypedAssetId<GameObject> ThingToSpawn;
    public Angle Angle;
    public uint FadeInTime;
    public unsafe Coord3D* Offset;
    public SageBool DestroyWhenSold;
    public SageBool UseBuildingProduction;
}
