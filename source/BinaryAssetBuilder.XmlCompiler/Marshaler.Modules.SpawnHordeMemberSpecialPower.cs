#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SpawnOffsetType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpawnOffsetType.X), "0"), &objT->X, state);
        Marshal(node.GetAttributeValue(nameof(SpawnOffsetType.Y), "0"), &objT->Y, state);
    }

    private static unsafe void Marshal(Node node, SpawnOffsetType** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(SpawnOffsetType), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, SpawnMemberEntryType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpawnMemberEntryType.Object), null), &objT->Object, state);
        Marshal(node.GetAttributeValue(nameof(SpawnMemberEntryType.Count), "1"), &objT->Count, state);
        Marshal(node.GetAttributeValue(nameof(SpawnMemberEntryType.GrantUpgradeOnSpawn), ""), &objT->GrantUpgradeOnSpawn, state);
        Marshal(node.GetAttributeValue(nameof(SpawnMemberEntryType.SpawnAtNextAvailableSpot), "false"), &objT->SpawnAtNextAvailableSpot, state);
        Marshal(node.GetAttributeValue(nameof(SpawnMemberEntryType.SpawnFX), null), &objT->SpawnFX, state);
        Marshal(node.GetChildNode(nameof(SpawnMemberEntryType.SpawnOffset), null), &objT->SpawnOffset, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }

    public static unsafe void Marshal(Node node, SpawnHordeMemberSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpawnHordeMemberSpecialPowerModuleData.AllowBackwardsReformMovement), "false"), &objT->AllowBackwardsReformMovement, state);
        Marshal(node.GetChildNodes(nameof(SpawnHordeMemberSpecialPowerModuleData.SpawnMemberEntry)), &objT->SpawnMemberEntry, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
#endif
