using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SuppressionUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SuppressionUpdateModuleData.UpdateDelay), "1s"), &objT->UpdateDelay, state);
        Marshal(node.GetAttributeValue(nameof(SuppressionUpdateModuleData.Suppressability), "0"), &objT->Suppressability, state);
        Marshal(node.GetAttributeValue(nameof(SuppressionUpdateModuleData.SuppressionDuration), "3s"), &objT->SuppressionDuration, state);
        Marshal(node.GetAttributeValue(nameof(SuppressionUpdateModuleData.AttributeModifierSuppressed), null), &objT->AttributeModifierSuppressed, state);
        Marshal(node.GetAttributeValue(nameof(SuppressionUpdateModuleData.AttributeModifierForceMove), null), &objT->AttributeModifierForceMove, state);
        Marshal(node.GetAttributeValue(nameof(SuppressionUpdateModuleData.IgnoreSuppressionObjectStatus), null), &objT->IgnoreSuppressionObjectStatus, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
