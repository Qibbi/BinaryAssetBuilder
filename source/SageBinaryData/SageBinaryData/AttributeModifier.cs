using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum AttributeModifierCategoryType
    {
        NONE,
        LEADERSHIP,
        FORMATION,
        SPELL,
        WEAPON,
        STRUCTURE,
        LEVEL,
        BUFF,
        DEBUFF,
        STUN,
        INNATE_ARMOR,
        INNATE_DAMAGEMULT,
        INNATE_VISION,
        INNATE_AUTOHEAL,
        INNATE_HEALTH
    }

    public enum AttributeType
    {
        NONE,
        ARMOR,
        DAMAGE_ADD,
        DAMAGE_MULT,
        RESIST_FEAR,
        RESIST_TERROR,
        EXPERIENCE,
        RANGE,
        SPEED,
        CRUSH_DECELERATE,
        RESIST_KNOCKBACK,
        SPELL_DAMAGE,
        RECHARGE_TIME,
        PRODUCTION,
        HEALTH,
        HEALTH_MULT,
        VISION,
        BOUNTY_PERCENTAGE,
        MIN_CRUSH_VELOCITY_PERCENTAGE,
        AUTO_HEAL,
        SHROUD_CLEARING,
        RATE_OF_FIRE,
        DAMAGE_STRUCTURE_BOUNTY_ADD,
        CRUSHER_LEVEL,
        COMMAND_POINT_BONUS,
        CRUSHABLE_LEVEL,
        CRUSHED_DECELERATE,
        INVULNERABLE,
        SUPPRESSABILITY,
        RESIST_EMP
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AttributeModifierCategoryBitFlags
    {
        public const int Count = 15;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AttributeModifierListType
    {
        public AttributeType Type;
        public Percentage Value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AttributeModifier
    {
        // TODO:
    }
}
