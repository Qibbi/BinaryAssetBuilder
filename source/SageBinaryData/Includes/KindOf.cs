﻿using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum KindOf
    {
        OBSTACLE,
        SELECTABLE,
        TARGETABLE,
        ALLY_TARGETABLE,
        IMMOBILE,
        CAN_ATTACK,
        STICK_TO_TERRAIN_SLOPE,
        CAN_CAST_REFLECTIONS,
        SHRUBBERY,
        STRUCTURE,
        INFANTRY,
        CAVALRY,
        MONSTER,
        MACHINE,
        AIRCRAFT,
        HUGE_VEHICLE,
        DOZER,
        SWARM_DOZER,
        HARVESTER,
        COMMANDCENTER,
        CASTLE_CENTER,
        SALVAGER,
        WEAPON_SALVAGER,
        TRANSPORT,
        BRIDGE,
        CANT_TOGGLE_POWER,
        SIEGE_WEAPON,
        PROJECTILE,
        PRELOAD,
        NO_GARRISON,
        CASTLE_KEEP,
        SHADOW_ULTRA_HIGH_ONLY,
        NO_COLLIDE,
        REPAIR_PAD,
        HEAL_PAD,
        STEALTH_GARRISON,
        SUPPLY_GATHERING_CENTER,
        AIRFIELD,
        DRAWABLE_ONLY,
        MP_COUNT_FOR_VICTORY,
        REBUILD_HOLE,
        SCORE,
        SCORE_CREATE,
        SCORE_DESTROY,
        NO_HEAL_ICON,
        CAN_RAPPEL,
        PARACHUTABLE,
        CAN_BE_REPULSED,
        MOB_NEXUS,
        IGNORED_IN_GUI,
        CRATE,
        CAPTURABLE,
        LINKED_TO_FLAG,
        CLEARED_BY_BUILD,
        SMALL_MISSILE,
        ALWAYS_VISIBLE,
        UNATTACKABLE,
        MINE,
        CAN_PLACE_CHARGE,
        PORTABLE_STRUCTURE,
        ALWAYS_SELECTABLE,
        ATTACK_NEEDS_LINE_OF_SIGHT,
        WALK_ON_TOP_OF_WALL,
        DEFENSIVE_WALL,
        FS_POWER,
        FS_FACTORY,
        FS_BASE_DEFENSE,
        FS_TECHNOLOGY,
        AIRCRAFT_PATH_AROUND,
        LOW_OVERLAPPABLE,
        FORCEATTACKABLE,
        AUTO_RALLYPOINT,
        CAN_CAPTURE,
        POWERED,
        PRODUCED_AT_HELIPAD,
        DRONE,
        CAN_SEE_THROUGH_STRUCTURE,
        BALLISTIC_MISSILE,
        CLICK_THROUGH,
        SUPPLY_SOURCE_ON_PREVIEW,
        PARACHUTE,
        GARRISONABLE_UNTIL_DESTROYED,
        BOAT,
        IMMUNE_TO_CAPTURE,
        HULK,
        CAN_PLACE_MANIPULATOR,
        SPAWNS_ARE_THE_WEAPONS,
        CANNOT_BUILD_NEAR_SUPPLIES,
        SUPPLY_SOURCE,
        REVEAL_TO_ALL,
        DISGUISER,
        INERT,
        HERO,
        IGNORES_SELECT_ALL,
        DONT_AUTO_CRUSH_INFANTRY,
        SIEGE_TOWER,
        TREE,
        SHRUB,
        CLUB,
        ROCK,
        THROWN_OBJECT,
        GRAB_AND_KILL,
        OPTIMIZED_PROP,
        ENVIRONMENT,
        DEFLECT_BY_SPECIAL_POWER,
        WORKING_PASSENGER,
        BASE_FOUNDATION,
        NEED_BASE_FOUNDATION,
        REACT_WHEN_SELECTED,
        CAN_BE_CAPTURED,
        IGNORED_IN_FINDPOSITIONAROUND,
        HORDE,
        COMBO_HORDE,
        NONOCCLUDING,
        NO_FREEWILL_ENTER,
        TIBERIUM_FIELD,
        BEAM_TARGET,
        BEAM_TARGET_REFLECTOR,
        TACTICAL_MARKER,
        PATH_THROUGH_EACH_OTHER,
        NOTIFY_OF_PREATTACK,
        GARRISON,
        MELEE_HORDE,
        BASE_SITE,
        INERT_SHROUD_REVEALER,
        OCL_BIT,
        SPELL_BOOK,
        DEPRECATED,
        PATH_THROUGH_INFANTRY,
        NO_FORMATION_MOVEMENT,
        NO_BASE_CAPTURE,
        ARMY_SUMMARY,
        CIVILIAN_UNIT,
        NOT_AUTOACQUIRABLE,
        KEEP_CLASSIFIED_WHEN_DEAD,
        CHUNK_VENDOR,
        ARCHER,
        MOVE_ONLY,
        FS_CASH_PRODUCER,
        ROCK_VENDOR,
        BLOCKING_GATE,
        CRANE,
        SIEGE_LADDER,
        MINE_TRIGGER,
        BUFF,
        GRAB_AND_DROP,
        PORTER,
        SCARY,
        CRITTER_EMITTER,
        BROADCASTS_INVISIBILITY,
        CAN_ATTACK_WALLS,
        IGNORE_FOR_VICTORY,
        DO_NOT_CLASSIFY,
        WALL_UPGRADE,
        ARMY_OF_DEAD,
        TAINT,
        BASE_DEFENSE_FOUNDATION,
        NOT_SELLABLE,
        WEBBED,
        WALL_HUB,
        BUILD_FOR_FREE,
        IGNORE_FOR_EVA_SPEECH_POSITION,
        MADE_OF_WOOD,
        MADE_OF_METAL,
        MADE_OF_STONE,
        MADE_OF_DIRT,
        FACE_AWAY_FROM_CASTLE_KEEP,
        BANNER,
        I_WANT_TO_EAT_YOU,
        CAN_REVERSE_MOVE,
        PASS_EXPERIENCE_TO_SLAVER,
        HAS_HEALTH_BAR,
        BIG_MONSTER,
        DEPLOYED_MINE,
        CANNOT_RETALIATE,
        CREEP,
        TAINTEFFECT,
        POWERED_POWERS_ONLY,
        VITAL_FOR_BASE_SURVIVAL,
        DO_NOT_PICK_ME_WHEN_BUILDING,
        SUMMONED,
        HIDE_IF_FOGGED,
        ALWAYS_SHOW_HOUSE_COLOR,
        MOVE_FOR_NOONE,
        WB_DISPLAY_SCRIPT_NAME,
        CAN_CLIMB_WALLS,
        NO_SHADOW,
        LARGE_RECTANGLE_PATHFIND,
        SUBMARINE,
        PORT,
        WALL_SEGMENT,
        SIMPLE_OBJECT_PROP,
        SHIP,
        OPTIMIZED_SOUND,
        PASS_EXPERIENCE_TO_CONTAINED,
        DOZER_FACTORY,
        THREAT_FINDER,
        ECONOMY_STRUCTURE,
        LIVING_WORLD_BUILDING_MIRROR,
        CAN_TOPPLE,
        NONCOM,
        CAN_SKIP_SHADOW,
        SCALEABLE_WALL,
        SKYBOX,
        WALL_GATE,
        CAPTUREFLAG,
        NEUTRALGOLLUM,
        PASS_EXPERIENCE_TO_CONTAINER,
        RESIST_EMP,
        ORIENTS_TO_CAMERA,
        NEVER_CULL_FOR_MP,
        DONT_USE_CANCEL_BUILD_BUTTON,
        CIVILIAN_BUILDING,
        HEAVY_MELEE_HITTER,
        DONT_HIDE_IF_FOGGED,
        VEHICLE,
        HARVESTABLE,
        GRABBABLE,
        CONSTRUCTION_YARD,
        CAN_SHOOT_OVER_WALLS,
        PASS_EXPERIENCE_TO_PRODUCER,
        EXPANSION_PAD,
        AMPHIBIOUS,
        SHOW_BEHIND_OCCLUDERS,
        FS_MONEY_STORAGE,
        VALID_TARGET_FOR_C4,
        UNIQUE_UNIT,
        SURPRISE_ATTACKER,
        COVER,
        INFILTRATOR,
        BRIDGE_SEGMENT,
        FS_WAR_FACTORY,
        FS_BARRACKS,
        FS_RADAR,
        FS_AIR_FIELD,
        FS_TECH_CENTER,
        TIBERIUM_BASED,
        TIBERIUM,
        CAN_ATTACK_STEALTHED,
        IMMUNE_TO_CYCLONIC_SHOCKWAVE,
        CANNOT_BE_DETECTED,
        AUTO_ACQUIRABLE_BY_AI,
        CRUSHABLE_OBSTACLE,
        NEUTRAL_TECH,
        SUPER_WEAPON,
        HEALED_BY_TIBERIUM,
        IGNORE_CAN_NOT_BUILD,
        SKIRMISH_AI_DONT_GARRISON,
        ASSAULT_AIRCRAFT,
        BOMBER_AIRCRAFT,
        ANTI_GARRISON,
        ENGINEER,
        EXPANSION_UNIT,
        OUTPOST,
        BEACON,
        HUSK,
        IGNORE_FORCE_MOVE,
        LINE_OF_SIGHT_IGNORES_BUILDINGS,
        MOTHERSHIP,
        SNIPER,
        ATTACK_FROM_STRUCTURE_ONLY_WHEN_GARRISONED,
        SKIP_DEFECT_IF_UNCOMBINED,
        SKIP_IDLE_WHEN_CAPTURED,
        BRIDGE_ENDCAP,
        BRIDGE_GATEHOUSE,
        CAN_BE_FAVORITE_UNIT,
        SLAVE_OWNER,
        MCV,
        CAN_HEAL_ALLIES,
        PROJECT_BUILDABILITY_FOR_ALLIES
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KindOfBitFlags
    {
        public const int Count = 270;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }
}
