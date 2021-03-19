using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RandomSoundSelectorClientBehaviorModuleData
    {
        public ClientBehaviorModuleData Base;
        public Percentage Chance;
        public unsafe int* VoicePriorityOverride;
        public unsafe AudioArrayVoice* AudioArrayVoice;
        public unsafe AudioArraySound* AudioArraySound;
        public SageBool RerollOnEveryFrame;
    }
}
