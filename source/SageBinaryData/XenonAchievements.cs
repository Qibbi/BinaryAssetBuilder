using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum AchievementTriggerType
    {
        SINGLEPLAYER,
        MULTIPLAYER,
        SKIRMISH
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Achievement
    {
        public BaseAssetType Base;
        public int XlastID;
        public AchievementTriggerType TriggerType;
        public AnsiString AchievementValueString;
    }
}
