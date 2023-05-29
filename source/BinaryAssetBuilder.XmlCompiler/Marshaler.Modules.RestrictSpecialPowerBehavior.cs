using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RestrictSpecialPowerBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RestrictSpecialPowerBehaviorModuleData.RestrictionType), null), &objT->RestrictionType, state);
        Marshal(node.GetAttributeValue(nameof(RestrictSpecialPowerBehaviorModuleData.DependentObject), null), &objT->DependentObject, state);
        Marshal(node.GetAttributeValue(nameof(RestrictSpecialPowerBehaviorModuleData.ConsiderSpecialPowerRadius), "true"), &objT->ConsiderSpecialPowerRadius, state);
        Marshal(node.GetChildNodes(nameof(RestrictSpecialPowerBehaviorModuleData.DependentObjectRadius)), &objT->DependentObjectRadius, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
