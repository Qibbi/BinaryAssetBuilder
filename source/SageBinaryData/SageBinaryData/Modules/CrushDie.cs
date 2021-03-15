using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CrushDieModuleData
    {
        public DieModuleData Base;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> TotalCrushSound;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> BackEndCrushSound;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> FrontEndCrushSound;
        public Percentage TotalCrushSoundPercent;
        public Percentage BackEndCrushSoundPercent;
        public Percentage FrontEndCrushSoundPercent;
    }
}
