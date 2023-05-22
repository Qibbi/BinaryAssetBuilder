using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DynamicShroudClearingRangeUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DynamicShroudClearingRangeUpdateModuleData.FinalVision), "0.0"), &objT->FinalVision, state);
        Marshal(node.GetAttributeValue(nameof(DynamicShroudClearingRangeUpdateModuleData.ChangeInterval), "0"), &objT->ChangeInterval, state);
        Marshal(node.GetAttributeValue(nameof(DynamicShroudClearingRangeUpdateModuleData.GrowInterval), "0"), &objT->GrowInterval, state);
        Marshal(node.GetAttributeValue(nameof(DynamicShroudClearingRangeUpdateModuleData.ShrinkDelay), "0"), &objT->ShrinkDelay, state);
        Marshal(node.GetAttributeValue(nameof(DynamicShroudClearingRangeUpdateModuleData.ShrinkTime), "0"), &objT->ShrinkTime, state);
        Marshal(node.GetAttributeValue(nameof(DynamicShroudClearingRangeUpdateModuleData.GrowDelay), "0"), &objT->GrowDelay, state);
        Marshal(node.GetAttributeValue(nameof(DynamicShroudClearingRangeUpdateModuleData.GrowTime), "0"), &objT->GrowTime, state);
        Marshal(node.GetAttributeValue(nameof(DynamicShroudClearingRangeUpdateModuleData.InitiallyDisabled), "false"), &objT->InitiallyDisabled, state);
        Marshal(node.GetChildNode(nameof(DynamicShroudClearingRangeUpdateModuleData.GridDecalTemplate), null), &objT->GridDecalTemplate, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
