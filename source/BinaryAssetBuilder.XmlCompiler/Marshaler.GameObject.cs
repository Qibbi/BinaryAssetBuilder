using BinaryAssetBuilder.Core.Diagnostics;
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BehaviorModuleData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0u;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x2B847E06u:
                MarshalPolymorphicType<AISpecialPowerUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x74A24C45u:
                MarshalPolymorphicType<AttributeModifierUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x239D954Fu:
                MarshalPolymorphicType<AttackTargetSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA1FE37ACu:
                MarshalPolymorphicType<ArmorUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC939197Bu:
                MarshalPolymorphicType<BeamTargetModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC8E1225Fu:
                MarshalPolymorphicType<SlavedUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0BBF2A39u:
                MarshalPolymorphicType<BezierProjectileBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x815A9161u:
                MarshalPolymorphicType<BuildingBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x8FFB4C58u:
                MarshalPolymorphicType<CastleUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE48609FBu:
                MarshalPolymorphicType<ClusterBombUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x70E5C103u:
                MarshalPolymorphicType<CollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x7EB7F219u:
                MarshalPolymorphicType<CommandSetUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x3B68B768u:
                MarshalPolymorphicType<CreateObjectDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x91ED30DCu:
                MarshalPolymorphicType<CrushDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD25E223Au:
                MarshalPolymorphicType<RebuildHoleExposeDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2F46AEF0u:
                MarshalPolymorphicType<RebuildHoleBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x6A65E73Du:
                MarshalPolymorphicType<DefaultProductionExitUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0F7EC801u:
                MarshalPolymorphicType<DestroyDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x03E414F0u:
                MarshalPolymorphicType<DynamicShroudClearingRangeUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA966196Eu:
                MarshalPolymorphicType<EmotionTrackerUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0FF760E0u:
                MarshalPolymorphicType<EngineerContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x5047272Eu:
                MarshalPolymorphicType<InfiltratorContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x5717D9DCu:
                MarshalPolymorphicType<InvalidTargetsDeathUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xAE4A97B0u:
                MarshalPolymorphicType<FireWeaponCollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB28C3D52u:
                MarshalPolymorphicType<FireWeaponUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF5D17C70u:
                MarshalPolymorphicType<StructureToppleUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x06DE2D62u:
                MarshalPolymorphicType<ToppleUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x97482233u:
                MarshalPolymorphicType<OilSpillUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF3B802D5u:
                MarshalPolymorphicType<DamageFieldUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x6BE00745u:
                MarshalPolymorphicType<FlammableUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4D834921u:
                MarshalPolymorphicType<AutoDepositUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB07119E4u:
                MarshalPolymorphicType<FXListBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xFF84FBDEu:
                MarshalPolymorphicType<GeometryUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF3967C53u:
                MarshalPolymorphicType<GettingBuiltBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2DE34173u:
                MarshalPolymorphicType<GiveUpgradeUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x04B8C430u:
                MarshalPolymorphicType<GrantUpgradeCreateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x7517FE52u:
                MarshalPolymorphicType<HeightDieUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x91840787u:
                MarshalPolymorphicType<MissileUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE7CF961Cu:
                MarshalPolymorphicType<JumpJetSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x977D25A1u:
                MarshalPolymorphicType<LevelUpUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x6C283C72u:
                MarshalPolymorphicType<LifetimeUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
#if KANESWRATH
            case 0x4899B6CDu:
                MarshalPolymorphicType<MetaGameLifetimeUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
