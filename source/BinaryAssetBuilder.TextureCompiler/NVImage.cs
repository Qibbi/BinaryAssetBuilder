using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 24)]
public struct NVImage<T> : IDisposable where T : unmanaged
{
    public uint Width;
    public uint Height;
    public unsafe T* Pixels;
    public CBool RGBE;

    public uint Size => Width * Height;
    public unsafe T* this[uint index] => &Pixels[index];
    public unsafe T* this[uint y, uint x] => &Pixels[(y * Width) + x];

    public unsafe void Apply(NVImage<T> x)
    {
        Resize(x.Width, x.Height);
        Pixels = x.Pixels;
        RGBE = x.RGBE;
    }

    public unsafe T* PixelsWrapped(uint x, uint y)
    {
        y %= Height;
        x %= Width;
        return &Pixels[(y * Width) + x];
    }

    public void Clear()
    {
        Width = 0;
        Height = 0;
    }

    public void Dispose()
    {
        Clear();
    }
}
