using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ProjectedBuildabilityInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ProjectedBuildabilityInfo.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(ProjectedBuildabilityInfo.BuildPlacementTypes), "INVALID"), &objT->BuildPlacementTypes, state);
        Marshal(node.GetAttributeValue(nameof(ProjectedBuildabilityInfo.StatusToReject), null), &objT->StatusToReject, state);
        Marshal(node.GetAttributeValue(nameof(ProjectedBuildabilityInfo.ModelConditionsToReject), null), &objT->ModelConditionsToReject, state);
    }

    public static unsafe void Marshal(Node node, ArmorTemplateSet* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ArmorTemplateSet.Armor), null), &objT->Armor, state);
        Marshal(node.GetAttributeValue(nameof(ArmorTemplateSet.DamageFX), null), &objT->DamageFX, state);
        Marshal(node.GetAttributeValue(nameof(ArmorTemplateSet.Conditions), null), &objT->Conditions, state);
    }

    public static unsafe void Marshal(Node node, LocomotorSet* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LocomotorSet.Speed), null), &objT->Speed, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorSet.Condition), null), &objT->Condition, state);
        Marshal(node.GetAttributeValue(nameof(LocomotorSet.Locomotor), null), &objT->Locomotor, state);
    }

    public static unsafe void Marshal(Node node, Flammability* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Flammability.Fuel), "0"), &objT->Fuel, state);
        Marshal(node.GetAttributeValue(nameof(Flammability.MaxBurnRate), "0"), &objT->MaxBurnRate, state);
        Marshal(node.GetAttributeValue(nameof(Flammability.Decay), "0"), &objT->Decay, state);
        Marshal(node.GetAttributeValue(nameof(Flammability.Resistance), "0"), &objT->Resistance, state);
    }

    public static unsafe void Marshal(Node node, SkirmishAIInformation* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SkirmishAIInformation.BaseBuildingLocation), "FRONT"), &objT->BaseBuildingLocation, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishAIInformation.UnitBuilderStandardCombatUnit), "false"), &objT->UnitBuilderStandardCombatUnit, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishAIInformation.ConquerMetricsOverrideDPS), null), &objT->ConquerMetricsOverrideDPS, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishAIInformation.ConquerMetricsOverrideDamageType), "UNDEFINED"), &objT->ConquerMetricsOverrideDamageType, state);
        Marshal(node.GetAttributeValue(nameof(SkirmishAIInformation.ConquerMetricsOverrideAntiMask), "ANTI_GROUND"), &objT->ConquerMetricsOverrideAntiMask, state);
    }

    public static unsafe void Marshal(Node node, PerUnitFX* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    public static unsafe void Marshal(Node node, ReplaceModule* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    public static unsafe void Marshal(Node node, InheritableModule* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    public static unsafe void Marshal(Node node, AutoResolveArmor* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AutoResolveArmor.Armor), null), &objT->Armor, state);
        Marshal(node.GetChildNodes(nameof(AutoResolveArmor.RequiredUpgrade)), &objT->RequiredUpgrade, state);
        Marshal(node.GetChildNodes(nameof(AutoResolveArmor.ExcludedUpgrade)), &objT->ExcludedUpgrade, state);
    }

    public static unsafe void Marshal(Node node, AutoResolveWeapon* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AutoResolveWeapon.Weapon), null), &objT->Weapon, state);
        Marshal(node.GetChildNodes(nameof(AutoResolveWeapon.RequiredUpgrade)), &objT->RequiredUpgrade, state);
        Marshal(node.GetChildNodes(nameof(AutoResolveWeapon.ExcludedUpgrade)), &objT->ExcludedUpgrade, state);
    }

    public static unsafe void Marshal(Node node, FormationPreviewDecal* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FormationPreviewDecal.Texture), null), &objT->Texture, state);
        Marshal(node.GetAttributeValue(nameof(FormationPreviewDecal.Width), "50.0"), &objT->Width, state);
        Marshal(node.GetAttributeValue(nameof(FormationPreviewDecal.Height), "50.0"), &objT->Height, state);
    }

    public static unsafe void Marshal(Node node, VisionInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(VisionInfo.VisionRange), "0.00"), &objT->VisionRange, state);
        Marshal(node.GetAttributeValue(nameof(VisionInfo.ShroudClearingRange), "0.0"), &objT->ShroudClearingRange, state);
        Marshal(node.GetAttributeValue(nameof(VisionInfo.VisionSide), "100"), &objT->VisionSide, state);
        Marshal(node.GetAttributeValue(nameof(VisionInfo.VisionRear), "100"), &objT->VisionRear, state);
        Marshal(node.GetAttributeValue(nameof(VisionInfo.VisionBonusTestRadius), "100"), &objT->VisionBonusTestRadius, state);
        Marshal(node.GetAttributeValue(nameof(VisionInfo.VisionBonusTestSegments), "8"), &objT->VisionBonusTestSegments, state);
        Marshal(node.GetAttributeValue(nameof(VisionInfo.VisionBonusPercentPerFoot), "0"), &objT->VisionBonusPercentPerFoot, state);
        Marshal(node.GetAttributeValue(nameof(VisionInfo.MaxVisionBonusPercent), "50"), &objT->MaxVisionBonusPercent, state);
        Marshal(node.GetAttributeValue(nameof(VisionInfo.MinVisionBonusPercent), "-50"), &objT->MinVisionBonusPercent, state);
    }

    public static unsafe void Marshal(Node node, CrusherInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrusherLevel), "0"), &objT->CrusherLevel, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrushableLevel), "127"), &objT->CrushableLevel, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.MountedCrusherLevel), "-1"), &objT->MountedCrusherLevel, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.MountedCrushableLevel), "-1"), &objT->MountedCrushableLevel, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrushKnockback), "0"), &objT->CrushKnockback, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrushZFactor), "1"), &objT->CrushZFactor, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrushEqualLevelProps), "false"), &objT->CrushEqualLevelProps, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.UseCrushAttack), "true"), &objT->UseCrushAttack, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrushOnlyWhileCharging), "false"), &objT->CrushOnlyWhileCharging, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.MinCrushVelocityPercent), "1"), &objT->MinCrushVelocityPercent, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrushDecelerationPercent), "0"), &objT->CrushDecelerationPercent, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrushAllies), "false"), &objT->CrushAllies, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrushWeapon), null), &objT->CrushWeapon, state);
        Marshal(node.GetAttributeValue(nameof(CrusherInfo.CrushRevengeWeapon), null), &objT->CrushRevengeWeapon, state);
    }
}
