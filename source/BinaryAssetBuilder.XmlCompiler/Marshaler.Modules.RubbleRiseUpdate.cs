using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RubbleRisePhaseEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RubbleRisePhaseEvent.Phase), null), &objT->Phase, state);
        Marshal(node.GetAttributeValue(nameof(RubbleRisePhaseEvent.OclCount), null), &objT->OclCount, state);
        Marshal(node.GetAttributeValue(nameof(RubbleRisePhaseEvent.FxCount), null), &objT->FxCount, state);
        Marshal(node.GetChildNodes(nameof(RubbleRisePhaseEvent.Ocl)), &objT->Ocl, state);
        Marshal(node.GetChildNodes(nameof(RubbleRisePhaseEvent.Fx)), &objT->Fx, state);
    }

    public static unsafe void Marshal(Node node, RubbleRiseUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RubbleRiseUpdateModuleData.MinRubbleRiseDelay), null), &objT->MinRubbleRiseDelay, state);
        Marshal(node.GetAttributeValue(nameof(RubbleRiseUpdateModuleData.MaxRubbleRiseDelay), null), &objT->MaxRubbleRiseDelay, state);
        Marshal(node.GetAttributeValue(nameof(RubbleRiseUpdateModuleData.MinBurstDelay), null), &objT->MinBurstDelay, state);
        Marshal(node.GetAttributeValue(nameof(RubbleRiseUpdateModuleData.MaxBurstDelay), null), &objT->MaxBurstDelay, state);
        Marshal(node.GetAttributeValue(nameof(RubbleRiseUpdateModuleData.BigBurstFrequency), null), &objT->BigBurstFrequency, state);
        Marshal(node.GetAttributeValue(nameof(RubbleRiseUpdateModuleData.RubbleRiseDamping), null), &objT->RubbleRiseDamping, state);
        Marshal(node.GetAttributeValue(nameof(RubbleRiseUpdateModuleData.RubbleHeight), null), &objT->RubbleHeight, state);
        Marshal(node.GetAttributeValue(nameof(RubbleRiseUpdateModuleData.MaxShudder), null), &objT->MaxShudder, state);
        Marshal(node.GetChildNodes(nameof(RubbleRiseUpdateModuleData.Phase)), &objT->Phase, state);
        Marshal(node.GetChildNode(nameof(RubbleRiseUpdateModuleData.Die), null), &objT->Die, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
