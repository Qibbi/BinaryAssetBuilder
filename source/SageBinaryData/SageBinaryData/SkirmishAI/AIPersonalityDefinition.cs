using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AITarget
    {
        public AITargetType TacticalAITarget;
        public int MaxTeamsPerTarget;
        public Time UpdateTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIStrategicState
    {
        public AssetReference<AIStrategicStateDefinition> State;
        public AIDifficultyBitFlags Difficulty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIBudgetState
    {
        public AssetReference<AIBudgetStateDefinition> State;
        public AIDifficultyBitFlags Difficulty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIBuildDelay
    {
        public Time Delay;
        public AIDifficultyBitFlags Difficulty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIResourceMultiplierCheat
    {
        public Percentage Percentage;
        public AIDifficultyBitFlags Difficulty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIBuildDelayRange
    {
        public Time MinDelay;
        public Time MaxDelay;
        public float MinTTKRatio;
        public float MaxTTKRatio;
        public AIDifficultyBitFlags Difficulty;
    }

    public enum AIUnitBuilderUnitChoiceShape
    {
        BEST,
        MIDDLE,
        WORST,
        FLAT
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIUnitBuilderUnitChoiceStrategy
    {
        public AIUnitBuilderUnitChoiceShape Shape;
        public float StandardDeviation;
        public AIDifficultyBitFlags Difficulty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIUnitBuilderUnitChoiceStrategyAdaptive
    {
        public float MinEffectiveness;
        public float MaxEffectiveness;
        public float MinStandardDeviation;
        public float MaxStandardDeviation;
        public float MinEfficiency;
        public float MaxEfficiency;
        public AIDifficultyBitFlags Difficulty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIUnitBuilderEvaluationDelayRange
    {
        public Time MinDelay;
        public Time MaxDelay;
        public float MinEfficiency;
        public float MaxEfficiency;
        public AIDifficultyBitFlags Difficulty;
        public SageBool UseAllAvailableQueues;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIPersonalityDefMap
    {
        public AnsiString Side;
        public AssetReference<BaseAssetType> Personality; // should be AssetReference<AIPersonalityDefMap> but .net thinks it might be a circular reference
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIWeightedOpeningMove
    {
        public AssetReference<SkirmishOpeningMove> Name;
        public Percentage Weight;
        public AIDifficultyBitFlags Difficulty;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AISpecificUnitCap
    {
        public TypedAssetId<GameObject> Unit;
        public int Cap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIPersonalityDefinition
    {
        public BaseInheritableAsset Base;
        public AnsiString PersonalityType;
        public AnsiString PersonalityUIName;
        public float SecondsTillTargetsCanExpire;
        public Percentage ChanceForTargetToExpire;
        public Percentage ChanceForUnitsToUpgrade;
        public int MaxBuildingsToBeDefensiveTarget_Small;
        public int MaxBuildingsToBeDefensiveTarget_Med;
        public Percentage ChanceToUseAllUnitsForDefenseTarget_Small;
        public Percentage ChanceToUseAllUnitsForDefenseTarget_Med;
        public Percentage ChanceToUseAllUnitsForDefenseTarget_Large;
        public int DesiredExcessPowerBuffer;
        public float BaseCompactness;
        public float DefaultThreatFindRadius;
        public float UnitBuilderCostEffectivenessWeight;
        public float UnitBuilderMoneyVersusTimePreference;
        public Percentage UnitBuilderOverallOffensivePreference;
        public Percentage UnitBuilderOverallDefensivePreference;
        public Percentage UnitBuilderEnemyTowerWeight;
        public float Expansion_TiberiumSearchRadius;
        public int Expansion_MaxTiberiumRemaining;
        public float ReactiveDefenseRadius;
        public AIDifficultyBitFlags RepairBuildingsAtDifficulty;
        public AIDifficultyBitFlags EmergencyManagerHandleNoPowerAtDifficulty;
        public AIDifficultyBitFlags EmergencyManagerHandleNoIncomeAtDifficulty;
        public AIDifficultyBitFlags EmergencyManagerHandleNoConyardAtDifficulty;
        public float StructureSaveChanceEasy;
        public float StructureSaveChanceMedium;
        public float StructureSaveChanceHard;
        public uint MinHarvesters;
        public float TimeToBeConsideredIdle;
        public List<AnsiString> Side;
        public List<AIPersonalityDefMap> PersonalityMap;
        public List<AIBuildDelay> BuildDelay;
        public List<AIBuildDelayRange> BuildDelayRange;
        public List<AIUnitBuilderUnitChoiceStrategy> UnitBuilderUnitChoiceStrategy;
        public List<AIUnitBuilderUnitChoiceStrategyAdaptive> UnitBuilderUnitChoiceStrategyAdaptive;
        public List<AIUnitBuilderEvaluationDelayRange> UnitBuilderEvaluationDelayRange;
        public List<AIResourceMultiplierCheat> ResourceMultiplierCheat;
        public List<AITarget> TacticalTarget;
        public List<AISpecificUnitCap> SpecificUnitCap;
        public List<AssetReference<SkirmishOpeningMove>> OpeningMoves;
        public List<AIWeightedOpeningMove> OpeningMove;
        public List<AIStrategicState> States;
        public List<AIBudgetState> BudgetStates;
        public List<AIStateUnitOverride> UnitOverride;
        public SageBool SkirmishPersonality;
    }
}
