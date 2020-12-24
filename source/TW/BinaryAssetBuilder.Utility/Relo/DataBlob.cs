using System.Runtime.InteropServices;

namespace Relo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DataBlob
    {
        public unsafe void* Data;
        public uint Size;
    }
}
