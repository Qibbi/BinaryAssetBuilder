using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIDrawableCaptionSettings
    {
        public FontDesc Font;
        public RGBColor Color;
    }
}
