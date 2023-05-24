using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

public enum InitiateRepairDieOptions
{
    REPAIR_INSTANT
}

[StructLayout(LayoutKind.Sequential)]
public struct InitiateRepairDieOptionsFlag
{
    public const int Count = 0x00000001;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

[StructLayout(LayoutKind.Sequential)]
public struct InitiateRepairDieModuleData
{
    public UpdateModuleData Base;
    public Time DelayTime;
    public AssetReference<FXList> MasterDeadDieFX;
    public InitiateRepairDieOptionsFlag Options;
    public ModelConditionFlagType InstantRepairModelCondition;
    public Time InstantRepairAnimDuration;
    public unsafe DieMuxDataType* Die;
}
