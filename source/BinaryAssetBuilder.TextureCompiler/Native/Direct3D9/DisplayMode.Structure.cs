using System.Runtime.InteropServices;

namespace Native.Direct3D9
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DisplayMode
    {
        public int Width;
        public int Height;
        public int RefreshRate;
        public Format Format;
    }
}
