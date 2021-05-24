using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum PCAudioCompressionSetting
    {
        NONE,
        XAS,
        EALAYER3
    }

    public enum XenonAudioCompressionSetting
    {
        NONE,
        XMA,
        EALAYER3
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioFile
    {
        public BaseAssetType Base;
        public AnsiString File;
        public unsafe int* PCSampleRate;
        public unsafe PCAudioCompressionSetting* PCCompression;
        public int PCQuality;
        public unsafe SageBool* IsStreamedOnPC;
        public unsafe int* XenonSampleRate;
        public unsafe XenonAudioCompressionSetting* XenonCompression;
        public int XenonQuality;
        public unsafe SageBool* IsStreamedOnXenon;
        public unsafe AnsiString* SubtitleStringName;
        public unsafe AnsiString* GUIPreset;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioFileRuntime
    {
        public BaseAssetType Base;
        public unsafe AnsiString* SubtitleStringName;
        public int NumberOfSamples;
        public int SampleRate;
        public int HeaderData;
        public int HeaderDataSize;
        public byte NumberOfChannels;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioFileMP3Passthrough
    {
        public BaseAssetType Base;
        public AnsiString File;
        public unsafe AnsiString* SubtitleStringName;
        public SageBool IsStreamed;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioFileMP3PassthroughRuntime
    {
        public BaseAssetType Base;
        public unsafe AnsiString* SubtitleStringName;
        public SageBool IsStreamed;
    }

    public enum AudioPriority
    {
        LOWEST,
        LOW,
        NORMAL,
        HIGH,
        HIGHEST,
        CRITICAL
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

    public enum AudioTypeFlag
    {
        UI,
        WORLD,
        SHROUDED,
        VOICE,
        PLAYER,
        ALLIES,
        ENEMIES,
        EVERYONE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioTypeFlags
    {
        public const int Count = 0x00000008;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum AudioControlFlag
    {
        LOOP,
        SEQUENTIAL,
        RANDOMSTART,
        INTERRUPT,
        FADE_ON_KILL,
        FADE_ON_START,
        ALLOW_KILL_MID_FILE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioControlFlags
    {
        public const int Count = 0x00000007;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BaseAudioEventInfo
    {
        public BaseInheritableAsset Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BaseSingleSound
    {
        public BaseAudioEventInfo Base;
        public Percentage Volume;
        public Percentage VolumeShift;
        public Percentage PerFileVolumeShift;
        public Percentage MinVolume;
        public Percentage PlayPercent;
        public int Limit;
        public AudioPriority Priority;
        public AudioTypeFlags Type;
        public AudioControlFlags Control;
        public float MinRange;
        public float MaxRange;
        public Percentage LowPassCutoff;
        public Percentage ZoomedInOffscreenVolumePercent;
        public Percentage ZoomedInOffscreenMinVolumePercent;
        public Percentage ZoomedInOffscreenOcclusionPercent;
        public Percentage ReverbEffectLevel;
        public Percentage DryLevel;
        public unsafe AudioVolumeSlider* SubmixSlider;
        public unsafe RealRange* PitchShift;
        public unsafe RealRange* PerFilePitchShift;
        public unsafe IntRange* Delay;
        public List<AudioVolumeSliderMultiplier> VolumeSliderMultiplier;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioFileRefWithWeight
    {
        public AssetReference<AudioFile> Base;
        public uint Weight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MultisoundSubsoundRef
    {
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> Base;
        public uint Weight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioEvent
    {
        public BaseSingleSound Base;
        public List<AudioFileRefWithWeight> Attack;
        public List<AudioFileRefWithWeight> Sound;
        public List<AudioFileRefWithWeight> Decay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicTrack
    {
        public BaseSingleSound Base;
        public unsafe AssetReference<AudioFile>* Filename;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DialogEvent
    {
        public BaseSingleSound Base;
        public unsafe AssetReference<AudioFile>* Filename;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AmbientStream
    {
        public BaseSingleSound Base;
        public unsafe AssetReference<AudioFile>* Filename;
    }

    public enum MultisoundControlFlag
    {
        LOOP,
        PLAY_ONE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MultisoundControlFlags
    {
        public const int Count = 0x00000002;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Multisound
    {
        public BaseAudioEventInfo Base;
        public MultisoundControlFlags Control;
        public List<MultisoundSubsoundRef> Subsound;
    }
}
