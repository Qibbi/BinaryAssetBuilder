using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXListBehaviorEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FXListBehaviorEvent.Index), null), &objT->Index, state);
        Marshal(node.GetAttributeValue(nameof(FXListBehaviorEvent.FX), null), &objT->FX, state);
        Marshal(node.GetAttributeValue(nameof(FXListBehaviorEvent.MinThreshold), "0"), &objT->MinThreshold, state);
        Marshal(node.GetAttributeValue(nameof(FXListBehaviorEvent.MaxThreshold), "0"), &objT->MaxThreshold, state);
        Marshal(node.GetAttributeValue(nameof(FXListBehaviorEvent.OrientToObject), "true"), &objT->OrientToObject, state);
        Marshal(node.GetAttributeValue(nameof(FXListBehaviorEvent.ForceUseDoFXObj), "false"), &objT->ForceUseDoFXObj, state);
        Marshal(node.GetAttributeValue(nameof(FXListBehaviorEvent.Direction), nameof(FXListBehaviorDirection.Default)), &objT->Direction, state);
    }

    public static unsafe void Marshal(Node node, FXListBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(FXListBehaviorModuleData.Event)), &objT->Event, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
