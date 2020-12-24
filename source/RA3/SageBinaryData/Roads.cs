using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Road
    {
        public BaseAssetType Base;
        public AssetReference<Texture> Texture;
        public AssetReference<Texture> NormalTexture;
        public float RoadWidth;
        public float RoadWidthInTexture;
        public float Priority;
    }
}
