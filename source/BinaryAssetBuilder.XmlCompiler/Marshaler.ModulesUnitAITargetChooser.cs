using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TargetingBaseCompare* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, TargetingDistanceCompare* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TargetingDistanceCompare.Tolerance), "30.0"), &objT->Tolerance, state);
        Marshal(node, (TargetingBaseCompare*)objT, state);
    }

    public static unsafe void Marshal(Node node, TargetingCombatChainCompare* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (TargetingBaseCompare*)objT, state);
    }

    public static unsafe void Marshal(Node node, TargetingInTurretArcCompare* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (TargetingBaseCompare*)objT, state);
    }

    public static unsafe void Marshal(Node node, TargetingCompareList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(TargetingCompareList.Compare)), &objT->Compare, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, BaseAITargetChooserData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BaseAITargetChooserData.IdleScanDelay), "0.8s"), &objT->IdleScanDelay, state);
        Marshal(node.GetAttributeValue(nameof(BaseAITargetChooserData.ReacquireDelay), "5s"), &objT->ReacquireDelay, state);
        Marshal(node.GetAttributeValue(nameof(BaseAITargetChooserData.StartupDelay), "0s"), &objT->StartupDelay, state);
        Marshal(node.GetAttributeValue(nameof(BaseAITargetChooserData.SympathyRange), "25.0"), &objT->SympathyRange, state);
        Marshal(node.GetAttributeValue(nameof(BaseAITargetChooserData.CheckVisionRange), "false"), &objT->CheckVisionRange, state);
        Marshal(node.GetAttributeValue(nameof(BaseAITargetChooserData.CanPickDynamicTargets), "true"), &objT->CanPickDynamicTargets, state);
        Marshal(node.GetAttributeValue(nameof(BaseAITargetChooserData.RotateToTargetWhenAiming), "true"), &objT->RotateToTargetWhenAiming, state);
        Marshal(node.GetAttributeValue(nameof(BaseAITargetChooserData.CanAutoAcquireNonAutoAcquirable), "false"), &objT->CanAutoAcquireNonAutoAcquirable, state);
    }

    public static unsafe void Marshal(Node node, UnitAITargetChooserData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UnitAITargetChooserData.TargetingCompareList), "DefaultTargetingCompareList"), &objT->TargetingCompareList, state);
        Marshal(node, (BaseAITargetChooserData*)objT, state);
    }

    public static unsafe void Marshal(Node node, UnitAITargetChooserData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(UnitAITargetChooserData), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, TurretAITargetChooserData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TurretAITargetChooserData.TargetingCompareList), "DefaultTurretTargetingCompareList"), &objT->TargetingCompareList, state);
        Marshal(node.GetAttributeValue(nameof(TurretAITargetChooserData.ActiveWhenPerformingSpecialAbility), "false"), &objT->ActiveWhenPerformingSpecialAbility, state);
        Marshal(node.GetAttributeValue(nameof(TurretAITargetChooserData.CanAcquireDynamicIfAssignedOutOfRange), "false"), &objT->CanAcquireDynamicIfAssignedOutOfRange, state);
        Marshal(node.GetAttributeValue(nameof(TurretAITargetChooserData.CanPickTargetsOutOfTurretAngle), "false"), &objT->CanPickTargetsOutOfTurretAngle, state);
        Marshal(node, (BaseAITargetChooserData*)objT, state);
    }

    public static unsafe void Marshal(Node node, TurretAITargetChooserData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(TurretAITargetChooserData), 1u);
        Marshal(node, *objT, state);
    }
}