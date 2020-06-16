using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum LogicCommandType
    {
        NONE,
        SPECIAL_POWER,
        STOP,
        OBJECT_UPGRADE,
        PLAYER_UPGRADE,
        DOZER_CONSTRUCT,
        UNIT_BUILD,
        EVACUATE,
        EXIT_CONTAINER,
        SET_STANCE,
        ATTACK_MOVE,
        SELL,
        CANCEL_UNIT_BUILD,
        CANCEL_UPGRADE,
        CONSTRUCTION_YARD_CONSTRUCT,
        HORDE_TOGGLE_FORMATION,
        GARRISON_BUILDING,
        DRILL_DOWN,
        DRILL_UP,
        TOGGLE_POWER,
        SELF_REPAIR,
        DEFAULT_BUILDING,
        RALLY
    }

    public enum LogicCommandOptions
    {
        NEED_TARGET_ENEMY_OBJECT,
        NEED_TARGET_NEUTRAL_OBJECT,
        NEED_TARGET_ALLY_OBJECT,
        FIRED_BY_SCRIPT,
        OPTION_ONE,
        OPTION_TWO,
        OPTION_THREE,
        AUTO_ABILITY_TRIGGERED,
        NEED_TARGET_POS,
        OK_FOR_MULTI_EXECUTE
    }

    public struct LogicCommandOptionsBitFlags
    {
        public const int Count = 10;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LogicCommand
    {
        public BaseInheritableAsset Base;
        public LogicCommandType Type;
        public LogicCommandOptionsBitFlags Options;
        public unsafe AssetReference<SpecialPowerTemplate>* SpecialPower;
        public unsafe AssetReference<UpgradeTemplate>* Upgrade;
        public unsafe AssetReference<GameObject>* Object;
    }
}
