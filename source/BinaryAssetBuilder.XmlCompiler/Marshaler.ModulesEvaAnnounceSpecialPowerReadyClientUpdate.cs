using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, EvaAnnounceSpecialPowerReadyClientUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceSpecialPowerReadyClientUpdateModuleData.AnnouncementEventEnemy), null), &objT->AnnouncementEventEnemy, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceSpecialPowerReadyClientUpdateModuleData.AnnouncementEventAlly), null), &objT->AnnouncementEventAlly, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceSpecialPowerReadyClientUpdateModuleData.AnnouncementEventOwner), null), &objT->AnnouncementEventOwner, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceSpecialPowerReadyClientUpdateModuleData.SpecialPowerTemplate), null), &objT->SpecialPowerTemplate, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceSpecialPowerReadyClientUpdateModuleData.JustMonitorPercentReady), "false"), &objT->JustMonitorPercentReady, state);
        Marshal(node, (ClientUpdateModuleData*)objT, state);
    }
}
