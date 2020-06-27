using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum DamageType
    {
        FORCE,
        CRUSH,
        SLASH,
        PIERCE,
        SIEGE,
        STRUCTURAL,
        FLAME,
        HEALING,
        UNRESISTABLE,
        WATER,
        PENALTY,
        FALLING,
        BLAST,
        REFLECTED,
        PASSENGER,
        MAGIC,
        CHOP,
        HERO,
        SPECIALIST,
        FLY_INTO,
        UNDEFINED,
        LOGICAL_FIRE,
        POISON,
        LASER,
        PLASMA,
        FIRE,
        ROCKET,
        GUN,
        CANNON,
        GRENADE,
        SNIPER,
        MINE,
        TIBERIUM,
        STORM_SHIELD
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DamageBitFlags
    {
        public const int Count = 35;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }
}
