using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BaseAudioEventInfo
    {
        public BaseInheritableAsset Base;
    }

    public enum AudioVolumeSlider
    {
        SOUNDFX,
        VOICE,
        MUSIC,
        AMBIENT,
        MOVIE,
        NONE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioVolumeSliderMultiplier
    {
        public AudioVolumeSlider Slider;
        public float Multiplier;
    }
}
