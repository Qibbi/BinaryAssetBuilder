using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RankedOptionSetting
    {
        public AnsiString Label;
        public int Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentShellMultiplayer
    {
        public UIBaseComponent Base;
        public AnsiString MatchOptionsRankedLabelSpec;
        public AnsiString MatchOptionsMatchTypeLabelSpec;
        public AnsiString MatchOptionsPlayersLabelSpec;
        public AnsiString AnyOptionLabelSpec;
        public AnsiString TACLineLabelSpec;
        public List<GameplayTypeSetting> GameType;
        public List<RankedOptionSetting> RankedOption;
    }
}
