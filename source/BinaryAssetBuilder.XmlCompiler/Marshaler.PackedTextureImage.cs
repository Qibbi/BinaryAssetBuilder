using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, PackedTextureImage* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PackedTextureImage.Texture), null), &objT->Texture, state);
        Marshal(node.GetAttributeValue(nameof(PackedTextureImage.Rotated), null), &objT->Rotated, state);
        Marshal(node.GetChildNode(nameof(PackedTextureImage.Dimensions), null), &objT->Dimensions, state);
        Marshal(node.GetChildNode(nameof(PackedTextureImage.Coords), null), &objT->Coords, state);
        Marshal(node.GetChildNode(nameof(PackedTextureImage.TextureDimensions), null), &objT->TextureDimensions, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}