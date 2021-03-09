using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DefaultValues
    {
        public int Difficulty;
        public float Gamma;
        public float Brightness;
        public float Contrast;
        public float VolumeMusic;
        public float VolumeFX;
        public float VolumeVoice;
        public float VolumeAmbient;
        public float VolumeMovie;
        public float ScrollSpeed;
        public int ScrollMagnetism;
        public int DefaultFaction;
        public int VisionCamZoom;
        public float ScrollSpeedMin;
        public float ScrollSpeedMax;
        public SageBool ButtonIcon;
        public SageBool HealthBars;
        public SageBool HighlightPads;
        public SageBool ToolTips;
        public SageBool InvertRotate;
        public SageBool VisionCamVisible;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentOptions
    {
        public UIBaseComponent Base;
        public AnsiString ControlsToken;
        public AnsiString SaveFileName;
        public List<AnsiString> ControlsText;
        public DefaultValues DefaultValues;
    }
}
