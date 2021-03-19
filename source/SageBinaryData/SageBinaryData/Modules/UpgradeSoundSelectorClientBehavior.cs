using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UpgradeSoundSelectorOverrideBlock
    {
        public ModelConditionBitFlags RequiredModelConditions;
        public ModelConditionBitFlags ConflictingModelConditions;
        public unsafe int* VoicePriorityOverride;
        public unsafe AudioArrayVoice* AudioArrayVoice;
        public unsafe AudioArraySound* AudioArraySound;
        public List<TypedAssetId<UpgradeTemplate>> RequiredUpgrade;
        public List<TypedAssetId<UpgradeTemplate>> ConflictingUpgrade;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UpgradeSoundSelectorClientBehaviorModuleData
    {
        public ClientBehaviorModuleData Base;
        public List<UpgradeSoundSelectorOverrideBlock> Override;
    }
}
