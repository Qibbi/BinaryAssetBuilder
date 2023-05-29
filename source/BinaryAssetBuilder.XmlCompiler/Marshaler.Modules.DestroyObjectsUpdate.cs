using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DestroyObjectsUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DestroyObjectsUpdateModuleData.Radius), "0.0"), &objT->Radius, state);
        Marshal(node.GetChildNode(nameof(DestroyObjectsUpdateModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
