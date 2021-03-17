using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HordeMeleeBehaviorData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HordeMeleeBehaviorData.Type), null), &objT->Type, state);
    }

    public static unsafe void Marshal(Node node, HordeMeleeBehaviorData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(HordeMeleeBehaviorData), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, PositionAndLeaderType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PositionAndLeaderType.X), "0"), &objT->X, state);
        Marshal(node.GetAttributeValue(nameof(PositionAndLeaderType.Y), "0"), &objT->Y, state);
        Marshal(node.GetAttributeValue(nameof(PositionAndLeaderType.LeaderRank), "-1"), &objT->LeaderRank, state);
        Marshal(node.GetAttributeValue(nameof(PositionAndLeaderType.LeaderIndex), "0"), &objT->LeaderIndex, state);
    }

    public static unsafe void Marshal(Node node, RankInfoType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RankInfoType.RankID), "0"), &objT->RankID, state);
        Marshal(node.GetAttributeValue(nameof(RankInfoType.UnitType), null), &objT->UnitType, state);
        Marshal(node.GetChildNodes(nameof(RankInfoType.Position)), &objT->Position, state);
        Marshal(node.GetChildNode(nameof(RankInfoType.WeaponConditionSet), null), &objT->WeaponConditionSet, state);
        Marshal(node.GetChildNode(nameof(RankInfoType.WeaponConditionClear), null), &objT->WeaponConditionClear, state);
    }

    public static unsafe void Marshal(Node node, BannerCarrierPosType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(BannerCarrierPosType.UnitType), null), &objT->UnitType, state);
        Marshal(node.GetChildNode(nameof(BannerCarrierPosType.Pos), null), &objT->Pos, state);
    }

    public static unsafe void Marshal(Node node, HordeContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.Formation), null), &objT->Formation, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.AlternateFormation), null), &objT->AlternateFormation, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.ForcedLocomotorSet), null), &objT->ForcedLocomotorSet, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.UseSlowHordeMovement), "true"), &objT->UseSlowHordeMovement, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.MeleeAttackLeashDistance), "60.0"), &objT->MeleeAttackLeashDistance, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.GeometryFrontAngleRadians), "0.0"), &objT->GeometryFrontAngleRadians, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.EvaEventLastMemberDeath), null), &objT->EvaEventLastMemberDeath, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.FrontAngle), "6.283"), &objT->FrontAngle, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.FlankedDelaySeconds), "0"), &objT->FlankedDelaySeconds, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.FlankedDurationSeconds), "5.0"), &objT->FlankedDurationSeconds, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.MinimumHordeSize), "0"), &objT->MinimumHordeSize, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.BackupMinDelayTime), "0s"), &objT->BackupMinDelayTime, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.BackupMaxDelayTime), "0s"), &objT->BackupMaxDelayTime, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.BackupMinDistance), "0"), &objT->BackupMinDistance, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.BackupMaxDistance), "0"), &objT->BackupMaxDistance, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.BackupPercentage), "0"), &objT->BackupPercentage, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.RadiusCowerOverride), "0"), &objT->RadiusCowerOverride, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.VisionOverrideRear), "0.0"), &objT->VisionOverrideRear, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.VisionOverrideSide), "0.0"), &objT->VisionOverrideSide, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.SpawnBannerCarrierImmediately), "false"), &objT->SpawnBannerCarrierImmediately, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.BannerCarrierByUpgradeOnly), "false"), &objT->BannerCarrierByUpgradeOnly, state);
        Marshal(node.GetAttributeValue(nameof(HordeContainModuleData.ForbiddenCoverStatus), null), &objT->ForbiddenCoverStatus, state);
        Marshal(node.GetChildNode(nameof(HordeContainModuleData.MeleeBehavior), null), &objT->MeleeBehavior, state);
        Marshal(node.GetChildNode(nameof(HordeContainModuleData.RandomOffset), null), &objT->RandomOffset, state);
        Marshal(node.GetChildNodes(nameof(HordeContainModuleData.RankInfo)), &objT->RankInfo, state);
        Marshal(node.GetChildNodes(nameof(HordeContainModuleData.RankThatStopsAdvance)), &objT->RankThatStopsAdvance, state);
        Marshal(node.GetChildNodes(nameof(HordeContainModuleData.RankToReleaseWhenAttacking)), &objT->RankToReleaseWhenAttacking, state);
        Marshal(node.GetChildNode(nameof(HordeContainModuleData.LeaderPosition), null), &objT->LeaderPosition, state);
        Marshal(node.GetChildNodes(nameof(HordeContainModuleData.BannerCarrierPosition)), &objT->BannerCarrierPosition, state);
        Marshal(node.GetChildNodes(nameof(HordeContainModuleData.BannerCarriersAllowed)), &objT->BannerCarriersAllowed, state);
        Marshal(node.GetChildNodes(nameof(HordeContainModuleData.LeadersAllowed)), &objT->LeadersAllowed, state);
        Marshal(node.GetChildNodes(nameof(HordeContainModuleData.AttributeModifier)), &objT->AttributeModifier, state);
        Marshal(node, (TransportContainModuleData*)objT, state);
    }
}
