using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PackedTextureImage
    {
        public BaseAssetType Base;
        public AssetReference<Texture> Texture;
        public ICoord2D Dimensions;
        public ICoord2D Coords;
        public ICoord2D TextureDimensions;
        public SageBool Rotated;
    }
}
