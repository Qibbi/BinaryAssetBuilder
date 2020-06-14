using System.Runtime.InteropServices;

namespace Relo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AssetReference<T> where T : unmanaged
    {
        public unsafe T* Reference;
    }
}
