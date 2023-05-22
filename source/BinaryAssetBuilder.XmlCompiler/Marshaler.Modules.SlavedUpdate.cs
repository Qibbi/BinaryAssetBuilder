using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SlavedUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.LeashRange), "0"), &objT->LeashRange, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.GuardMaxRange), "0"), &objT->GuardMaxRange, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.GuardWanderRange), "0"), &objT->GuardWanderRange, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.AttackRange), "0"), &objT->AttackRange, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.AttackWanderRange), "0"), &objT->AttackWanderRange, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.ScoutRange), "0"), &objT->ScoutRange, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.ScoutWanderRange), "0"), &objT->ScoutWanderRange, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.DistToTargetToGrantRangeBonus), "0"), &objT->DistToTargetToGrantRangeBonus, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.RepairRange), "0"), &objT->RepairRange, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.RepairMinAltitude), "0"), &objT->RepairMinAltitude, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.RepairMaxAltitude), "0"), &objT->RepairMaxAltitude, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.RepairWhenHealthBelowPercentage), "0"), &objT->RepairWhenHealthBelowPercentage, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.RepairRatePerSecond), "0"), &objT->RepairRatePerSecond, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.MinReadyFrames), "0"), &objT->MinReadyFrames, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.MaxReadyFrames), "0"), &objT->MaxReadyFrames, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.MinWeldFrames), "0"), &objT->MinWeldFrames, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.MaxWeldFrames), "0"), &objT->MaxWeldFrames, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.WeldingSysId), null), &objT->WeldingSysId, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.WeldingFXBone), null), &objT->WeldingFXBone, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.StayOnSameLayerAsMaster), "false"), &objT->StayOnSameLayerAsMaster, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.DieOnMastersDeath), "false"), &objT->DieOnMastersDeath, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.DieOnMastersDeathDamageType), nameof(DamageType.UNRESISTABLE)), &objT->DieOnMastersDeathDamageType, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.DieOnMastersDeathType), nameof(DeathType.NORMAL)), &objT->DieOnMastersDeathType, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.FadeOutRange), "0"), &objT->FadeOutRange, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.FadeTime), "0"), &objT->FadeTime, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.MarkUnselectable), "false"), &objT->MarkUnselectable, state);
        Marshal(node.GetAttributeValue(nameof(SlavedUpdateModuleData.UseSlaverAsControlForEvaObjectSightedEvents), "false"), &objT->UseSlaverAsControlForEvaObjectSightedEvents, state);
        Marshal(node.GetChildNode(nameof(SlavedUpdateModuleData.GuardPosOffset), null), &objT->GuardPosOffset, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
