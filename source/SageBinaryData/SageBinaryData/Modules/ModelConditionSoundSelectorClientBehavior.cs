using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ModelConditionSoundSelectorOverrideBlock
    {
        public ModelConditionBitFlags RequiredFlags;
        public ModelConditionBitFlags ExcludedFlags;
        public unsafe int* VoicePriorityOverride;
        public unsafe AudioArrayVoice* AudioArrayVoice;
        public unsafe AudioArraySound* AudioArraySound;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ModelConditionSoundSelectorClientBehaviorModuleData
    {
        public ClientBehaviorModuleData Base;
        public List<ModelConditionSoundSelectorOverrideBlock> Override;
    }
}
