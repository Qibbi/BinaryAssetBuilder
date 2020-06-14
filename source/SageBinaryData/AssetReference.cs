using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AssetReference<T> where T : unmanaged
    {
        public unsafe T* Reference;
    }
}
