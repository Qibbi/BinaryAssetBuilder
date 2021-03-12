using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum TargetingHeuristicType
    {
        BaseDefense,
        EnemyStructure,
        FriendlyStructure,
        EnemyUnit,
        FriendlyUnit,
        Expansion,
        Prioritized,
        TechBuilding,
        Bridge,
        NeutralGarrison,
        AntiGarrison,
        Beacon,
        Crate
    }

    public enum AITargetSortType
    {
        Distance,
        ThreatToGround,
        ThreatToAir,
        Random
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AITargetingHeuristic
    {
        public BaseAssetType Base;
        public TargetingHeuristicType HeuristicType;
        public AITargetType ReturnTargetType;
        public AITargetSortType SortType;
        public KindOfBitFlags VitalKindOf;
        public KindOfBitFlags ForbiddenKindOf;
        public unsafe float* ThreatFinderRange;
        public float SearchRange;
        public List<KindOfBitFlags> PrioritizedKindOf;
        public SageBool Destroyed;
    }
}
