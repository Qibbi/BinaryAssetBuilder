using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TargetingBaseCompare
    {
        public BaseAssetType Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TargetingDistanceCompare
    {
        public TargetingBaseCompare Base;
        public float Tolerance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TargetingCombatChainCompare
    {
        public TargetingBaseCompare Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TargetingInTurretArcCompare
    {
        public TargetingBaseCompare Base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TargetingCompareList
    {
        public BaseAssetType Base;
        public List<AssetReference<TargetingBaseCompare>> Compare;
    }
}
