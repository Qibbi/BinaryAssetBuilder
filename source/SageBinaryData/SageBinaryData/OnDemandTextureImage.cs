using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OnDemandTextureImage
    {
        public BaseAssetType Base;
        public AssetReference<OnDemandTexture> Texture;
        public ICoord2D Dimensions;
        public ICoord2D Coords;
        public ICoord2D TextureDimensions;
        public SageBool Rotated;
    }
}
