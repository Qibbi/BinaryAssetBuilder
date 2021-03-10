using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNuggetBase
    {
        public BaseAssetType Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionExpensiveNuggetBase
    {
        public MusicScriptConditionNuggetBase Base;
        public Time TimeBetweenConditionChecks;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_LocalPlayerIsObserver
    {
        public MusicScriptConditionNuggetBase Base;
        public SageBool CountDeadPlayersAsObservers;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_UnitsFarFromBase
    {
        public MusicScriptConditionExpensiveNuggetBase Base;
        public int MinUnitsToPass;
        public float MinDistanceFromBase;
        public ObjectFilterRelationshipBitMask Relationship;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_TimeFromStartOfLevel
    {
        public MusicScriptConditionNuggetBase Base;
        public Time Timeout;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_TrackPlayedCount
    {
        public MusicScriptConditionNuggetBase Base;
        public TypedAssetId<MusicScriptTrack> Track;
        public int Count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_SpecificTrackTypePlaying
    {
        public MusicScriptConditionNuggetBase Base;
        public StringHash TrackType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_AnyTrackPlaying
    {
        public MusicScriptConditionNuggetBase Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_ObjectsOfTypeExist
    {
        public MusicScriptConditionExpensiveNuggetBase Base;
        public int Count;
        public ModelConditionBitFlags RequiredModelConditions;
        public ModelConditionBitFlags ExcludedModelConditions;
        public unsafe ObjectFilter* Filter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_EvaEventPlayedRecently
    {
        public MusicScriptConditionNuggetBase Base;
        public AnsiString EvaEvent;
        public Time Timeout;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_ObjectsNearEvaEvent
    {
        public MusicScriptConditionExpensiveNuggetBase Base;
        public AnsiString EvaEvent;
        public int Count;
        public float Distance;
        public unsafe ObjectFilter* Filter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_ScoredKillCount
    {
        public MusicScriptConditionNuggetBase Base;
        public int Count;
        public Time Time;
        public unsafe AssetReference<ObjectFilterAsset>* Filter;
        public SageBool CountOnlyKillsAgainstTheLocalPlayer;
        public SageBool CountOnlyKillsByTheLocalPlayer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_Not
    {
        public MusicScriptConditionNuggetBase Base;
        public AssetReference<MusicScriptConditionNuggetBase> Condition;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_Or
    {
        public MusicScriptConditionNuggetBase Base;
        public List<AssetReference<MusicScriptConditionNuggetBase>> Condition;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptConditionNugget_And
    {
        public MusicScriptConditionNuggetBase Base;
        public List<AssetReference<MusicScriptConditionNuggetBase>> Condition;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptTimeoutSpecifier
    {
        public int Weight;
        public Time Duration;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicScriptTrack
    {
        public BaseAssetType Base;
        public StringHash TrackTypeKey;
        public int Level;
        public int Priority;
        public unsafe AssetReference<MusicScriptConditionNuggetBase>* Condition;
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> Track;
        public List<MusicScriptTimeoutSpecifier> Timeout;
        public SageBool ConditionsAreLatch;
        public SageBool FadeInTrack;
        public SageBool FadeOutLowerLevelTrack;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MusicPalette
    {
        public BaseAssetType Base;
        public List<AssetReference<MusicScriptTrack>> Track;
        public SageBool IsDefaultForNewMap;
    }
}
