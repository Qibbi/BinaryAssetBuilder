using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum InvisibilityUpdateOptions
    {
        STARTS_ACTIVE,
        BROADCAST,
        BROADCAST_INVERSE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InvisibilityUpdateOptionsBitFlags
    {
        public const int Count = 0x00000003;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InvisibilityUpdateModuleData
    {
        public UpdateModuleData Base;
        public InvisibilityUpdateOptionsBitFlags Options;
        public Time UpdatePeriod;
        public float BroadcastRange;
        public Percentage OpacityMin;
        public Percentage OpacityMax;
        public unsafe StringHash* NamedVoiceNameToUseAsVoiceMoveToStealthyArea;
        public unsafe StringHash* NamedVoiceNameToUseAsVoiceEnterStateMoveToStealthyArea;
        public InvisibilityNuggetType InvisibilityNugget;
        public unsafe ObjectFilter* BroadcastObjectFilter;
        public unsafe TypedAssetId<UpgradeTemplate>* RequiresUpgrade;
    }
}