#endif
            case 0x2799DFF2u:
                MarshalPolymorphicType<LocomotorSetModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x14E031A2u:
                MarshalPolymorphicType<SwitchLocomotorsSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x7C9A2737u:
                MarshalPolymorphicType<MaxHealthUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB53A18ADu:
                MarshalPolymorphicType<MinefieldBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC7248613u:
                MarshalPolymorphicType<ModelConditionSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4DDD5C7Fu:
                MarshalPolymorphicType<ModelConditionUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xDDD81EE9u:
                MarshalPolymorphicType<RandomModelConditionBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x09BE107Cu:
                MarshalPolymorphicType<StrafeAreaUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF145A667u:
                MarshalPolymorphicType<OCLMonitorUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4E463B86u:
                MarshalPolymorphicType<TeleportSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x93833563u:
                MarshalPolymorphicType<TeleportToCasterSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x69E2CD6Cu:
                MarshalPolymorphicType<ObjectCreationUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x8999C6A4u:
                MarshalPolymorphicType<OCLSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
#if KANESWRATH
            case 0xA9778E00u:
                MarshalPolymorphicType<SpawnHordeMemberSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
#endif
            case 0xC662DEB4u:
                MarshalPolymorphicType<TemporaryOwnerSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
#if KANESWRATH
            case 0x9B27DE30u: // actually present in TW, with minor change to KW, enable?
                MarshalPolymorphicType<DominateEnemySpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4D76910Cu: // actually present in TW, enable?
                MarshalPolymorphicType<TemporarilyDefectUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
