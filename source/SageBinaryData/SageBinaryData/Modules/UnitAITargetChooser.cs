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

    [StructLayout(LayoutKind.Sequential)]
    public struct BaseAITargetChooserData
    {
        public Time IdleScanDelay;
        public Time ReacquireDelay;
        public Time StartupDelay;
        public float SympathyRange;
        public SageBool CheckVisionRange;
        public SageBool CanPickDynamicTargets;
        public SageBool RotateToTargetWhenAiming;
        public SageBool CanAutoAcquireNonAutoAcquirable;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UnitAITargetChooserData
    {
        public BaseAITargetChooserData Base;
        public AssetReference<TargetingCompareList> TargetingCompareList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TurretAITargetChooserData
    {
        public BaseAITargetChooserData Base;
        public AssetReference<TargetingCompareList> TargetingCompareList;
        public SageBool ActiveWhenPerformingSpecialAbility;
        public SageBool CanAcquireDynamicIfAssignedOutOfRange;
        public SageBool CanPickTargetsOutOfTurretAngle;
    }
}
