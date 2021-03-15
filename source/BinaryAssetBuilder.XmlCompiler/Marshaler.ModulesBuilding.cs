using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BuildingBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BuildingBehaviorModuleData.NightWindowObject), null), &objT->NightWindowObject, state);
        Marshal(node.GetAttributeValue(nameof(BuildingBehaviorModuleData.FireWindowObject), null), &objT->FireWindowObject, state);
        Marshal(node.GetAttributeValue(nameof(BuildingBehaviorModuleData.GlowWindowObject), null), &objT->GlowWindowObject, state);
        Marshal(node.GetAttributeValue(nameof(BuildingBehaviorModuleData.NightFireWindowObject), null), &objT->NightFireWindowObject, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
