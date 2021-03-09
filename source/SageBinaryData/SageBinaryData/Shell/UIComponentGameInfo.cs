using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum GameModeEnum
    {
        NONE,
        CAMPAIGN,
        SKIRMISH,
        TUTORIAL,
        MULTIPLAYER,
        SHELL
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentGameInfo
    {
        public UIBaseComponent Base;
        public AnsiString GameScoreDisplayToken;
        public AnsiString ScorePlayerToken;
        public int GameScoreXLocWS;
        public int GameScoreXLoc;
        public int GameScoreYLocWS;
        public int GameScoreYLoc;
        public int Player1ScoreXLocWS;
        public int Player1ScoreXLoc;
        public int Player1ScoreYLocWS;
        public int Player1ScoreYLoc;
        public int Player2ScoreXLocWS;
        public int Player2ScoreXLoc;
        public int Player2ScoreYLocWS;
        public int Player2ScoreYLoc;
        public int Player3ScoreXLocWS;
        public int Player3ScoreXLoc;
        public int Player3ScoreYLocWS;
        public int Player3ScoreYLoc;
        public int Player4ScoreXLocWS;
        public int Player4ScoreXLoc;
        public int Player4ScoreYLocWS;
        public int Player4ScoreYLoc;
    }
}
