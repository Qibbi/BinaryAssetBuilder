using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, EvaAnnounceClientCreateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceClientCreateModuleData.AnnouncementEventEnemy), null), &objT->AnnouncementEventEnemy, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceClientCreateModuleData.AnnouncementEventAlly), null), &objT->AnnouncementEventAlly, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceClientCreateModuleData.AnnouncementEventOwner), null), &objT->AnnouncementEventOwner, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceClientCreateModuleData.DelayBeforeAnnouncementLogicFrames), "0"), &objT->DelayBeforeAnnouncementLogicFrames, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceClientCreateModuleData.OnlyIfVisible), "false"), &objT->OnlyIfVisible, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceClientCreateModuleData.CountAsFirstSightedAnnouncement), "false"), &objT->CountAsFirstSightedAnnouncement, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceClientCreateModuleData.UseObjectsPosition), "false"), &objT->UseObjectsPosition, state);
        Marshal(node.GetAttributeValue(nameof(EvaAnnounceClientCreateModuleData.CreateFakeRadarEvent), "false"), &objT->CreateFakeRadarEvent, state);
        Marshal(node, (ClientUpdateModuleData*)objT, state);
    }
}
