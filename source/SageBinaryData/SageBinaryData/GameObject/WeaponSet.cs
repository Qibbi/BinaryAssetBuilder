using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

public enum WeaponChoiceCriteria
{
    PREFER_MOST_DAMAGE,
    PREFER_LONGEST_RANGE,
    PREFER_GRAB_OVER_DAMAGE,
    PREFER_LEAST_MOVEMENT,
    SELECT_AT_RANDOM,
    USE_WEAPONSET_DEFAULT_CRITERIA
}

[StructLayout(LayoutKind.Sequential)]
public struct CommandSourceBitFlags
{
    public const int Count = 4;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

[StructLayout(LayoutKind.Sequential)]
public struct WeaponTemplateSetSlot
{
    public WeaponSlotType WeaponSlot;
    public AssetReference<WeaponTemplate> WeaponTemplate;
    public KindOfBitFlags PreferredAgainst;
    public KindOfBitFlags OnlyAgainst;
    public CommandSourceBitFlags AutoChooseMask;
    public ModelConditionBitFlags OnlyInCondition;
}

[StructLayout(LayoutKind.Sequential)]
public struct WeaponTemplateSet
{
    public WeaponSetBitFlags Conditions;
    public WeaponSlotType OnlyAgainst;
    public WeaponSlotType OnlyInCondition;
    public WeaponChoiceCriteria DefaultWeaponChoiceCritera;
    public List<WeaponTemplateSetSlot> Slot;
    public SageBool ShareWeaponReloadTime;
    public SageBool WeaponLockSharedAcrossSets;
    public SageBool ReadyStatusSharedWithinSet;
}
