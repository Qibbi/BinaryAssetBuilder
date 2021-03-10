using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MissionObjectivePresentationSettings
    {
        public AnsiString ID;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> Dialog;
        public unsafe float* CameraFieldOfViewVariance;
        public unsafe Time* Duration;
        public unsafe Angle* CameraStartAngle;
        public unsafe Angle* CameraEndAngle;
        public unsafe Angle* CameraFieldOfView;
        public SageBool UseDynamicZoom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MissionObjectiveTag
    {
        public AnsiString Script;
        public AnsiString Description;
        public List<MissionObjectivePresentationSettings> PresentationSettings;
        public SageBool IsBonusObjective;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MissionObjectiveList
    {
        public BaseAssetType Base;
        public List<MissionObjectiveTag> MissionObjectiveTag;
    }
}
