using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StanceDefinition* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StanceDefinition.Type), null), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(StanceDefinition.AttributeModifier), null), &objT->AttributeModifier, state);
    }

    public static unsafe void Marshal(Node node, StanceTemplate* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(StanceTemplate.StanceDefinition)), &objT->StanceDefinition, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}