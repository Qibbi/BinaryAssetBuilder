using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FXCreationList
{
    public AnsiString Bone;
    public AssetReference<FXList> FX;
}

[StructLayout(LayoutKind.Sequential)]
public struct FlammableUpdateModuleData
{
    public UpdateModuleData Base;
    public Time BurnedDelay;
    public Time AflameDuration;
    public int AflameDamageAmount;
    public Time AflameDamageDelay;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> BurningSoundName;
    public float FlameDamageLimit;
    public Time FlameDamageExpiration;
    public float RunToWaterDepth;
    public float RunToWaterSearchRadius;
    public float RunToWaterSearchIncrement;
    public DamageType DamageType;
    public unsafe FXCreationList* FireFXList;
    public unsafe AnimAndDuration* CustomAnimAndDuration;
    public SageBool SetBurnedStatus;
    public SageBool SwapModelWhenAflame;
    public SageBool SwapModelWhenQuenched;
    public SageBool SwapTextureWhenAflame;
    public SageBool SwapTextureWhenQuenhed;
    public SageBool BurnContained;
    public SageBool RunToWater;
    public SageBool PanicLocomotorWhileAflame;
}
