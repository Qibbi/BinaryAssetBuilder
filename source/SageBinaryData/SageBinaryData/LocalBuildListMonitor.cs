using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LocalBuildListMonitor
    {
        public BaseAssetType Base;
        public Time TimeBetweenUpdates;
        public uint UpdatesToSkipAfterStart;
        public uint UpdatesToSkipAfterSaveFileLoad;
        public uint UpdatesToSkipAfterTargetPlayerChanges;
        public unsafe ObjectFilter* ProducerObjectFilter;
    }
}
