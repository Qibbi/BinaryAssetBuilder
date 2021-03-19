using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EvaAnnounceClientCreateModuleData
    {
        public ClientUpdateModuleData Base;
        public unsafe AnsiString* AnnouncementEventEnemy;
        public unsafe AnsiString* AnnouncementEventAlly;
        public unsafe AnsiString* AnnouncementEventOwner;
        public uint DelayBeforeAnnouncementLogicFrames;
        public SageBool OnlyIfVisible;
        public SageBool CountAsFirstSightedAnnouncement;
        public SageBool UseObjectsPosition;
        public SageBool CreateFakeRadarEvent;
    }
}
