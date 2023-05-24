using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TiberiumGrowthModBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TiberiumGrowthModBehaviorModuleData.GreenTiberiumMultiplier), "1.0"), &objT->GreenTiberiumMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumGrowthModBehaviorModuleData.BlueTiberiumMultiplier), "1.0"), &objT->BlueTiberiumMultiplier, state);
        Marshal(node, (DieModuleData*)objT, state);
    }
}
