using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ModelConditionSpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ModelConditionSpecialAbilityUpdateModuleData.WhichSpecialPower), "1"), &objT->WhichSpecialPower, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
