using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EvaAnnounceSpecialPowerReadyClientUpdateModuleData
    {
        public ClientUpdateModuleData Base;
        public unsafe AnsiString* AnnouncementEventEnemy;
        public unsafe AnsiString* AnnouncementEventAlly;
        public unsafe AnsiString* AnnouncementEventOwner;
        public AssetReference<SpecialPowerTemplate> SpecialPowerTemplate;
        public SageBool JustMonitorPercentReady;
    }
}
