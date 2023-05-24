using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

public enum SlowDeathPhaseType
{
    INITIAL,
    MIDPOINT,
    FINAL,
    HIT_GROUND
}

[StructLayout(LayoutKind.Sequential)]
public struct SlowDeathBaseType
{
    public SlowDeathPhaseType Type;
}

[StructLayout(LayoutKind.Sequential)]
public struct SlowDeathFXListType
{
    public SlowDeathBaseType Base;
    public List<AssetReference<FXList>> FX;
}

[StructLayout(LayoutKind.Sequential)]
public struct SlowDeathOCLType
{
    public SlowDeathBaseType Base;
    public List<AssetReference<ObjectCreationList>> OCL;
}

[StructLayout(LayoutKind.Sequential)]
public struct SlowDeathWeaponType
{
    public SlowDeathBaseType Base;
    public List<AssetReference<WeaponTemplate>> Weapon;
}

[StructLayout(LayoutKind.Sequential)]
public struct SlowDeathSoundType
{
    public SlowDeathBaseType Base;
    public List<AnsiString> List;
}

[StructLayout(LayoutKind.Sequential)]
public struct SlowDeathBehaviorModuleData
{
    public UpdateModuleData Base;
    public Velocity SinkRate;
    public int ProbabilityModifier;
    public Percentage ModifierBonusPerOverkillPercent;
    public Time SinkDelay;
    public Time SinkDelayVariance;
    public Time DestructionDelay;
    public Time DestructionDelayVariance;
    public Time DecayBeginTime;
    public float FlingForce;
    public float FlingForceVariance;
    public Angle FlingPitch;
    public Angle FlingPitchVariance;
    public ModelConditionBitFlags DeathFlags;
    public Time FadeTime;
    public Time FadeDelay;
    public ModelConditionBitFlags DeathTypes;
    public ObjectStatusBitFlags DeathObjectStatusBits;
    public List<SlowDeathFXListType> FX;
    public List<SlowDeathOCLType> OCL;
    public List<SlowDeathWeaponType> Weapon;
    public List<SlowDeathSoundType> Sound;
    public unsafe DieMuxDataType* DieMuxData;
    public SageBool ShadowWhenDead;
    public SageBool Fade;
}
