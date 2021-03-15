using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AttributeModifierUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AttributeModifierUpgradeModuleData.AttributeModifier), null), &objT->AttributeModifier, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
