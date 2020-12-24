using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Mouse
    {
        public BaseAssetType Base;
        public AnsiString TooltipFontName;
        public int TooltipFontSize;
        public int TooltipDelayTime;
        public Color TooltipTextColor;
        public float OrthoZoom;
        public int DragTolerance;
        public SageBool TooltipFontIsBold;
        public SageBool UseTooltipAltTextColor;
        public SageBool AdjustTooltipAltColor;
        public SageBool OrthoCamera;
    }
}
