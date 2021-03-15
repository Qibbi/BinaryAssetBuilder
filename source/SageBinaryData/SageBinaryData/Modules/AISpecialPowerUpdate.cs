using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AISpecialPowerUpdateModuleData
    {
        public UpdateModuleData Base;
        public TypedAssetId<LogicCommand> CommandButtonName;
        public TypedAssetId<LogicCommand> SecondaryCommandButtonName;
        public AISpecialPowerInstanceType SpecialPowerAIType;
        public float SpecialPowerRadius;
        public float ReinforceDistance;
        public TypedAssetId<GameObject> SpellMakesAStructure;
        public TypedAssetId<GameObject> SpecificUnit;
        public KindOfBitFlags UnitKindOf;
        public KindOfBitFlags AllyUnitInclude;
        public KindOfBitFlags AllyUnitExclude;
        public KindOfBitFlags EnemyUnitInclude;
        public KindOfBitFlags EnemyUnitExclude;
        public int MinimumCutoff;
        public Time UpdateTime;
        public int MaxFrequency;
        public SageBool RandomizeTargetLocation;
    }
}
