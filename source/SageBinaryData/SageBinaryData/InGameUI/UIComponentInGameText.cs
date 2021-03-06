using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.InGameUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentInGameText
    {
        public UIBaseComponent Base;
        public float AdjustFactor;
        public float TextIndent;
        public uint TooltipAppearDelayMS;
        public uint TooltipDisappearDelayMS;
        public AnsiString AptTokenTitle;
        public AnsiString AptTokenPrereq;
        public AnsiString AptTokenCost;
        public AnsiString AptTokenTime;
        public AnsiString AptTokenEnergy;
        public AnsiString AptTokenShortDesc;
        public AnsiString AptTokenLongDesc;
        public AnsiString ProductionTextConstruction;
        public AnsiString ProductionTextUpgrade;
        public AnsiString ProductionTextRecruit;
        public float ProductionTextScale;
        public AnsiString SubtitleStringLabelPrefix;
        public AnsiString SubtitleStringLabelSuffix;
        public AnsiString SubtitleStringExclusionChar;
        public Coord2D StatusTextPosition;
        public RGBColor ProductionTextColor;
        public FontDesc ProductionTextFont;
    }
}
