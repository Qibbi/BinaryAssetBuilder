using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, OnDemandTextureImage* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(OnDemandTextureImage.Texture), null), &objT->Texture, state);
        Marshal(node.GetAttributeValue(nameof(OnDemandTextureImage.Rotated), null), &objT->Rotated, state);
        Marshal(node.GetChildNode(nameof(OnDemandTextureImage.Dimensions), null), &objT->Dimensions, state);
        Marshal(node.GetChildNode(nameof(OnDemandTextureImage.Coords), null), &objT->Coords, state);
        Marshal(node.GetChildNode(nameof(OnDemandTextureImage.TextureDimensions), null), &objT->TextureDimensions, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}