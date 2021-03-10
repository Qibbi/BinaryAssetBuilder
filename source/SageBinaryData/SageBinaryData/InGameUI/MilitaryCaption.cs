using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIMilitaryCaptionSettings
    {
        public Time Delay;
        public RGBColor Color;
        public Coord2D Position;
        public FontDesc TitleFont;
        public FontDesc Font;
        public SageBool Centered;
    }
}
