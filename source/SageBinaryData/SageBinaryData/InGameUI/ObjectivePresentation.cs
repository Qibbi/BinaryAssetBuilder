using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIObjectivePresentationSettingsZoom
    {
        public float InitialChangePerSecond;
        public Percentage Overshoot;
        public float ChangePerSecond;
        public Percentage InitialFOV;
        public Percentage MidPointFOV;
        public Percentage MinimumFOV;
        public Percentage MidPointOfs;
        public int ZoomCount;
        public Time DurationMin;
        public Time DurationMax;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> ZoomOutSound;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> ZoomInSound;
        public Percentage MinFOVChangeForZoomOutSound;
        public Percentage MaxFOVChangeForZoomInSound;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIObjectivePresentationSettingsMove
    {
        public float Acceleration;
        public float MaxSpeed;
        public float JitterXY;
        public float JitterZ;
        public float MinHardCutDistance;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> HardCutSound;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> MoveSound;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIObjectivePresentationSettings
    {
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> StartObjectiveSound;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> SatelliteViewFinishSound;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> SatelliteViewAmbientLoop;
        public Time DefaultTimePerTarget;
        public Angle DefaultCameraStartAngle;
        public Angle DefaultCameraEndAngle;
        public Angle DefaultCameraFieldOfView;
        public float DefaultCameraFieldOfViewVariance;
        public InGameUIObjectivePresentationSettingsZoom Zoom;
        public InGameUIObjectivePresentationSettingsMove Move;
    }
}
