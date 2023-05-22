using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SelfAudio
{
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> SelfBuildingLoop;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> SelfRepairFromDamageLoop;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> SelfRepairFromRubbleLoop;
}

[StructLayout(LayoutKind.Sequential)]
public struct PercentOfBuildCostToRebuildInfo
{
    public Percentage Pristine;
    public Percentage Damaged;
    public Percentage ReallyDamaged;
    public Percentage Rubble;
}

[StructLayout(LayoutKind.Sequential)]
public struct GettingBuiltBehaviorModuleData
{
    public UpdateModuleData Base;
    public TypedAssetId<GameObject> WorkerTemplate;
    public TypedAssetId<GameObject> EvilWorkerTemplate;
    public float SpawnTimer;
    public AssetReference<WeaponTemplate> HealWeapon;
    public float RebuildTimeSeconds;
    public float DisallowRebuildRange;
    public PercentOfBuildCostToRebuildInfo PercentOfBuildCostToRebuildInfo;
    public SelfAudio SelfAudio;
    public unsafe ObjectFilter* DisallowRebuildFilter;
    public SageBool TestFaction;
    public SageBool RebuildWhenDead;
    public SageBool UseSpawnTimerWithoutWorker;
}
