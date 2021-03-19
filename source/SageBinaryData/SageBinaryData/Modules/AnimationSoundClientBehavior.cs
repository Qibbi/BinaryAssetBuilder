using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationSoundInfo
    {
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> Sound;
        public unsafe ModelConditionBitFlags* RequiredMC;
        public unsafe ModelConditionBitFlags* ExcludedMC;
        public TypedAssetId<W3DAnimation> Animation;
        public List<int> Frame;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimationSoundClientBehaviorModuleData
    {
        public ClientBehaviorModuleData Base;
        public unsafe float* MaxUpdateRangeCap;
        public List<AnimationSoundInfo> Sound;
    }
}
