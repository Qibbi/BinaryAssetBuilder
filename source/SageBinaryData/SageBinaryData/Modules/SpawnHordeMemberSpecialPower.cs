#if KANESWRATH
using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SpawnOffsetType
{
    public float X;
    public float Y;
}

[StructLayout(LayoutKind.Sequential)]
public struct SpawnMemberEntryType
{
    public TypedAssetId<GameObject> Object;
    public uint Count;
    public TypedAssetId<UpgradeTemplate> GrantUpgradeOnSpawn;
    public AssetReference<FXList> SpawnFX;
    public unsafe SpawnOffsetType* SpawnOffset;
    public SageBool SpawnAtNextAvailableSpot;
}

[StructLayout(LayoutKind.Sequential)]
public struct SpawnHordeMemberSpecialPowerModuleData
{
    public SpecialPowerModuleData Base;
    public List<SpawnMemberEntryType> SpawnMemberEntry;
    public SageBool AllowBackwardsReformMovement;
}
#endif
