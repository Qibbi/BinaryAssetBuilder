using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct TextureFileData
{
    public uint Size;
    public IntPtr Data;
}
