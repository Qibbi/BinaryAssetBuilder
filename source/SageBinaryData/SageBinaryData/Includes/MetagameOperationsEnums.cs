﻿#if KANESWRATH
using System.Runtime.InteropServices;

namespace SageBinaryData;

public enum MetagameOperationsEnums
{
    INVALID = -1,
    CONSTRUCT_NEW_TIER_1_BASE,
    UPGRADE_BASE_TIER_2,
    UPGRADE_BASE_TIER_3,
    UPGRADE_BASE_DEFENSES,
    UPGRADE_BASE_EXTRA_POWER,
    REPAIR_BASE,
    DECOMMISSION_BASE,
    DETAILS_BASE,
    CONSTRUCT_STRIKE_FORCE_UL,
    CONSTRUCT_STRIKE_FORCE_L,
    CONSTRUCT_STRIKE_FORCE_M,
    CONSTRUCT_STRIKE_FORCE_H,
    CONSTRUCT_STRIKE_FORCE_UH,
    DECOMMISSION_STRIKE_FORCE,
    RESUPPLY_STRIKE_FORCE,
    DETAILS_STRIKE_FORCE,
    UPGRADE_STRIKE_FORCE,
    MOVE_STRIKE_FORCE,
    PATROL_STRIKE_FORCE,
    INTERCEPT_STRIKE_FORCE,
    CONSTRUCT_STRATEGIC_BUILDING,
    NAVAL_MOVE,
    AIRLIFT,
    REQUEST_TO_SELL,
    GDI_POWER_ION_BLAST,
    GDI_POWER_REFUGEE_AID,
    GDI_POWER_SKY_SENTRY,

    GDI_POWER_FIREHAWK_RAID,
    GDI_POWER_MEDIA_BLITZ,
    GDI_POWER_FIRESTORM_GENERATOR,
    GDI_POWER_COMMANDO_STRIKE,
    GDI_POWER_STATE_OF_EMERGENCY,

    GDI_POWER_SPECIAL_FORCES,
    GDI_POWER_SONIC_AGITATION,
    GDI_POWER_ZOCOM_INFILTRATION,
    NOD_POWER_VERTIGO_STRIKE,
    NOD_POWER_DOGS_OF_WAR,
    NOD_POWER_THE_FURY_OF_NOD,
    NOD_POWER_STEALTH_FIELD,
    NOD_POWER_BLACK_HAND,
    NOD_POWER_MARKED_OF_KANE,
    NOD_POWER_KANE_LIVES,
    NOD_POWER_FRIENDS_OF_NOD,
    NOD_POWER_NUCLEAR_MISSILE,
    NOD_POWER_BOOBY_TRAPS,
    NOD_POWER_FORCEABLE_EVOLUTION,
    NOD_POWER_RAISE_INSURRECTION,
    NOD_POWER_SABOTAGE,
    NOD_POWER_TRAITOR,
    NOD_POWER_DECOY_BASE,
    NOD_POWER_GUERRILLA_WARFARE,
    SCRIN_POWER_WORMHOLE,
    SCRIN_POWER_ION_SUPERSTORM,
    SCRIN_POWER_ORBITAL_TRANSPORT,
    SCRIN_POWER_PHASE_FIELD,
    SCRIN_POWER_DROPSHIP,
    SCRIN_POWER_ERADICATE,
    SCRIN_POWER_ASSIMILATE_TECHNOLOGY,
    SCRIN_POWER_ICHOR_INJECTION,
    SCRIN_POWER_ALIEN_PLAGUE,
    SCRIN_POWER_INFESTATION,
    SCRIN_POWER_PLANETARY_BOMBARDMENT,
    RANDOM_POWER_WEATHER,
    RANDOM_POWER_NOD_SPLINTER_GROUP,
    RANDOM_POWER_REFINERY_EXPLOSION,
    RANDOM_POWER_COMMAND_INTRIGUES,
    RANDOM_POWER_MUTANT_GUERRILLAS,
    RANDOM_POWER_MUTANT_ATTACK,
    RANDOM_POWER_FAMINE,
    RANDOM_POWER_POPULATION_BOOM,
    RANDOM_POWER_LOGISTICS_SNAFU,
    RANDOM_POWER_CORRUPTION,
    RANDOM_POWER_FIELD_REFIT,
    RANDOM_POWER_TIBERIUM_EXPOSURE,
    CONSTRUCT_QUEUED_STRIKEFORCE_UL,
    CONSTRUCT_QUEUED_STRIKEFORCE_L,
    CONSTRUCT_QUEUED_STRIKEFORCE_M,
    CONSTRUCT_QUEUED_STRIKEFORCE_H,
    CONSTRUCT_QUEUED_STRIKEFORCE_UH,
    NOD_POWER_NUCLEAR_MISSILE_WARHEAD,
    NOD_POWER_TIBERIUM_PRODUCTION_SURGE,
    NOD_POWER_DEACTIVATE_STEALTH_FIELD,
    CONSTRUCT_QUEUED_STRATEGIC_BUILDING,
    CANCEL_PENDING_OPERATION,
    GDI_POWER_ION_BLAST_WARHEAD,
    WORMHOLE_MOVE,
    SCRIN_POWER_PLANETARY_BOMBARDMENT_WARHEAD,
    SPECIAL_TRAVEL_POWERS,
    PATROL_STRIKE_FORCE_REPEATING,
    BUILD_STRIKEFORCE,
    SCRIN_POWER_RIFT_GENERATOR,
    SCRIN_POWER_RIFT_GENERATOR_WARHEAD,
    SCRIN_POWER_BUILD_TOWER
}

public enum MGStrikeForceResultType
{
    VeterancyUp,
    VeterancyDown,
    Damaged,
    Killed
}

public enum MGRTSPlayerEffectFlagType
{
    Traitor,
    EliminatedEarly,
    Ion_Superstorm
}

public enum MGPowerPrereqFlagType
{
    // GDI
    ION_CANNON,
    ASAT_DEFENSE,
    INTELLIGENCE_OP_CENTER,
    RECLAMATOR_HUB,
    TIBERIUM_PROCESSING_CENTER,
    // Nod
    TEMPLE_OF_NOD,
    PROPAGANDA_CENTER,
    TIBERIUM_FORGE,
    WARMECH_ENGINEERING_FACILITY,
    STEALTH_TOWER,
    // Scrin
    RIFT_GENERATOR,
    TERRAFORMING_NEXUS,
    LIFE_FORM_RECYCLING_PLANT,
    HIVE,
    
    ALIEN_TOWER,
    
    AIR_TOWER,
    TIER_1_BASE,
    TIER_2_BASE,
    TIER_3_BASE,
    
    DISABLE_STRAT_BUILDING_1,
    DISABLE_STRAT_BUILDING_2,
    DISABLE_STRAT_BUILDING_3,
    DISABLE_STRAT_BUILDING_4,
    DISABLE_STRAT_BUILDING_5
}

[StructLayout(LayoutKind.Sequential)]
public struct MGPowerPrereqBitFlags
{
    public const int Count = 24;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

public enum MetaGameDependencyEnum
{
    StrikeForceIsNearTransportObject,
    StrikeForceHasMcvOrDronePlatform,
    StrikeForceIsNearTier3Base,
    StrikeForceUpgradeNotYetPurchased,
    BaseHasNotYetBuiltStrategicBuilding,
    BaseDefenseUpgradeNotYetPurchased,
    BasePowerUpgradeNotYetPurchased,
    BaseTierUpgradeNotYetPurchased
}

[StructLayout(LayoutKind.Sequential)]
public struct MetaGameDependenciesType
{
    public const int Count = 8;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}
#endif
