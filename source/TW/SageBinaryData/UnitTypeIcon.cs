using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UnitTypeIcon
    {
        public BaseInheritableAsset Base;
        public AssetReference<PackedTextureImage> Image;
        public unsafe Coord2D* Offset;
    }
}
