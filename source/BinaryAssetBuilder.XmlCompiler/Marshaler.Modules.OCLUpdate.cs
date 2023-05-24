using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, OCLUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(OCLUpdateModuleData.OCL), null), &objT->OCL, state);
        Marshal(node.GetAttributeValue(nameof(OCLUpdateModuleData.MinDelay), "0"), &objT->MinDelay, state);
        Marshal(node.GetAttributeValue(nameof(OCLUpdateModuleData.MaxDelay), "0"), &objT->MaxDelay, state);
        Marshal(node.GetAttributeValue(nameof(OCLUpdateModuleData.CreateAtEdge), "false"), &objT->CreateAtEdge, state);
        Marshal(node.GetAttributeValue(nameof(OCLUpdateModuleData.Amount), "-1"), &objT->Amount, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
