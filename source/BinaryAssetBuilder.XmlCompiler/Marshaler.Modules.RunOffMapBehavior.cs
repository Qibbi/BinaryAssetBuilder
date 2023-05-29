using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RunOffMapBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RunOffMapBehaviorModuleData.RequiresSpecificTrigger), "true"), &objT->RequiresSpecificTrigger, state);
        Marshal(node.GetAttributeValue(nameof(RunOffMapBehaviorModuleData.RunOffMapWaypointName), null), &objT->RunOffMapWaypointName, state);
        Marshal(node.GetAttributeValue(nameof(RunOffMapBehaviorModuleData.DieOnMap), "false"), &objT->DieOnMap, state);
        Marshal(node.GetAttributeValue(nameof(RunOffMapBehaviorModuleData.FlyingOffMap), "false"), &objT->FlyingOffMap, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
