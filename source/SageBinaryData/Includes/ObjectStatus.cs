using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum ObjectStatusType
    {
        DESTROYED,
        CAN_ATTACK,
        UNDER_CONSTRUCTION,
        UNSELECTABLE,
        NO_COLLISIONS,
        NO_ATTACK,
        AIRBORNE_TARGET,
        PARACHUTING,
        REPULSOR,
        HIJACKED,
        AFLAME,
        BURNED,
        CANNOT_BE_SOLD,
        IS_FIRING_WEAPON,
        IS_BRAKING,
        STEALTHED,
        HIDDEN,
        DETECTED,
        CAN_STEALTH,
        SOLD,
        UNDERGOING_REPAIR,
        RECONSTRUCTING,
        IS_ATTACKING,
        NO_AUTO_ACQUIRE,
        USING_ABILITY,
        IS_AIMING_WEAPON,
        NO_ATTACK_FROM_AI,
        IGNORING_STEALTH,
        IS_MELEE_ATTACKING,
        GUARD_SELECTION,
        LEASHED_RETURNING,
        DEATH_1,
        DEATH_2,
        DEATH_3,
        DEATH_4,
        DEATH_5,
        CONTESTED,
        CONTESTING_BUILDING,
        HORDE_MEMBER,
        RIDERLESS,
        RIDER_IS_PILOT,
        RIDER1,
        RIDER2,
        RIDER3,
        RIDER4,
        NO_SHADOW,
        IN_STASIS,
        OUT_OF_PHASE,
        NEXT_MOVE_IS_REVERSE,
        IMMOBILE,
        FLEE_OFF_MAP,
        NOT_IN_WORLD,
        INAUDIBLE,
        CHANTING,
        ENRAGED,
        CREATE_DRAWABLE_WITH_LOW_DETAIL,
        SINKING,
        RAMPAGING,
        INSIDE_GARRISON,
        DEPLOYED,
        UNATTACKABLE,
        ENCLOSED,
        TEMPORARILY_DEFECTED,
        TAGGED,
        DEPLOYING,
        PRIMARY_MEMBER_PRESENT,
        PORTER_TAGGED,
        GRAB_AND_DROP,
        STAND_GROUND,
        UNCONTROLLABLY_SCARED,
        SPECIAL_ABILITY_PACKING_UNPACKING_OR_USING,
        TIBERIUM_VIBRATING,
        UPDATING_AI,
        CLONED,
        IGNORE_AI_COMMAND,
        RUNNING_DOWN_FROM_BEHIND,
        DO_NOT_SCORE,
        CAN_NOT_WALK_ON,
        MARCH_OF_DEATH,
        DO_NOT_PICK_ME,
        INHERITED_FROM_ALLY_TEAM,
        SWITCHED_WEAPONS,
        END_FIRE_STATE,
        BOOKENDING,
        ELVISH_EXPRESSLY,
        INSIDE_CASTLE,
        BUILD_BEING_CANCELED,
        PENDING_CONSTRUCTION,
        PHANTOM_STRUCTURE,
        IN_FORMATION_TEMPLATE,
        IS_LEAVING_FACTORY,
        MOVING_TO_DISMOUNT,
        NO_HERO_PROPERTIES,
        CAN_ENTER_ANYTHING,
        HOLDING_THE_RING,
        INVISIBLE_DETECTED_BY_FRIEND,
        INVISIBLE_DETECTED,
        WORKER_REPAIRING,
        ATTACHED,
        WONT_RIDE_WITH_YOU,
        COMMAND_BUTTON_TOGGLED,
        OCLMONITOR_COMPLETED_TASK,
        OCLMONITOR_MONITOR_RELEASED,
        USER_POWERED_DOWN,
        GARRISONED,
        BOOBY_TRAPPED,
        IS_HIDEOUT,
        SUICIDE_BOMBER_HAS_TARGET,
        UNIT_WANTS_TO_REGARRISON,
        IN_COVER,
        DONT_CLEAR_FOR_BUILD,
        MATCH_TARGETS_SPEED,
        HAS_TIBERIUM_GROWTH_MOD,
        HAS_TIBERIUM_UPGRADE,
        STEAL_NEXT_UNIT_TRAPPED,
        DOES_CONTAIN_TIBERIUM,
        IS_BEING_HARVESTED,
        HAS_TIBERIUM_AMMO,
        SHIELDBODY_ENABLED,
        HEALTH_PERCENT_0,
        HEALTH_PERCENT_25,
        HEALTH_PERCENT_50,
        HEALTH_PERCENT_75,
        HEALTH_PERCENT_100,
        WEAPON_UPGRADED_01,
        WEAPON_UPGRADED_02,
        WEAPON_UPGRADED_03,
        COMBINED_PARENT,
        COMBINED_CHILD,
        COMBINED_ATTACHED,
        LOADED_FROM_MAP,
        ATTACKING_GARRISONED_STRUCTURE,
        EXITING_COMBINED,
        DELAYED_ENTER_STRUCTURE,
        DOCKING,
        HARVESTING,
        BRIDGE_IMPASSABLE,
        POWERED_DOWN_EMP,
        FORCE_ATTACKING,
        FORCE_ATTACK_MOVING,
        SCARED_CIVILIAN_CAR,
        USER_PARALYZED,
        BOOBY_TRAP_EXPLODE,
        IS_ENGAGED,
        CARRYING_FLAG,
        IS_MOVING_TO_RALLY_POINT,
        CAN_SPOT_FOR_BOMBARD,
        AIRCRAFT_IGNORE_SAMEPLAYER_HANGAR_RULE,
        NEXT_MOVE_IS_FORCE_ATTACK_MOVE,
        SPECIALABILITY_ACTIVE,
        CAN_STEALTH_FROM_PRODUCER
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ObjectStatusBitFlags
    {
        public const int Count = 151;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum DeathType
    {
        NONE,
        NORMAL,
        CRUSHED,
        BURNED,
        EXPLODED,
        POISONED,
        TOPPLED,
        FLOODED,
        SUICIDED,
        LASERED,
        DETONATED,
        SPLATTED,
        POISONED_BETA,
        EXTRA_2,
        EXTRA_3,
        EXTRA_4,
        EXTRA_5,
        EXTRA_6,
        EXTRA_7,
        EXTRA_8,
        KNOCKBACK,
        SUPERNATURAL,
        FADED,
        SLAUGHTERED,
        CATALYST
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DeathBitFlags
    {
        public const int Count = 25;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DamageBitFlags
    {
        public const int Count = 34;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }

    public enum DamageSubType
    {
        NORMAL,
        BECOME_UNDEAD,
        SELF,
        UNDEFINED
    }

    public enum InvisibilityType
    {
        INVALID = -1,
        STEALTH,
        CAMOUFLAGE
    }

    public enum InvisibilityNuggetOptions
    {
        ALLOW_NEAR_TREES,
        DETECTED_BY_FRIENDLIES,
        DISCONTINUE_WHEN_REVEALED,
        UNTOGGLE_HIDDEN_WHEN_LEAVING_STEALTH
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InvisibilityNuggetOptionsBitFlags
    {
        public const int Count = 4;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }
}
