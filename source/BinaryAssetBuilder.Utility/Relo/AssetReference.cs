using System.Runtime.InteropServices;

namespace Relo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AssetReference<T> where T : unmanaged
    {
        public unsafe T* Reference;
    }

    // U is the AssetFactory, ex. typedef AssetReference<BaseAssetType, RenderAssetFactory> RenderObjectReference;
    [StructLayout(LayoutKind.Sequential)]
    public struct AssetReference<T, U> where T : unmanaged
    {
        public unsafe T* Reference;
    }
}
