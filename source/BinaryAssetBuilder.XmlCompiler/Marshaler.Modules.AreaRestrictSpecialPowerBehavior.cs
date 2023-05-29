using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AreaRestrictSpecialPowerBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AreaRestrictSpecialPowerBehaviorModuleData.RestrictionType), null), &objT->RestrictionType, state);
        Marshal(node.GetAttributeValue(nameof(AreaRestrictSpecialPowerBehaviorModuleData.AreaName), null), &objT->AreaName, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
