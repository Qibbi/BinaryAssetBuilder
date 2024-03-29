﻿namespace SageBinaryData;

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
    STORM_SHIELD,
#if KANESWRATH
    METAGAME_POPULATION,
    METAGAME_UNREST,
    METAGAME_TIBERIUM
#endif
}
