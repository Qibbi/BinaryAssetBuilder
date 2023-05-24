using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct AudioLoopUpgradeModuleData
{
    public UpgradeModuleData Base;
    public AssetReference<BaseAudioEventInfo, AudioEventInfo> SoundToPlay;
    public uint KillAfterMS;
    public SageBool KillOnDeath;
}
