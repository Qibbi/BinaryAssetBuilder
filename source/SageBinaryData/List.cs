using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct List<T> where T : unmanaged
    {
        public uint Count;
        public unsafe T* Target;
    }
}
