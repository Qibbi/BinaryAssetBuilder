﻿using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BehaviorModuleData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x25E1EFA5u:
                MarshalPolymorphicType<CreateCrateDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2827372Cu:
                MarshalPolymorphicType<ShareExperienceBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB2483B20u:
                MarshalPolymorphicType<TooltipUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xAA507848u:
                MarshalPolymorphicType<RespawnUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x9E322E47u:
                MarshalPolymorphicType<CashHackSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2E021907u:
                MarshalPolymorphicType<PlayerPowerManagerBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x7C27AD44u:
                MarshalPolymorphicType<DestroyObjectsUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2F4536A8u:
                MarshalPolymorphicType<SetLocomotorSpeedUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB956A21Au:
                MarshalPolymorphicType<GrantUpgradeAreaOfEffectSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x1E5C747Au:
                MarshalPolymorphicType<LinearDamageUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xDFD38381u:
                MarshalPolymorphicType<ShroudClearBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x8DA12662u:
                MarshalPolymorphicType<MonitorSpecialPowerTimerUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0FEC21CBu:
                MarshalPolymorphicType<MonitorConditionUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x47E7EAC9u:
                MarshalPolymorphicType<AreaRestrictSpecialPowerBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x953C7F5Bu:
                MarshalPolymorphicType<RestrictSpecialPowerBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xDA2F4EE5u:
                MarshalPolymorphicType<RadarScanMapSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x39B825FFu:
                MarshalPolymorphicType<RepairSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x146948BCu:
                MarshalPolymorphicType<HighlightReachableTargetsSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xBEB7D7A3u:
                MarshalPolymorphicType<FindCoverBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x384E25E7u:
                MarshalPolymorphicType<BannerCarrierUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x977F8391u:
                MarshalPolymorphicType<StructureUnpackUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF3F8ADFAu:
                MarshalPolymorphicType<WallHubBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE622F055u:
                MarshalPolymorphicType<AttributeModifierPoolUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xBCFB5BB7u:
                MarshalPolymorphicType<SuppressionUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x877ACEADu:
                MarshalPolymorphicType<RunOffMapBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD6791F61u:
                MarshalPolymorphicType<MoveToPositionAndReplaceSelfSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xAC7E2A4Au:
                MarshalPolymorphicType<MoveToPositionAndEvacuateSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x38C496D8u:
                MarshalPolymorphicType<CreateAndEnterObjectSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC3A62C68u:
                MarshalPolymorphicType<PowerUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x08E25591u:
                MarshalPolymorphicType<PassiveAreaEffectBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA2F69397u:
                MarshalPolymorphicType<BridgeBuilderModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4A32BF8Eu:
                MarshalPolymorphicType<SpawnCrateUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x21068FF6u:
                MarshalPolymorphicType<StealUnitUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE502295Eu:
                MarshalPolymorphicType<BoobyTrapUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE9FD14C9u:
                MarshalPolymorphicType<AttachUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0EA26C39u:
                MarshalPolymorphicType<ClearanceTestingSlowDeathBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x006DBEBFu:
                MarshalPolymorphicType<HelicopterSlowDeathBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x55F9E6EDu:
                MarshalPolymorphicType<ReplaceObjectUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x59D12990u:
                MarshalPolymorphicType<HitReactionBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0BA45362u:
                MarshalPolymorphicType<ClickReactionBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x18A4208Fu:
                MarshalPolymorphicType<ObjectDefectionHelperModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x54203FA0u:
                MarshalPolymorphicType<SpecialPowerTimerRefreshSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x98270BD0u:
                MarshalPolymorphicType<FiringTrackerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x311B2FAFu:
                MarshalPolymorphicType<RubbleRiseUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC0A1E43Du:
                MarshalPolymorphicType<StancesBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x264EC61Au:
                MarshalPolymorphicType<GatherSlavesUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x9776876Eu:
                MarshalPolymorphicType<SupplyCenterCreateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF46EB384u:
                MarshalPolymorphicType<PowerUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD2C1CFC2u:
                MarshalPolymorphicType<InvisibilitySpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x35634018u:
                MarshalPolymorphicType<InvisibilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC1947EDCu:
                MarshalPolymorphicType<SlaughterHordeContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x8EC7A787u:
                MarshalPolymorphicType<TunnelTeleportContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB4841EABu:
                MarshalPolymorphicType<TunnelContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x1D7FC977u:
                MarshalPolymorphicType<HordeGarrisonContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x07FEA222u:
                MarshalPolymorphicType<ReturnToDockSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x28004AB1u:
                MarshalPolymorphicType<ReturnToProducerSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4E2D96C9u:
                MarshalPolymorphicType<RecallUnitsSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xCDEF277Du:
                MarshalPolymorphicType<CloneStoredObjectsSpecialPowerUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA74A234Cu:
                MarshalPolymorphicType<StoreObjectsSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2EB6C99Cu:
                MarshalPolymorphicType<StorePurchasedUpgradeBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF8C4AA6Bu:
                MarshalPolymorphicType<CaptureBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x5E58E0AEu:
                MarshalPolymorphicType<DualWeaponBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA63DC46Bu:
                MarshalPolymorphicType<ActivateModuleSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xFEF85F95u:
                MarshalPolymorphicType<StreamStateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x3C934753u:
                MarshalPolymorphicType<SweepingLaserStateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE7B6AF0Du:
                MarshalPolymorphicType<LaserStateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xCA9ED83Du:
                MarshalPolymorphicType<LaserUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF8079C05u:
                MarshalPolymorphicType<DamageStateListModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xCB909BFEu:
                MarshalPolymorphicType<DestroyModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2A79518Fu:
                MarshalPolymorphicType<DamagerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x025C0BD7u:
                MarshalPolymorphicType<DamageModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x29234E6Eu:
                MarshalPolymorphicType<InactiveBodyModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB5EB41EDu:
                MarshalPolymorphicType<SquishCollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x93A6B8C0u:
                MarshalPolymorphicType<StealthUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xCDC0EFF7u:
                MarshalPolymorphicType<CostModifierUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x90F05519u:
                MarshalPolymorphicType<LevelGrantSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE06AB787u:
                MarshalPolymorphicType<ExperienceScalarUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE9BBF43Bu:
                MarshalPolymorphicType<ParkingPlaceBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xFBF6592Du:
                MarshalPolymorphicType<AutoHealBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD014A1C2u:
                MarshalPolymorphicType<KeepObjectDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x510D79C7u:
                MarshalPolymorphicType<UpgradeDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x696245D9u:
                MarshalPolymorphicType<RadarUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x786C9458u:
                MarshalPolymorphicType<StatusBitsUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x884BDE51u:
                MarshalPolymorphicType<ProductionSpeedBonusUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x5A7BCED3u:
                MarshalPolymorphicType<DelayedUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD3302D7Eu:
                MarshalPolymorphicType<EMPUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x42409853u:
                MarshalPolymorphicType<DeletionUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC001089Bu:
                MarshalPolymorphicType<InheritUpgradeCreateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC2EBB54Du:
                MarshalPolymorphicType<ExperienceLevelCreateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xBAE3BC7Du:
                MarshalPolymorphicType<GarrisonContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x90CEB49Cu:
                MarshalPolymorphicType<FireWeaponWhenDeadBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0897B555u:
                MarshalPolymorphicType<FireWeaponWhenDamagedBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4CA37F3Eu:
                MarshalPolymorphicType<AutoAbilityBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x3CFBDE26u:
                MarshalPolymorphicType<DistributedMoneyBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE42D5618u:
                MarshalPolymorphicType<AimWeaponBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD6297BD1u:
                MarshalPolymorphicType<SupplyWarehouseDockUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC2F1EC20u:
                MarshalPolymorphicType<SupplyCenterDockUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0A2B8743u:
                MarshalPolymorphicType<RepairUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD9A4DA61u:
                MarshalPolymorphicType<DockUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2E546F8Eu:
                MarshalPolymorphicType<RadarBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xAE3A906Cu:
                MarshalPolymorphicType<TiberiumGrowthModBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0F2D5192u:
                MarshalPolymorphicType<TiberiumCrystalBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x6BC9FD0Eu:
                MarshalPolymorphicType<TiberiumFieldBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF4568855u:
                MarshalPolymorphicType<TiberiumThiefSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x1E45A393u:
                MarshalPolymorphicType<WeaponFireSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x313998B5u:
                MarshalPolymorphicType<CaptureSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA0AA07E1u:
                MarshalPolymorphicType<BeamSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x431722A9u:
                MarshalPolymorphicType<WeaponSetUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x22ED33D8u:
                MarshalPolymorphicType<AudioLoopUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xAE60AE98u:
                MarshalPolymorphicType<UpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x3FECABBBu:
                MarshalPolymorphicType<UnpauseSpecialPowerUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4758FED0u:
                MarshalPolymorphicType<HordeContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x408E9A3Fu:
                MarshalPolymorphicType<HordeTransportContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x578C272Fu:
                MarshalPolymorphicType<TransportContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x5A0E7D7Bu:
                MarshalPolymorphicType<TerrainResourceBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x5F06BA81u:
                MarshalPolymorphicType<SubObjectsUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x643A2AC3u:
                MarshalPolymorphicType<ShieldBodyUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x5E1CAFDBu:
                MarshalPolymorphicType<AttributeModifierAuraUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC6F3F62Du:
                MarshalPolymorphicType<InitiateRepairDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x8CE2210Cu:
                MarshalPolymorphicType<StructureCollapseUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x74569AAAu:
                MarshalPolymorphicType<StealthDetectorUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB9B2A9B3u:
                MarshalPolymorphicType<SpecialPowerUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD877BA74u:
                MarshalPolymorphicType<SpecialPowerDispatchSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x90A9315Bu:
                MarshalPolymorphicType<HordeDispatchSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x9DAFD38Cu:
                MarshalPolymorphicType<AssignSlavesTargetObjectSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xCEFE1113u:
                MarshalPolymorphicType<SpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x78FDECC7u:
                MarshalPolymorphicType<LargeGroupAudioUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC80E586Bu:
                MarshalPolymorphicType<OCLMonitorSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x511F1BBBu:
                MarshalPolymorphicType<CurseSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xAC598F82u:
                MarshalPolymorphicType<SpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0D916ADFu:
                MarshalPolymorphicType<SpawnBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x98769794u:
                MarshalPolymorphicType<SlowDeathBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x573DC203u:
                MarshalPolymorphicType<VeterancyCrateCollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xEE961694u:
                MarshalPolymorphicType<UnitCrateCollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB297F4B2u:
                MarshalPolymorphicType<ShroudCrateCollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xEF293C44u:
                MarshalPolymorphicType<MoneyCrateCollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x839AE83Cu:
                MarshalPolymorphicType<HealCrateCollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x1E205942u:
                MarshalPolymorphicType<SalvageCrateCollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x53FBA9B5u:
                MarshalPolymorphicType<ReplaceSelfUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x75A090B5u:
                MarshalPolymorphicType<RemoveUpgradeUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE1BD0410u:
                MarshalPolymorphicType<RefundDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0453E648u:
                MarshalPolymorphicType<GiveOrRestoreUpgradeSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xDDB97E4Bu:
                MarshalPolymorphicType<CaptureAndGiveCommandSetSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x52EECAEDu:
                MarshalPolymorphicType<RadarFreezeSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x47DF9C1Au:
                MarshalPolymorphicType<RadarSpySpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE6B352B9u:
                MarshalPolymorphicType<RadarJamSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xBED5AA3Au:
                MarshalPolymorphicType<RadarHackSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x7C298D04u:
                MarshalPolymorphicType<UncombineSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x599F60D5u:
                MarshalPolymorphicType<CombineSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x9063FB6Cu:
                MarshalPolymorphicType<QueueProductionExitUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x1B337783u:
                MarshalPolymorphicType<ProductionUpdateInfoModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x6EC75439u:
                MarshalPolymorphicType<ProductionUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x005B408Eu:
                MarshalPolymorphicType<PlayerUpgradeSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA112A404u:
                MarshalPolymorphicType<CompositeStructureInfoModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x784EC9B8u:
                MarshalPolymorphicType<CombinedInfoModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x79BFEDCBu:
                MarshalPolymorphicType<PhysicsBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE491340Bu:
                MarshalPolymorphicType<HealContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD7CC2E35u:
                MarshalPolymorphicType<OpenContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB8B58445u:
                MarshalPolymorphicType<OCLUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC662DEB4u:
                MarshalPolymorphicType<TemporaryOwnerSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x8999C6A4u:
                MarshalPolymorphicType<OCLSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x69E2CD6Cu:
                MarshalPolymorphicType<ObjectCreationUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x93833563u:
                MarshalPolymorphicType<TeleportToCasterSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4E463B86u:
                MarshalPolymorphicType<TeleportSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF145A667u:
                MarshalPolymorphicType<OCLMonitorUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x09BE107Cu:
                MarshalPolymorphicType<StrafeAreaUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xDDD81EE9u:
                MarshalPolymorphicType<RandomModelConditionBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4DDD5C7Fu:
                MarshalPolymorphicType<ModelConditionUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC7248613u:
                MarshalPolymorphicType<ModelConditionSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB53A18ADu:
                MarshalPolymorphicType<MinefieldBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x7C9A2737u:
                MarshalPolymorphicType<MaxHealthUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x14E031A2u:
                MarshalPolymorphicType<SwitchLocomotorsSpecialAbilityUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2799DFF2u:
                MarshalPolymorphicType<LocomotorSetModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x6C283C72u:
                MarshalPolymorphicType<LifetimeUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x977D25A1u:
                MarshalPolymorphicType<LevelUpUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE7CF961Cu:
                MarshalPolymorphicType<JumpJetSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x91840787u:
                MarshalPolymorphicType<MissileUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x7517FE52u:
                MarshalPolymorphicType<HeightDieUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x04B8C430u:
                MarshalPolymorphicType<GrantUpgradeCreateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2DE34173u:
                MarshalPolymorphicType<GiveUpgradeUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF3967C53u:
                MarshalPolymorphicType<GettingBuiltBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xFF84FBDEu:
                MarshalPolymorphicType<GeometryUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB07119E4u:
                MarshalPolymorphicType<FXListBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x4D834921u:
                MarshalPolymorphicType<AutoDepositUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x6BE00745u:
                MarshalPolymorphicType<FlammableUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF3B802D5u:
                MarshalPolymorphicType<DamageFieldUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x97482233u:
                MarshalPolymorphicType<OilSpillUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x06DE2D62u:
                MarshalPolymorphicType<ToppleUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xF5D17C70u:
                MarshalPolymorphicType<StructureToppleUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xB28C3D52u:
                MarshalPolymorphicType<FireWeaponUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xAE4A97B0u:
                MarshalPolymorphicType<FireWeaponCollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x5717D9DCu:
                MarshalPolymorphicType<InvalidTargetsDeathUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x5047272Eu:
                MarshalPolymorphicType<InfiltratorContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0FF760E0u:
                MarshalPolymorphicType<EngineerContainModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA966196Eu:
                MarshalPolymorphicType<EmotionTrackerUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x03E414F0u:
                MarshalPolymorphicType<DynamicShroudClearingRangeUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0F7EC801u:
                MarshalPolymorphicType<DestroyDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x6A65E73Du:
                MarshalPolymorphicType<DefaultProductionExitUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2F46AEF0u:
                MarshalPolymorphicType<RebuildHoleBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xD25E223Au:
                MarshalPolymorphicType<RebuildHoleExposeDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x91ED30DCu:
                MarshalPolymorphicType<CrushDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x3B68B768u:
                MarshalPolymorphicType<CreateObjectDieModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x7EB7F219u:
                MarshalPolymorphicType<CommandSetUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x70E5C103u:
                MarshalPolymorphicType<CollideModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xE48609FBu:
                MarshalPolymorphicType<ClusterBombUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x8FFB4C58u:
                MarshalPolymorphicType<CastleUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x815A9161u:
                MarshalPolymorphicType<BuildingBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x0BBF2A39u:
                MarshalPolymorphicType<BezierProjectileBehaviorModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC8E1225Fu:
                MarshalPolymorphicType<SlavedUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xC939197Bu:
                MarshalPolymorphicType<BeamTargetModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0xA1FE37ACu:
                MarshalPolymorphicType<ArmorUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x239D954Fu:
                MarshalPolymorphicType<AttackTargetSpecialPowerModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x74A24C45u:
                MarshalPolymorphicType<AttributeModifierUpgradeModuleData, BehaviorModuleData>(node, objT, state);
                break;
            case 0x2B847E06u:
                MarshalPolymorphicType<AISpecialPowerUpdateModuleData, BehaviorModuleData>(node, objT, state);
                break;
            default:
                break;
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Behavior module {0:X08} is not implemented.", typeId);
        }
    }
}
