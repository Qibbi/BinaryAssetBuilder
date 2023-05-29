#if KANESWRATH
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SalvagerInfoModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SalvagerInfoModuleData.SalvageRadius), "200.0"), &objT->SalvageRadius, state);
        Marshal(node.GetAttributeValue(nameof(SalvagerInfoModuleData.PercentageOfBountyRecycled), "100"), &objT->PercentageOfBountyRecycled, state);
        Marshal(node.GetAttributeValue(nameof(SalvagerInfoModuleData.UseBountyNotUnitCost), "false"), &objT->UseBountyNotUnitCost, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
#endif