#endif
            case 0xB8B58445u:
                MarshalPolymorphicType<OCLUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD7CC2E35u:
                MarshalPolymorphicType<OpenContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE491340Bu:
                MarshalPolymorphicType<HealContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x79BFEDCBu:
                MarshalPolymorphicType<PhysicsBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x784EC9B8u:
                MarshalPolymorphicType<CombinedInfoModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA112A404u:
                MarshalPolymorphicType<CompositeStructureInfoModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x005B408Eu:
                MarshalPolymorphicType<PlayerUpgradeSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x6EC75439u:
                MarshalPolymorphicType<ProductionUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;

            default:
                Tracer.GetTracer("Marshaler", "Marshalling").TraceWarning("Marshalling unknown type {0} from {1}.", typeId, nameof(PolymorphicList<BehaviorModuleData>));
                MarshalUnknownPolymorphicType(node, objT, state);
                break;
        }
    }

    private static unsafe void Marshal(Node node, AutoResolveInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AutoResolveInfo.AutoResolveUnitType), null), &objT->AutoResolveUnitType, state);
        Marshal(node.GetAttributeValue(nameof(AutoResolveInfo.AutoResolveBody), null), &objT->AutoResolveBody, state);
        Marshal(node.GetAttributeValue(nameof(AutoResolveInfo.AutoResolveArmor), null), &objT->AutoResolveArmor, state);
        Marshal(node.GetAttributeValue(nameof(AutoResolveInfo.AutoResolveWeapon), null), &objT->AutoResolveWeapon, state);
        Marshal(node.GetAttributeValue(nameof(AutoResolveInfo.AutoResolveLeadership), null), &objT->AutoResolveLeadership, state);
        Marshal(node.GetAttributeValue(nameof(AutoResolveInfo.AutoResolveCombatChain), null), &objT->AutoResolveCombatChain, state);
    }

    private static unsafe void Marshal(Node node, AutoResolveInfo** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AutoResolveInfo), 1u);
        Marshal(node, *objT, state);
    }

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

    private static unsafe void Marshal(Node node, ProjectedBuildabilityInfo** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ProjectedBuildabilityInfo), 1u);
        Marshal(node, *objT, state);
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

    private static unsafe void Marshal(Node node, Flammability** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(Flammability), 1u);
        Marshal(node, *objT, state);
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

    private static unsafe void Marshal(Node node, SkirmishAIInformation** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(SkirmishAIInformation), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, PerUnitFX* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    private static unsafe void Marshal(Node node, PerUnitFX** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(PerUnitFX), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, ReplaceModule* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    private static unsafe void Marshal(Node node, ReplaceModule** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(ReplaceModule), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, InheritableModule* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    private static unsafe void Marshal(Node node, InheritableModule** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(InheritableModule), 1u);
        Marshal(node, *objT, state);
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

    private static unsafe void Marshal(Node node, AutoResolveArmor** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AutoResolveArmor), 1u);
        Marshal(node, *objT, state);
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

    private static unsafe void Marshal(Node node, AutoResolveWeapon** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AutoResolveWeapon), 1u);
        Marshal(node, *objT, state);
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

    private static unsafe void Marshal(Node node, FormationPreviewDecal** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(FormationPreviewDecal), 1u);
        Marshal(node, *objT, state);
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

    private static unsafe void Marshal(Node node, VisionInfo** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(VisionInfo), 1u);
        Marshal(node, *objT, state);
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

    private static unsafe void Marshal(Node node, CrusherInfo** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(CrusherInfo), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, GameObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GameObject.KindOf), null), &objT->KindOf, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.Browser), null), &objT->Browser, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ReviveText), null), &objT->ReviveText, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.RecruitText), null), &objT->RecruitText, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.Description), null), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.TypeDescription), null), &objT->TypeDescription, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.Hotkey), null), &objT->Hotkey, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.RadarPriority), null), &objT->RadarPriority, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.BuildCompletion), null), &objT->BuildCompletion, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.TransportSlotCount), "0"), &objT->TransportSlotCount, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.FenceWidth), "0"), &objT->FenceWidth, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.FenceXOffset), "0"), &objT->FenceXOffset, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.RemoveTerrainRadius), "0.0"), &objT->RemoveTerrainRadius, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.EmotionRange), "0"), &objT->EmotionRange, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.PlacementViewAngle), "0r"), &objT->PlacementViewAngle, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.BuildFadeInOnCreateTimeSeconds), "0s"), &objT->BuildFadeInOnCreateTimeSeconds, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.FactoryExitWidth), null), &objT->FactoryExitWidth, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.FactoryExtraBibWidth), null), &objT->FactoryExtraBibWidth, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.IsTrainable), "true"), &objT->IsTrainable, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.Side), null), &objT->Side, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.EditorName), null), &objT->EditorName, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.EditorSorting), "NONE"), &objT->EditorSorting, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.BuildCost), "0"), &objT->BuildCost, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.BountyValue), "0"), &objT->BountyValue, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.BuildTime), "0.0"), &objT->BuildTime, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.BuildFadeInOnCreateTime), "0"), &objT->BuildFadeInOnCreateTime, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.RefundValue), "0"), &objT->RefundValue, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.EnergyProduction), "0"), &objT->EnergyProduction, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.EnergyBonus), "0"), &objT->EnergyBonus, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.IsForbidden), "false"), &objT->IsForbidden, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.IsPrerequisite), "false"), &objT->IsPrerequisite, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.IsGrabbable), "false"), &objT->IsGrabbable, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.IsHarvestable), "false"), &objT->IsHarvestable, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.CommandSet), ""), &objT->CommandSet, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.SelectPortrait), ""), &objT->SelectPortrait, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ButtonImage), ""), &objT->ButtonImage, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.VoicePriority), null), &objT->VoicePriority, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.MinZIncreaseForVoiceMoveToHigherGround), "-1"), &objT->MinZIncreaseForVoiceMoveToHigherGround, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.CrowdResponse), null), &objT->CrowdResponse, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.CampnessValue), "0"), &objT->CampnessValue, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.CampnessValueRadius), "600.0"), &objT->CampnessValueRadius, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.Scale), "1.0"), &objT->Scale, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.HealthBoxScale), "1.5"), &objT->HealthBoxScale, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.HealthBoxHeightOffset), "10.0"), &objT->HealthBoxHeightOffset, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.OcclusionDelay), null), &objT->OcclusionDelay, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.LiveCameraPitch), "0"), &objT->LiveCameraPitch, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.FormationWidth), "1"), &objT->FormationWidth, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.FormationDepth), "1"), &objT->FormationDepth, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.InstanceScaleFuzziness), null), &objT->InstanceScaleFuzziness, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.StructureRubbleHeight), "0"), &objT->StructureRubbleHeight, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ThreatValue), "0"), &objT->ThreatValue, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ThreatRadius), "-1"), &objT->ThreatRadius, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.MaxSimultaneousOfType), null), &objT->MaxSimultaneousOfType, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.RamPower), "0"), &objT->RamPower, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.RamZMult), "1.0"), &objT->RamZMult, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ShockwaveResistance), "0"), &objT->ShockwaveResistance, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.CommandPoints), "0"), &objT->CommandPoints, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.CommandPointBonus), "0"), &objT->CommandPointBonus, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.VoiceAttackChargeTimeout), null), &objT->VoiceAttackChargeTimeout, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.MaxDistanceForEngaged), null), &objT->MaxDistanceForEngaged, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.EngagedStateTimeout), null), &objT->EngagedStateTimeout, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ThreatLevel), "1.0"), &objT->ThreatLevel, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ForceLuaRegistration), "false"), &objT->ForceLuaRegistration, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ShowHealthInSelectionDecal), "false"), &objT->ShowHealthInSelectionDecal, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.KeepSelectableWhenDead), "false"), &objT->KeepSelectableWhenDead, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.IsAutoBuilt), "false"), &objT->IsAutoBuilt, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.CanPathThroughGates), "true"), &objT->CanPathThroughGates, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ShouldClearShotsOnIdle), "false"), &objT->ShouldClearShotsOnIdle, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.SlopeLimitIndex), "0"), &objT->SlopeLimitIndex, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.PathfindDiameter), "-1"), &objT->PathfindDiameter, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.SupplyOverride), "0"), &objT->SupplyOverride, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.DisplayMeleeDamage), "-1"), &objT->DisplayMeleeDamage, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.DisplayRangedDamage), "-1"), &objT->DisplayRangedDamage, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.HeroSortOrder), "2147483647"), &objT->HeroSortOrder, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ExperienceScalarTable), null), &objT->ExperienceScalarTable, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.FiringArc), "360"), &objT->FiringArc, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.CamouflageDetectionMultiplier), "1"), &objT->CamouflageDetectionMultiplier, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.SelectionPriority), "2147483647"), &objT->SelectionPriority, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ProductionQueueType), "INVALID"), &objT->ProductionQueueType, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.BuildPlacementTypeFlag), "INVALID"), &objT->BuildPlacementTypeFlag, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.BuildInProximityToSamePlayerStucture), "true"), &objT->BuildInProximityToSamePlayerStucture, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.BuildOnRequiredObjectKindOf), null), &objT->BuildOnRequiredObjectKindOf, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.UnitCategory), "NONE"), &objT->UnitCategory, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.WeaponCategory), "NONE"), &objT->WeaponCategory, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.HasFiredRecentlyTime), "2s"), &objT->HasFiredRecentlyTime, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.UnitTypeIcon), null), &objT->UnitTypeIcon, state);
        Marshal(node.GetAttributeValue(nameof(GameObject.ReinvisibilityDelay), "4s"), &objT->ReinvisibilityDelay, state);
        Marshal(node.GetChildNode(nameof(GameObject.DisplayName), null), &objT->DisplayName, state);
        Marshal(node.GetChildNode(nameof(GameObject.GameDependency), null), &objT->GameDependency, state);
        Marshal(node.GetChildNodes(nameof(GameObject.ArmorSet)), &objT->ArmorSet, state);
        Marshal(node.GetChildNodes(nameof(GameObject.WeaponSet)), &objT->WeaponSet, state);
        Marshal(node.GetChildNodes(nameof(GameObject.LocomotorSet)), &objT->LocomotorSet, state);
        Marshal(node.GetChildNode(nameof(GameObject.Buildable), null), &objT->Buildable, state);
        Marshal(node.GetChildNode(nameof(GameObject.ThingClass), null), &objT->ThingClass, state);
        Marshal(node.GetChildNode(nameof(GameObject.DeadCollideSize), null), &objT->DeadCollideSize, state);
        Marshal(node.GetChildNode(nameof(GameObject.BuildFadeInOnCreateList), null), &objT->BuildFadeInOnCreateList, state);
        Marshal(node.GetChildNode(nameof(GameObject.BuildVariations), null), &objT->BuildVariations, state);
        Marshal(node.GetChildNodes(nameof(GameObject.EquivalentTo)), &objT->EquivalentTo, state);
        Marshal(node.GetChildNode(nameof(GameObject.DisplayColor), null), &objT->DisplayColor, state);
        Marshal(node.GetChildNode(nameof(GameObject.Flammability), null), &objT->Flammability, state);
        Marshal(node.GetChildNode(nameof(GameObject.SkirmishAIInformation), null), &objT->SkirmishAIInformation, state);
        Marshal(node.GetChildNode(nameof(GameObject.Draws), null), &objT->Draws, state);
        Marshal(node.GetChildNode(nameof(GameObject.Behaviors), null), &objT->Behaviors, state);
        MarshalSinglePolymorphic(node.GetChildNode(nameof(GameObject.AI), null), &objT->AI, state);
        MarshalSinglePolymorphic(node.GetChildNode(nameof(GameObject.Body), null), &objT->Body, state);
        Marshal(node.GetChildNode(nameof(GameObject.ClientUpdates), null), &objT->ClientUpdates, state);
        Marshal(node.GetChildNode(nameof(GameObject.ClientBehaviors), null), &objT->ClientBehaviors, state);
        Marshal(node.GetChildNode(nameof(GameObject.UnitSpecificFX), null), &objT->UnitSpecificFX, state);
        Marshal(node.GetChildNode(nameof(GameObject.Geometry), null), &objT->Geometry, state);
        Marshal(node.GetChildNode(nameof(GameObject.ReplaceModule), null), &objT->ReplaceModule, state);
        Marshal(node.GetChildNode(nameof(GameObject.InheritableModule), null), &objT->InheritableModule, state);
        Marshal(node.GetChildNode(nameof(GameObject.AutoResolveArmor), null), &objT->AutoResolveArmor, state);
        Marshal(node.GetChildNode(nameof(GameObject.AutoResolveWeapon), null), &objT->AutoResolveWeapon, state);
        Marshal(node.GetChildNode(nameof(GameObject.WorldMapArmoryUpgradesAllowed), null), &objT->WorldMapArmoryUpgradesAllowed, state);
        Marshal(node.GetChildNode(nameof(GameObject.FormationPreviewDecal), null), &objT->FormationPreviewDecal, state);
        Marshal(node.GetChildNode(nameof(GameObject.FormationPreviewItemDecal), null), &objT->FormationPreviewItemDecal, state);
        Marshal(node.GetChildNode(nameof(GameObject.LiveCameraOffset), null), &objT->LiveCameraOffset, state);
        Marshal(node.GetChildNode(nameof(GameObject.AudioArrayVoice), null), &objT->AudioArrayVoice, state);
        Marshal(node.GetChildNode(nameof(GameObject.AudioArraySound), null), &objT->AudioArraySound, state);
        Marshal(node.GetChildNode(nameof(GameObject.EvaEvents), null), &objT->EvaEvents, state);
        Marshal(node.GetChildNodes(nameof(GameObject.UpgradeCameo)), &objT->UpgradeCameo, state);
        Marshal(node.GetChildNode(nameof(GameObject.ShadowInfo), null), &objT->ShadowInfo, state);
        Marshal(node.GetChildNode(nameof(GameObject.AutoResolveInfo), null), &objT->AutoResolveInfo, state);
        Marshal(node.GetChildNode(nameof(GameObject.VisionInfo), null), &objT->VisionInfo, state);
        Marshal(node.GetChildNode(nameof(GameObject.CrusherInfo), null), &objT->CrusherInfo, state);
        Marshal(node.GetChildNode(nameof(GameObject.ProjectedBuildabilityInfo), null), &objT->ProjectedBuildabilityInfo, state);
        Marshal(node.GetChildNodes(nameof(GameObject.DisplayUpgrade)), &objT->DisplayUpgrade, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
