using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RepairUpdateModuleDataPercentOfBuildCostToRebuildInfo
    {
        public Percentage Pristine;
        public Percentage Damaged;
        public Percentage ReallyDamaged;
        public Percentage Rubble;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RepairUpdateModuleDataSelfAudio
    {
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> SelfRepairFromDamageLoop;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> SelfRepairFromRubbleLoop;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RepairUpdateModuleData
    {
        public UpdateModuleData Base;
        public float RepopThreshold;
        public uint HealAmountPerSecond;
        public RepairUpdateModuleDataPercentOfBuildCostToRebuildInfo PercentOfBuildCostToRebuildInfo;
        public RepairUpdateModuleDataSelfAudio SelfAudio;
        public SageBool Toggleable;
        public SageBool RepairableWhenDead;
    }
}
