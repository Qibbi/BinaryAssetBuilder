using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DockUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DockUpdateModuleData.NumberApproachPositions), null), &objT->NumberApproachPositions, state);
        Marshal(node.GetAttributeValue(nameof(DockUpdateModuleData.AllowsPassthrough), null), &objT->AllowsPassthrough, state);
        Marshal(node.GetAttributeValue(nameof(DockUpdateModuleData.GoToRallyPointAfterDock), "false"), &objT->GoToRallyPointAfterDock, state);
        Marshal(node.GetAttributeValue(nameof(DockUpdateModuleData.ShouldDockInReverse), "false"), &objT->ShouldDockInReverse, state);
        Marshal(node.GetAttributeValue(nameof(DockUpdateModuleData.MinDockTime), "0s"), &objT->MinDockTime, state);
        Marshal(node.GetAttributeValue(nameof(DockUpdateModuleData.ObjectsInLineWeight), "13s"), &objT->ObjectsInLineWeight, state);
        Marshal(node.GetChildNode(nameof(DockUpdateModuleData.ForVoiceRetreatThisIsASafeHarborToObjectFilter), null), &objT->ForVoiceRetreatThisIsASafeHarborToObjectFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
