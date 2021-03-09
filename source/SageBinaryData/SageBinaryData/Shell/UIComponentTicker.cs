using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentTickerGroup
    {
        public AnsiString Name;
        public AnsiString HTTPAddress;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentTicker
    {
        public UIBaseComponent Base;
        public AnsiString CustomRenderName;
        public int NumberOfTickerDisplays;
        public float ScrollSpeedPixelPerSec;
        public float NumberOfPixelsBetweenHeadline;
        public Color TickerColor;
        public List<UIComponentTickerGroup> TickerGroup;
    }
}
