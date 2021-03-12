using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum ArmorSetType
    {
        VETERAN,
        ELITE,
        HERO,
        PLAYER_UPGRADE,
        WEAK_VERSUS_BASEDEFENSES,
        ALTERNATE_FORMATION,
        MOUNTED,
        PLAYER_UPGRADE_2,
        PLAYER_UPGRADE_3,
        UNBESIEGEABLE,
        AS_TOWER,
        UNUSED_01,
        UNUSED_02,
        UNUSED_03,
        UNUSED_04,
        UNUSED_05,
        UNUSED_06,
        UNUSED_07,
        UNUSED_08,
        UNUSED_09,
        UNUSED_10,
        SHIELDBODY_ENABLED
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ArmorSetBitFlags
    {
        public const int Count = 0x00000016;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ArmorListType
    {
        public DamageType Damage;
        public Percentage Percent;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ArmorTemplate
    {
        public BaseInheritableAsset Base;
        public Percentage Default;
        public Percentage DamageScalar;
        public Percentage SideDamageScalar;
        public Percentage RearDamageScalar;
        public Percentage FlankedPenalty;
        public List<ArmorListType> Armor;
    }
}
