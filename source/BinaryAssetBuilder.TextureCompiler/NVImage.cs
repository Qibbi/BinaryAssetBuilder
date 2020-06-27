using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 24)]
internal struct NVImage<T> where T : unmanaged
{
    public int Width;
    public int Height;
    public unsafe T* Data;
}
