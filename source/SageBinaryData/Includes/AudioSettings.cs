using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MicrophoneSettings
    {
        public BaseAssetType Base;
        public Percentage MicrophonePreferredFractionCameraToGround;
        public Percentage VolumeMicrophonePullTowardsTerrainLookAtPoint;
        public Percentage PanningMicrophonePullTowardsTerrainLookAtPoint;
        public float MicrophoneMinDistanceToCamera;
        public float MicrophoneMaxDistanceToCamera;
        public float ZoomMinDistance;
        public float ZoomMaxDistance;
        public Percentage ZoomSoundVolumePercentageAmount;
        public float ZoomFadeDistanceForMaxEffect;
        public float ZoomFadeZeroEffectEdgeLength;
        public float ZoomFadeFullEffectEdgeLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VolumeCompressionSettings
    {
        public float Threshold;
        public float Ratio;
        public Time AttackTime;
        public Time ReleaseTime;
        public SageBool AppliesEquallyToAllChannels;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioSettings
    {
        public BaseAssetType Base;
        public int StreamBufferSizePerChannel;
        public int MaxRequestsPerStream;
        public Time ForceResetTime;
        public Time EmergencyResetTime;
        public Percentage MinOcclusion;
        public Time DelayPriorToPlayingToReadSoundFile;
        public Time ReadAheadTime;
        public Time QueueAheadTime;
        public Time LongTime;
        public uint AudioFootprintInBytes;
        public Percentage DefaultSoundVolume;
        public Percentage DefaultVoiceVolume;
        public Percentage DefaultMusicVolume;
        public Percentage DefaultMovieVolume;
        public Percentage DefaultAmbientVolume;
        public Time AutomaticSubtitleDuration;
        public int AutomaticSubtitleLines;
        public float PanRadiusScaleValue;
        public float PanSize;
        public Percentage MinSampleVolume;
        public float PositionDeltaForReverbCheck;
        public Time TimeToFadeAudio;
        public int AmbientStreamHysteresisVolume;
        public Percentage VolumeMultiplierFor2DSounds;
        public uint VoiceMoveToCampMaxCampnessAtStartPoint;
        public uint VoiceMoveToCampMinCampnessAtEndPoint;
        public Time MinDelayBetweenEnterStateVoice;
        public Time TimeSinceLastAttackForVoiceRetreatToCastle;
        public float DistanceToLookForEnemiesForVoiceRetreatToCastle;
        public Time PostPostGameMusicWait;
        public RGBAColor AutomaticSubtitleWindowColor;
        public RGBAColor AutomaticSubtitleTextColor;
        public List<AudioVolumeSliderMultiplier> VolumeSliderMultiplierForMovie;
        public MicrophoneSettings TacticalMicSettings;
        public MicrophoneSettings LivingWorldMicSettings;
        public MicrophoneSettings ShellMicSettings;
        public VolumeCompressionSettings VolumeCompressorSettings;
        public SageBool PlayEnemySightedEventsOnlyFromNearbyUnits;
        public SageBool SuppressOcclusion;
    }
}
