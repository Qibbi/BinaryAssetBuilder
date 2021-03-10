using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUITimerSettings
    {
        public Time FlashDuration;
        public Coord2D Position;
        public RGBColor FlashColor;
        public FontDesc NormalFont;
        public RGBColor NormalColor;
        public FontDesc ReadyFont;
        public RGBColor ReadyColor;
        public SageBool Centered;
    }
}
