using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct FPPixel
{
    public unsafe fixed float P[4];

    public unsafe float R { get => P[0]; set => P[0] = value; }
    public unsafe float G { get => P[1]; set => P[1] = value; }
    public unsafe float B { get => P[2]; set => P[2] = value; }
    public unsafe float A { get => P[3]; set => P[3] = value; }
    public unsafe float X { get => P[0]; set => P[0] = value; }
    public unsafe float Y { get => P[1]; set => P[1] = value; }
    public unsafe float Z { get => P[2]; set => P[2] = value; }
    public unsafe float W { get => P[3]; set => P[3] = value; }
}
