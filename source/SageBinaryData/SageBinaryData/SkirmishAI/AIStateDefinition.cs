using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum AITargetType
    {
        PrimaryTarget,
        SecondaryTarget,
        FocusedTarget,
        SpreadTarget,
        SiegeTarget,
        ExtraTarget,
        Guard,
        SpecialDefense,
        EngineerDefense,
        CommandoDefense,
        ExpansionDefense,
        Counterattack,
        Airstrike,
        AssaultAirstrike,
        BombingAirstrike,
        Superweapon,
        Engineer,
        Commando,
        CaptureTech,
        Garrison,
        AntiGarrison,
        Bridge,
        Isolation,
        Beacon,
        Crate,
        Husk,
        Capture,
        Structure,
        Unit,
        Defensive,
        Diversion,
        Expansion,
        Opportunity,
        Targetless
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateHeuristic : IPolymorphic
    {
        public uint TypeId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateConstantHeuristic
    {
        public AIStateHeuristic Base;
        public float Weight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateTimerHeuristic
    {
        public AIStateHeuristic Base;
        public Time StartTime;
        public Time EndTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateIntervalHeuristic
    {
        public AIStateHeuristic Base;
        public Time IntervalTime;
        public Time ActiveTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateOpeningMoveHeuristic
    {
        public AIStateHeuristic Base;
        public SageBool Complete;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateHarvesterCapHeuristic
    {
        public AIStateHeuristic Base;
        public uint MaxHarvesters;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateMoneyHeuristic
    {
        public AIStateHeuristic Base;
        public uint Money;
        public SageBool Above;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateFullInvestmentHeuristic
    {
        public AIStateHeuristic Base;
        public uint Threshold;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateFullTechHeuristic
    {
        public AIStateHeuristic Base;
        public uint Threshold;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateAntiGarrisonTechHeuristic
    {
        public AIStateHeuristic Base;
        public uint EnemyGarrisons;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStatePathToTargetHeuristic
    {
        public AIStateHeuristic Base;
        public SageBool PathExists;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateCounterattackHeuristic
    {
        public AIStateHeuristic Base;
        public float Threshold;
        public KindOfBitFlags AttackerKindOf;
        public KindOfBitFlags DefenderKindOf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateEnemyNearbyHeuristic
    {
        public AIStateHeuristic Base;
        public float Distance;
        public KindOfBitFlags AttackerKindOf;
        public KindOfBitFlags DefenderKindOf;
        public SageBool EnemyNearby;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateFocusedThresholdHeuristic
    {
        public AIStateHeuristic Base;
        public KindOfBitFlags AttackerKindOf;
        public KindOfBitFlags DefenderKindOf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateSpreadThresholdHeuristic
    {
        public AIStateHeuristic Base;
        public KindOfBitFlags AttackerKindOf;
        public KindOfBitFlags DefenderKindOf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateSiegeThresholdHeuristic
    {
        public AIStateHeuristic Base;
        public float Threshold;
        public SageBool SiegeMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateBalanceOfPowerHeuristic
    {
        public AIStateHeuristic Base;
        public KindOfBitFlags AttackerKindOf;
        public KindOfBitFlags DefenderKindOf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStatePowerAdvantageHeuristic
    {
        public AIStateHeuristic Base;
        public KindOfBitFlags AttackerKindOf;
        public KindOfBitFlags DefenderKindOf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStatePenetrabilityHeuristic
    {
        public AIStateHeuristic Base;
        public KindOfBitFlags AttackerKindOf;
        public KindOfBitFlags DefenderKindOf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateVulnerabilityHeuristic
    {
        public AIStateHeuristic Base;
        public KindOfBitFlags AttackerKindOf;
        public KindOfBitFlags DefenderKindOf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateOpponentAAPowerHeuristic
    {
        public AIStateHeuristic Base;
        public KindOfBitFlags AttackerKindOf;
        public KindOfBitFlags DefenderKindOf;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateOpponentFundsHeuristic
    {
        public AIStateHeuristic Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateOpponentPowerThresholdHeuristic
    {
        public AIStateHeuristic Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateMiddleGameHeuristic
    {
        public AIStateHeuristic Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateLateGameHeuristic
    {
        public AIStateHeuristic Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateProductionAdvantageHeuristic
    {
        public AIStateHeuristic Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateBridgeExistsHeuristic
    {
        public AIStateHeuristic Base;
        public Percentage BridgeHealthMinimumPercentage;
        public Percentage BridgeHealthMaximumPercentage;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateSuperweaponHeuristic
    {
        public AIStateHeuristic Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateOverpowerHeuristic
    {
        public AIStateHeuristic Base;
        public float PowerAdvantageWeight;
        public float PenetrabilityWeight;
        public AIStatePowerAdvantageHeuristic PowerAdvantageHeuristic;
        public AIStatePenetrabilityHeuristic PenetrabilityHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateResourceSqueezeHeuristic
    {
        public AIStateHeuristic Base;
        public float PenetrabilityWeight;
        public float OpponentFundsWeight;
        public AIStatePenetrabilityHeuristic PenetrabilityHeuristic;
        public AIStateOpponentFundsHeuristic OpponentFundsHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateProductionHaltHeuristic
    {
        public AIStateHeuristic Base;
        public float PenetrabilityWeight;
        public float BalanceOfPowerWeight;
        public AIStatePenetrabilityHeuristic PenetrabilityHeuristic;
        public AIStateBalanceOfPowerHeuristic BalanceOfPowerHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateBaseCrackHeuristic
    {
        public AIStateHeuristic Base;
        public AIStateLateGameHeuristic LateGameHeuristic;
        public AIStatePenetrabilityHeuristic PenetrabilityHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateOverrunEarlyHeuristic
    {
        public AIStateHeuristic Base;
        public AIStateMiddleGameHeuristic MiddleGameHeuristic;
        public AIStateLateGameHeuristic LateGameHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateOverrunMiddleHeuristic
    {
        public AIStateHeuristic Base;
        public AIStateMiddleGameHeuristic MiddleGameHeuristic;
        public AIStateLateGameHeuristic LateGameHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateOverrunLateHeuristic
    {
        public AIStateHeuristic Base;
        public AIStateLateGameHeuristic LateGameHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStatePowerCutHeuristic
    {
        public AIStateHeuristic Base;
        public AIStateOpponentPowerThresholdHeuristic OpponentPowerThresholdHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateEmergencyHeuristic
    {
        public AIStateHeuristic Base;
        public float Threshold;
        public AIStateVulnerabilityHeuristic VulnerabilityHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateScriptedFlagHeuristic
    {
        public AIStateHeuristic Base;
        public AnsiString FlagName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIAlliedBeaconExistsHeuristic
    {
        public AIStateHeuristic Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateLinearCombinationHeuristicWeightedHeuristic
    {
        public float Weight;
        public PolymorphicList<AIStateHeuristic> Heuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateLinearCombinationHeuristic
    {
        public AIStateHeuristic Base;
        public List<AIStateLinearCombinationHeuristicWeightedHeuristic> WeightedHeuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateDefinition
    {
        public BaseAssetType Base;
        public PolymorphicList<AIStateHeuristic> Heuristic;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StateTargetHeuristic
    {
        public AssetReference<AITargetingHeuristic> TargetHeuristic;
        public float WeightMultiplier;
        public unsafe AITargetType* TargetType;
    }

    public enum Tactics
    {
        SimpleAttack,
        FlankAttack,
        DefenseAvoidanceAttack,
        SimpleSiege,
        SiegeGates,
        Superweapon,
        Engineer,
        BasePenetrationTroops,
        SimpleDefense,
        StaticDefense,
        ReactiveDefense,
        SimpleExpansion,
        FarmKill,
        Hunt,
        RoamingDefense,
        StructureCreep,
        GarrisonBuilding
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateTactic
    {
        public Tactics Tactic;
        public AITargetType TargetType;
        public AIDifficultyBitFlags Difficulty;
        public List<AITeamTemplate> TeamTemplate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateUnitBuilderModifier : IPolymorphic
    {
        public uint TypeId;
        public int UnitBonus;
        public Percentage UnitPreferenceOffensiveModifier;
        public Percentage UnitPreferenceDefensiveModifier;
        public AIDifficultyBitFlags Difficulty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateUnitKindofModifier
    {
        public AIStateUnitBuilderModifier Base;
        public KindOfBitFlags UnitKind;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateUnitModifier
    {
        public AIStateUnitBuilderModifier Base;
        public TypedAssetId<GameObject> UnitName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStateUnitOverride
    {
        public TypedAssetId<GameObject> UnitName;
        public Percentage Percentage;
        public AIDifficultyBitFlags Difficulty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStrategicStateDefinition
    {
        public AIStateDefinition Base;
        public float UnitUpgradeMultiplier;
        public unsafe float* UnitBuilderCostEffectivenessWeight;
        public unsafe float* UnitBuilderMoneyVersusTimePreference;
        public unsafe Percentage* UnitBuilderOverallOffensivePreference;
        public unsafe Percentage* UnitBuilderOverallDefensivePreference;
        public unsafe Percentage* UnitBuilderEnemyTowerWeight;
        public unsafe int* UnitBuilderSimpleUnitCap;
        public List<StateTargetHeuristic> TargetHeuristic;
        public List<AIStateTactic> Tactic;
        public List<AIStateUnitKindofModifier> UnitModifierByKind;
        public List<AIStateUnitModifier> UnitModifierByName;
        public List<AIStateUnitOverride> UnitOverride;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIBudgetStateDefinition
    {
        public AIStateDefinition Base;
        public AIBankBudget Budget;
    }
}
