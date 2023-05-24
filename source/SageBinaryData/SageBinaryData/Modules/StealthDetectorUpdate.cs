using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct StealthDetectorUpdateModuleData
{
    public UpgradeModuleData Base;
    public Time DetectionRate;
    public float DetectionRange;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> PingSound;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> LoudPingSound;
    public AssetReference<FXParticleSystemTemplate> IRBeaconParticleSys;
    public AssetReference<FXParticleSystemTemplate> IRParticleSys;
    public AssetReference<FXParticleSystemTemplate> IRBrightParticleSys;
    public AssetReference<FXParticleSystemTemplate> IRGridParticleSys;
    public AnsiString IRParticleSysBone;
    public KindOfBitFlags ExtraRequiredKindOf;
    public KindOfBitFlags ExtraForbiddenKindOf;
    public AssetReference<UpgradeTemplate> RequiredUpgrade;
    public SageBool InitiallyDisabled;
    public SageBool CanDetectWhileGarrisoned;
    public SageBool CanDetectWhileContained;
#if KANESWRATH
    public SageBool UseMetaAOI;
#endif
}
