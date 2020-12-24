using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageSequence
    {
        public BaseInheritableAsset Base;
        public List<AssetReference<PackedTextureImage>> Image;
    }
}
