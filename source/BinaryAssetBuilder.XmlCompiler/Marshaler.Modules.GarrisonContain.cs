using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InitialRoster* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InitialRoster.TemplateId), null), &objT->TemplateId, state);
        Marshal(node.GetAttributeValue(nameof(InitialRoster.Count), null), &objT->Count, state);
    }

    private static unsafe void Marshal(Node node, InitialRoster** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(InitialRoster), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, GarrisonContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GarrisonContainModuleData.MobileGarrison), null), &objT->MobileGarrison, state);
        Marshal(node.GetAttributeValue(nameof(GarrisonContainModuleData.ImmuneToClearBuildingAttacks), null), &objT->ImmuneToClearBuildingAttacks, state);
        Marshal(node.GetAttributeValue(nameof(GarrisonContainModuleData.ResetInitialTeamOnCapture), "false"), &objT->ResetInitialTeamOnCapture, state);
        Marshal(node.GetChildNode(nameof(GarrisonContainModuleData.InitialRoster), null), &objT->InitialRoster, state);
        Marshal(node, (OpenContainModuleData*)objT, state);
    }
}
