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
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
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
        }
    }
}
