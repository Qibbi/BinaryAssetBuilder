using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum WeaponSlotType
    {
        PRIMARY_WEAPON,
        SECONDARY_WEAPON,
        TERTIARY_WEAPON,
        QUATERNARY_WEAPON,
        QUINARY_WEAPON,
        NO_WEAPON
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponSlotBitFlags
    {
        public const int Count = 6;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum TimeOfDayType
    {
        INVALID = -1,
        MORNING,
        AFTERNOON,
        EVENING,
        NIGHT,
        INTERPOLATE
    }

    public enum WaypointPortalType
    {
        NORMAL,
        PORTAL,
        WALK_PORTAL,
        CLIMB_PORTAL,
        PRE_CLIMB_PORTAL,
        BEACON,
        SPLINE_CATMULL_ROM,
        FAKE_PATHFIND_PORTAL,
        MINESHAFT_PORTAL
    }

    public enum LocomotorSetType
    {
        INVALID = -1,
        NORMAL,
        NORMAL_UPGRADED,
        FREEFALL,
        WANDER,
        PANIC,
        TAXIING,
        SUPERSONIC,
        MOUNTED,
        ENRAGED,
        SCARED,
        CONTAINED,
        COMBO,
        COMBO2,
        COMBO3,
        WALL_SCALING,
        CHANGING_FIRINGARC,
        BURNINGDEATH
    }

    public enum ModelLODType
    {
        LOW,
        HIGH
    }

    public enum AnimationLODType
    {
        VERY_LOW,
        LOW,
        MEDIUM,
        HIGH,
        ULTRA_HIGH
    }

    public enum EffectsLODType
    {
        VERY_LOW,
        LOW,
        MEDIUM,
        HIGH,
        ULTRA_HIGH
    }

    public enum DecalLODType
    {
        OFF,
        LOW,
        HIGH
    }

    public enum WaterLODType
    {
        LOW,
        MEDIUM,
        HIGH,
        ULTRA_HIGH
    }

    public enum ShadowLODType
    {
        OFF,
        LOW,
        MEDIUM,
        HIGH,
        ULTRA_HIGH
    }

    public enum TerrainLODType
    {
        LOW,
        MEDIUM,
        HIGH,
        ULTRA_HIGH
    }

    public enum TextureQualityLODType
    {
        LOW,
        MEDIUM,
        HIGH
    }

    public enum WeatherType
    {
        NORMAL,
        CLOUDY,
        RAINY,
        CLOUDYRAINY,
        SUNNY,
        SNOWY,
        INVALID
    }

    public enum DisabledType
    {
        DEFAULT,
        USER_PARALYZED,
        EMP,
        HELD,
        PARALYZED,
        UNMANNED,
        UNDERPOWERED,
        FREEFALL,
        TEMPORARILY_BUSY,
        SCRIPT_DISABLED,
        SCRIPT_UNDERPOWERED
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DisabledBitFlags
    {
        public const int Count = 11;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum WeaponSetType
    {
        VETERAN,
        ELITE,
        HERO,
        PLAYER_UPGRADE,
        PASSENGER_TYPE_ONE,
        PASSENGER_TYPE_TWO,
        GARRISONED,
        CLOSE_RANGE,
        RAMPAGE,
        CONTESTING_BUILDING,
        RIDER1,
        RIDER2,
        RIDER3,
        RIDER4,
        RIDER5,
        RIDER6,
        RIDER7,
        RIDER8,
        SPECIAL_ONE,
        SPECIAL_TWO,
        CONTAINED,
        MOUNTED,
        ENRAGED,
        SPECIAL_UPGRADE,
        TOGGLE_1,
        TOGGLE_2,
        TOGGLE_3,
        HERO_MODE,
        UNUSED_WS_01,
        UNUSED_WS_02,
        UNUSED_WS_03,
        UNUSED_WS_04,
        UNUSED_WS_05,
        UNUSED_WS_06,
        UNUSED_WS_07,
        UNUSED_WS_08,
        UNUSED_WS_09,
        UNUSED_WS_10,
        UNUSED_WS_11,
        UNUSED_WS_12,
        UNUSED_WS_13,
        UNUSED_WS_14,
        UNUSED_WS_15,
        UNUSED_WS_16,
        UNUSED_WS_17,
        UNUSED_WS_18,
        UNUSED_WS_19,
        UNUSED_WS_20,
        UNUSED_WS_21,
        UNUSED_WS_22,
        UNUSED_WS_23,
        UNUSED_WS_24,
        UNUSED_WS_25,
        UNUSED_WS_26,
        UNUSED_WS_27,
        UNUSED_WS_28,
        UNUSED_WS_29,
        UNUSED_WS_30,
        UNUSED_WS_31,
        UNUSED_WS_32,
        HIDDEN,
        DUMMY_01,
        DUMMY_02,
        DUMMY_03,
        DUMMY_04,
        DUMMY_05,
        DUMMY_06,
        DUMMY_07,
        DUMMY_08,
        DUMMY_09,
        DUMMY_10,
        UNUSED_WS_33,
        UNUSED_WS_34,
        UNUSED_WS_35,
        UNUSED_WS_36,
        UNUSED_WS_37,
        UNUSED_WS_38,
        UNUSED_WS_39,
        UNUSED_WS_40,
        UNUSED_WS_41,
        UNUSED_WS_42,
        UNUSED_WS_43,
        UNUSED_WS_44,
        UNUSED_WS_45,
        UNUSED_WS_46,
        UNUSED_WS_47,
        UNUSED_WS_48,
        UNUSED_WS_49,
        UNUSED_WS_50,
        UNUSED_WS_51,
        UNUSED_WS_52,
        UNUSED_WS_53,
        UNUSED_WS_54,
        UNUSED_WS_55,
        UNUSED_WS_56,
        UNUSED_WS_57,
        UNUSED_WS_58,
        UNUSED_WS_59,
        UNUSED_WS_60,
        UNUSED_WS_61,
        UNUSED_WS_62,
        UNUSED_WS_63,
        UNUSED_WS_64
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WeaponSetBitFlags
    {
        public const int Count = 103;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum UpgradeIdType
    {
        UPGRADE_01,
        UPGRADE_02,
        UPGRADE_03,
        UPGRADE_04,
        UPGRADE_05,
        UPGRADE_06,
        UPGRADE_07,
        UPGRADE_08,
        UPGRADE_09,
        UPGRADE_10
    }

    public enum TerrainScorchType
    {
        RANDOM = -1,
        SCORCH_1,
        SCORCH_2,
        SCORCH_3,
        SCORCH_4,
        SCORCH_5,
        SCORCH_6,
        SCORCH_7,
        SCORCH_8,
        SCORCH_9,
        SCORCH_10,
        SCORCH_11,
        SCORCH_12,
        SCORCH_13,
        SCORCH_14,
        SCORCH_15,
        SCORCH_16,
    }

    public enum LivingWorldObjectType
    {
        ARMY,
        BATTLE_MARKER,
        REGION_DISPUTE,
        CLOUD,
        BUILDING,
        BUILDPLOT,
        DEFAULT,
        ANY
    }
}
