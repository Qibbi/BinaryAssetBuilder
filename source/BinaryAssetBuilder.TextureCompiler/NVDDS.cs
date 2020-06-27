using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct MIPMapData
{
    public uint MipLevel;
    public uint Width;
    public uint Height;
    public int FaceNumber;
    public int NumFaces;
}

[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
}

public static class NVDDS
{
    public unsafe delegate NVErrorCode DXTWriteDelegate(void* buffer, uint count, MIPMapData* mipMapData, void* userData);

    public static unsafe NVErrorCode NVDXTCompress(NVImage<RGBA_t>* srcImage, NVCompressionOptions* options, DXTWriteDelegate fileWriteRoutine, RECT* rect = null)
    {
        RGBA
    }
}
