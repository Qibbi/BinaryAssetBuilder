using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIMessageSettings
    {
        public Time Delay;
        public RGBColor Color1;
        public RGBColor Color2;
        public FontDesc Font;
    }
}
