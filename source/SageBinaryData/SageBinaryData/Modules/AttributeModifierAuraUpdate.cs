using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

public enum AttributeModifierAuraUpdateRequired
{
    MOUNTED,
    TAINT,
    ELVEN_WOOD
}

[StructLayout(LayoutKind.Sequential)]
public struct AttributeModifierAuraUpdateRequiredBitFlags
{
    public const int Count = 3;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

[StructLayout(LayoutKind.Sequential)]
public struct AttributeModifierAuraUpdateModuleData
{
    public UpgradeModuleData Base;
    public AssetReference<AttributeModifier> AttributeModifierName;
    public Time RefreshDelay;
    public float Range;
    public AttributeModifierAuraUpdateRequiredBitFlags RequiredConditions;
    public AttributeModifierCategoryBitFlags AntiCategory;
    public AssetReference<FXList> AntiFX;
    public int MaxActiveRank;
    public ObjectStatusBitFlags RequiredObjectStatusFlags;
    public unsafe ObjectFilter* ObjectFilter;
    public SageBool TargetEnemy;
    public SageBool AllowPowerWhenAttacking;
    public SageBool InitiallyActive;
    public SageBool AffectGood;
    public SageBool AffectEvil;
    public SageBool RunWhileDead;
    public SageBool AllowSelf;
    public SageBool AffectContainedOnly;
    public SageBool AffectHordeMembersOnly;
}
