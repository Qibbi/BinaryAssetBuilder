using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ModelConditionAudioLoopClientBehaviorModuleDataModelConditionSound
    {
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo>* Sound;
        public ModelConditionBitFlags RequiredFlags;
        public ModelConditionBitFlags ExcludedFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ModelConditionAudioLoopClientBehaviorModuleData
    {
        public ClientBehaviorModuleData Base;
        public List<ModelConditionAudioLoopClientBehaviorModuleDataModelConditionSound> ModelConditionSound;
    }
}
