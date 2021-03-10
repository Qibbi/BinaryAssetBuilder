using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUISettings
    {
        public BaseInheritableAsset Base;
        public AnsiString CommandLimitReachedText;
        public Time ObjectivesButtonFlashDuration;
        public Time IntelligenceDatabaseButtonFlashDuration;
        public InGameUICommandButtonSettings CommandButton;
        public RGBColor AttackMoveMarkerColor;
        public InGameUIDecalCloudSettings DecalCloud;
        public InGameUIDrawableCaptionSettings DrawableCaption;
        public InGameUIExitContainerButtonSettings ExitContainerButton;
        public InGameUIFixedButtonHelp FixedButtonHelp;
        public InGameUIFloatingTextSettings FloatingText;
        public InGameUIMessageSettings Message;
        public InGameUIMilitaryCaptionSettings MilitaryCaption;
        public RGBColor MoveMarkerColor;
        public InGameUIObjectivePresentationSettings ObjectivePresentation;
        public InGameUISubtitleSettings Subtitle;
        public InGameUITimerSettings Timer;
    }
}
