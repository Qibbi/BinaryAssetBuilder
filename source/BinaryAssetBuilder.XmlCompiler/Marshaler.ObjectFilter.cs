using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ObjectFilterAsset* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(ObjectFilterAsset.Filter), null), &objT->Filter, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
