using System.Runtime.InteropServices;
using Relo;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct PassiveAreaEffectBehaviorModuleData
{
    public UpdateModuleData Base;
    public float EffectRadius;
    public uint MaxBeneficiaries;
    public Percentage HealingPercentPerSecond;
    public float HealingPointsPerSecond;
    public uint SurveyDelayFrames;
    public AssetReference<UpgradeTemplate> UpgradeRequired;
    public AttributeModifierCategoryBitFlags AntiCategoryMask;
    public AssetReference<FXList> AntiFX;
    public AssetReference<FXList> HealFX;
    public List<AssetReference<AttributeModifier>> Modifier;
    public unsafe ObjectFilter* AllowFilter;
    public SageBool NonStackable;
    public SageBool AffectAttached;
    public SageBool AffectWoundedOnly;
    public SageBool AffectUnderAttack;
}
