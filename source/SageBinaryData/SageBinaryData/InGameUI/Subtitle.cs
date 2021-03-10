using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUISubtitleSettings
    {
        public Time HoldTime;
        public int LineCount;
        public FontDesc Font;
        public Color PanelColor;
        public Color TextColor;
        public Coord2D Position;
        public Coord2D Size;
    }
}
