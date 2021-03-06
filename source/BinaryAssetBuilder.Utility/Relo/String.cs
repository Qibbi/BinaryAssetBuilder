using System.Runtime.InteropServices;

namespace Relo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct String<T> where T : unmanaged
    {
        public int Length;
        public unsafe T* Target;
    }
}
