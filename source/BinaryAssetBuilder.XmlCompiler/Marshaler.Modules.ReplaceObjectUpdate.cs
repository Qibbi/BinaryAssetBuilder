using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ReplaceObjectNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(ReplaceObjectNugget.TargetObjectFilter), null), &objT->TargetObjectFilter, state);
        Marshal(node.GetChildNodes(nameof(ReplaceObjectNugget.ReplacementObject)), &objT->ReplacementObject, state);
    }

    public static unsafe void Marshal(Node node, ReplaceObjectUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ReplaceObjectUpdateModuleData.ReplaceRadius), null), &objT->ReplaceRadius, state);
        Marshal(node.GetAttributeValue(nameof(ReplaceObjectUpdateModuleData.ReplaceFX), null), &objT->ReplaceFX, state);
        Marshal(node.GetAttributeValue(nameof(ReplaceObjectUpdateModuleData.Scatter), null), &objT->Scatter, state);
        Marshal(node.GetChildNodes(nameof(ReplaceObjectUpdateModuleData.ReplaceObjectNugget)), &objT->ReplaceObjectNugget, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
