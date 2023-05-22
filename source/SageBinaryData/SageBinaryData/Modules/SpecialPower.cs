using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct SpecialPowerModuleData
{
    public BehaviorModuleData Base;
    public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
    public AttributeModifierCategoryBitFlags AntiCategory;
    public AssetReference<FXList> AntiFX;
    public AssetReference<AttributeModifier> AttributeModifier;
    public float AttributeModifierRange;
    public AssetReference<FXList> AttributeModifierFX;
    public Duration WeatherDuration;
    public List<AnsiString> RequirementsFilterMPSkirmish;
    public AssetReference<FXList> InitiateFX;
    public AssetReference<FXList> TriggerFX;
    public ModelConditionFlagType SetModelCondition;
    public Time SetModelConditionTime;
    public int GiveLevels;
    public WeatherType ChangeWeather;
    public TypedAssetId<SpecialPowerTemplate> OnTriggerRechargeSpecialPower;
    public uint BurnDecayModifier;
    public float MaxDistanceFromCommandCenter;
    public ObjectFilter AttributeModifierAffects;
    public ObjectFilter RequirementsFilterMP;
    public ObjectFilter RequirementsFilterStrategic;
    public unsafe SoundOrEvaEvent* InitiateSound;
    public SageBool UpdateModuleStartsAttack;
    public SageBool StartsPaused;
    public SageBool ReEnableAntiCategory;
    public SageBool AttributeModifierAffectsSelf;
    public SageBool AttributeModifierWeatherBased;
    public SageBool TargetEnemy;
    public SageBool TargetAllSides;
    public SageBool DisableDuringAnimDuration;
    public SageBool IdleWhenStartingPower;
    public SageBool AffectGood;
    public SageBool AffectEvil;
    public SageBool AffectAllies;
    public SageBool AvailableAtStart;
    public SageBool AdjustVictim;
    public SageBool UseDistanceFromCommandCenter;
    public SageBool ChildModuleHandlesFX;
}
