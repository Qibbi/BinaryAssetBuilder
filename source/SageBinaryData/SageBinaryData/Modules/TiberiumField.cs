using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct TiberiumFieldBehaviorModuleData
{
    public UpdateModuleData Base;
    public Time DamageUpdateFrequencySeconds;
    public Time HealUpdateFrequencySeconds;
    public float Radius;
    public float DamageRadiusAdd;
    public float HealRadiusAdd;
    public int FieldResolution;
    public int MaxFieldMoney;
    public int StartingFieldMoney;
    public TypedAssetId<GameObject> ThingToSpawn;
    public float SpawnOffset;
    public float ClusterScaleFactor;
    public float ClusterPowerFactor;
    public int CrystalGrowthRate;
    public uint LifetimeFieldMoney;
    public unsafe ObjectFilter* DamageFilter;
    public unsafe ObjectFilter* HealFilter;
    public SageBool KillWhenEmptyAndFinishedSpawning;
    public SageBool AllowStartingFieldCrystalsToGrow;
}
