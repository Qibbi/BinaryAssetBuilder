using System.Runtime.InteropServices;

namespace Relo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct List<T> where T : unmanaged
    {
        public uint Count;
        public unsafe T* Target;
    }
}
