using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum GameStatsMode
    {
        CAMPAIGN_GAME,
        SKIRMISH_GAME,
        LAN_GAME,
        ONLINE_UNRANKED_GAME,
        ONLINE_RANKED_1V1_GAME,
        ONLINE_RANKED_2V2_GAME,
        ONLINE_CLAN_1V1_GAME,
        ONLINE_CLAN_2V2_GAME
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameStatsModeData
    {
        public BaseAssetType Base;
        public GameStatsMode GameStatsMode;
        public List<AnsiString> AvailableMapName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MultiplayerSettings
    {
        public BaseAssetType Base;
        public int InitialCreditsVeryLow;
        public int InitialCreditsLow;
        public int InitialCreditsMedium;
        public int InitialCreditsHigh;
        public int InitialCreditsVeryHigh;
        public int StartCountdownTimer;
        public int MaxBeaconsPerPlayer;
        public List<GameStatsModeData> GameStatsModeData;
        public SageBool UseShroud;
        public SageBool ShowRandomPlayerTemplate;
        public SageBool ShowRandomStartPos;
        public SageBool ShowRandomColor;
    }
}
