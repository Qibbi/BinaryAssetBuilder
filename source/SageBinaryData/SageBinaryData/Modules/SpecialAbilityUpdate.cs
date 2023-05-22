using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

public enum SpecialAbilityUpdateOptionsType
{
    CHECK_SPECIALPOWER_REQUIREMENTS_DURING_UPDATE,
    SKIP_PACKING_WITH_NO_TARGET,
    SPECIAL_OBJECTS_PERSISTENT,
    UNIQUE_SPECIAL_OBJECT_TARGETS,
    SPECIAL_OBJECTS_PERSIST_WHEN_OWNER_DIES,
    ALWAYS_VALIDATE_SPECIAL_OBJECTS,
    FLIP_OWNER_AFTER_PACKING,
    FLIP_OWNER_AFTER_UNPACKING,
    DO_CAPTURE_FX,
    LOSE_STEALTH_ON_TRIGGER,
    APPROACH_REQUIRES_LINE_OF_SIGHT,
    CHARGE_ATTACK_SPEED_BOOST,
    MUST_FINISH_ABILITY,
    KILL_ATTRIBUTE_MODIFIER_ON_EXIT,
    KILL_ATTRIBUTE_MODIFIER_ON_REJECTED,
    INSTANT,
    NEED_COLLISION_BEFORE_TRIGGER,
    SUPPRESS_FOR_HORDES,
    APPROACH_UNTIL_MEMBERS_IN_RANGE,
    IGNORE_FACING_CHECK,
    USE_OBJECT_GEOMETRY_FOR_WITHIN_RANGE_CHECK,
    CHECK_CHAINED_COMMAND,
    SHOW_PREPARATION_PROGRESS,
    DESTROY_OCL_REGISTERED_OBJECTS_ON_EXIT,
    UPDATE_REQUIRES_LINE_OF_SIGHT,
    CHECK_PREVENT_CONDITIONS
}

[StructLayout(LayoutKind.Sequential)]
public struct SpecialAbilityUpdateOptionsTypeBitFlags
{
    public const int Count = 26;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

public enum ConditionsType
{
    MOUNTED,
    WEAPON_TOGGLE,
    MOVING
}

[StructLayout(LayoutKind.Sequential)]
public struct ConditionsBitFlags
{
    public const int Count = 3;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

[StructLayout(LayoutKind.Sequential)]
public struct SpecialAbilityUpdateModuleData
{
    public UpdateModuleData Base;
    public Percentage GrabPassengerHealGain;
    public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
    public float StartAbilityRange;
    public float AbilityAbortRange;
    public Time PreparationTime;
    public Time PersistentPrepTime;
    public int PersistentCount;
    public Time PackTime;
    public Time UnpackTime;
    public Time PreTriggerUnstealthTime;
    public SpecialAbilityUpdateOptionsTypeBitFlags Options;
    public float PackUnpackVariationFactor;
    public Time ParalyzeDurationWhenCompleted;
    public Time ParalyzeDurationWhenAborted;
    public TypedAssetId<GameObject> SpecialObject;
    public AnsiString SpecialObjectAttachToBone;
    public uint MaxSpecialObjects;
    public Time EffectDuration;
    public int EffectValue;
    public float EffectRange;
    public float FleeRangeAfterCompletion;
    public AssetReference<FXParticleSystemTemplate> DisableFXParticleSystem;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> PackSound;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> UnpackSound;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> PrepSoundLoop;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> TriggerSound;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> ActiveLoopSound;
    public int AwardXPForTriggering;
    public int SkillPointsForTriggering;
    public int UnpackingVariation;
    public Time FreezeAfterTriggerDuration;
    public ConditionsBitFlags RequiredConditions;
    public ConditionsBitFlags RejectedConditions;
    public ObjectStatusBitFlags SetObjectStatusOnTrigger;
    public ObjectStatusBitFlags ClearObjectStatusOnExit;
    public AnsiString ContactPointOverride;
    public AssetReference<AttributeModifier> TriggerAttributeModifier;
    public Time AttributeModifierDuration;
    public AssetReference<LogicCommand> ChainedButton;
    public uint RequireAndSpendTiberiumOnCaster;
    public DisabledBitFlags DisabledTypesToProcess;
    public DisabledBitFlags DisabledTypesToContinueSoundsFor;
    public unsafe AnimAndDuration* CustomAnimAndDuration;
    public unsafe AnimAndDuration* GrabPassengerAnimAndDuration;
    public SageBool StartRechargeOnExit;
    public SageBool GoIdleInStartPreparation;
    public SageBool FaceTarget;
}
