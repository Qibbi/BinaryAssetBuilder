using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, Road* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Road.Texture), null), &objT->Texture, state);
        Marshal(node.GetAttributeValue(nameof(Road.NormalTexture), null), &objT->NormalTexture, state);
        Marshal(node.GetAttributeValue(nameof(Road.RoadWidth), null), &objT->RoadWidth, state);
        Marshal(node.GetAttributeValue(nameof(Road.RoadWidthInTexture), null), &objT->RoadWidthInTexture, state);
        Marshal(node.GetAttributeValue(nameof(Road.Priority), null), &objT->Priority, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}