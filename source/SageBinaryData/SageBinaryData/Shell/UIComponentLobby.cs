using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.Shell
{
    public enum SlotStateType
    {
        OPEN,
        CLOSED,
        PRIVATE,
        AI
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SlotState
    {
        public AnsiString Label;
        public SlotStateType Value;
        public SageBool AvailableInRanked;
        public SageBool AvailableInModerated;
    }

    public enum AIDifficultyValue
    {
        EASY,
        MEDIUM,
        HARD,
        BRUTAL
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIDifficultySetting
    {
        public AnsiString Label;
        public AIDifficultyValue Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TeamSetting
    {
        public AnsiString Label;
        public int Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameTimeSetting
    {
        public AnsiString Label;
        public int Value;
        public SageBool Default;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameResourcesSetting
    {
        public int Value;
        public SageBool Default;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GamePointsSetting
    {
        public int Value;
        public SageBool Default;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameFlagsSetting
    {
        public int Value;
        public SageBool Default;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MultiplayerLobbyData
    {
        public AnsiString LobbyTitleLabelSpec;
        public AnsiString UnmoderatedLobbyTitleTemplateSpec;
        public AnsiString ModeratedLobbyTitleTemplateSpec;
        public AnsiString PlayerNameLabelSpec;
        public AnsiString SlotLabelSpec;
        public List<SlotState> SlotState;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SkirmishLobbyData
    {
        public AnsiString LoadMusic;
        public AnsiString SlotLabelSpec;
        public List<SlotState> SlotState;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentLobby
    {
        public UIBaseComponent Base;
        public AnsiString RandomStringLabel;
        public AnsiString FactionLabelSpec;
        public AnsiString AIPersonalityLabelSpec;
        public AnsiString AIDifficultyLabelSpec;
        public AnsiString TeamLabelSpec;
        public AnsiString MapListSpec;
        public AnsiString GameplayTypeSpec;
        public AnsiString GameTimeLimitSpec;
        public AnsiString GameResourcesSpec;
        public AnsiString HillTimeSpec;
        public AnsiString CapturePointsSpec;
        public AnsiString BarrierTimeSpec;
        public AnsiString CaptureFlagsSpec;
        public List<AnsiString> FactionValue;
        public List<AIDifficultySetting> AIDifficulty;
        public List<TeamSetting> Team;
        public List<GameplayTypeSetting> GameType;
        public List<GameTimeSetting> GameTime;
        public List<GameResourcesSetting> GameResources;
        public List<GameTimeSetting> HillTime;
        public List<GameTimeSetting> BarrierTime;
        public List<GamePointsSetting> CapturePoints;
        public List<GameFlagsSetting> CaptureFlags;
        public MultiplayerLobbyData MultiplayerLobbySettings;
        public SkirmishLobbyData SkirmishLobbySettings;
    }
}
