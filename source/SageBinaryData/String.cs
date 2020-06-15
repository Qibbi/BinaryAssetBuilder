using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct String<T> where T : unmanaged
    {
        public int Length;
        public unsafe T* Target;
    }
}
