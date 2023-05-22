using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SlavedUpdateModuleData
{
    public UpdateModuleData Base;
    public int LeashRange;
    public int GuardMaxRange;
    public int GuardWanderRange;
    public int AttackRange;
    public int AttackWanderRange;
    public int ScoutRange;
    public int ScoutWanderRange;
    public int DistToTargetToGrantRangeBonus;
    public int RepairRange;
    public float RepairMinAltitude;
    public float RepairMaxAltitude;
    public int RepairWhenHealthBelowPercentage;
    public float RepairRatePerSecond;
    public int MinReadyFrames;
    public int MaxReadyFrames;
    public int MinWeldFrames;
    public int MaxWeldFrames;
    public AssetReference<FXParticleSystemTemplate> WeldingSysId;
    public AnsiString WeldingFXBone;
    public DamageType DieOnMastersDeathDamageType;
    public DeathType DieOnMastersDeathType;
    public int FadeOutRange;
    public uint FadeTime;
    public unsafe Coord3D* GuardPosOffset;
    public SageBool StayOnSameLayerAsMaster;
    public SageBool DieOnMastersDeath;
    public SageBool MarkUnselectable;
    public SageBool UseSlaverAsControlForEvaObjectSightedEvents;
}
