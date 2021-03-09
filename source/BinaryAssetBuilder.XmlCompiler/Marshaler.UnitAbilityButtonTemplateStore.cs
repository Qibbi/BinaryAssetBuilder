using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UnitAbilityButtonTemplateData.Id), null), &objT->Id, state);
    }

    public static unsafe void Marshal(Node node, SingleStateUnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(SingleStateUnitAbilityButtonTemplateData.State), null), &objT->State, state);
        Marshal(node, (UnitAbilityButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, BuildWallUnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (SingleStateUnitAbilityButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, EvacuateUnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (SingleStateUnitAbilityButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, ObjectUpgradeUnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (SingleStateUnitAbilityButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, PlayerUpgradeUnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (SingleStateUnitAbilityButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, StanceUnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StanceUnitAbilityButtonTemplateData.StanceType), null), &objT->StanceType, state);
        Marshal(node, (SingleStateUnitAbilityButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, SpecialPowerUnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (SingleStateUnitAbilityButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, TargetedSpecialPowerUnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TargetedSpecialPowerUnitAbilityButtonTemplateData.ValidTargetCursor), null), &objT->ValidTargetCursor, state);
        Marshal(node.GetAttributeValue(nameof(TargetedSpecialPowerUnitAbilityButtonTemplateData.InvalidTargetCursor), null), &objT->InvalidTargetCursor, state);
        Marshal(node.GetAttributeValue(nameof(TargetedSpecialPowerUnitAbilityButtonTemplateData.RadiusCursor), null), &objT->RadiusCursor, state);
        Marshal(node, (SpecialPowerUnitAbilityButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, MultiplePowersTargetedSpecialPowerUnitAbilityButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MultiplePowersTargetedSpecialPowerUnitAbilityButtonTemplateData.AdditionalSpecialPowerTemplate)), &objT->AdditionalSpecialPowerTemplate, state);
        Marshal(node.GetChildNodes(nameof(MultiplePowersTargetedSpecialPowerUnitAbilityButtonTemplateData.AdditionalRadiusCursor)), &objT->AdditionalRadiusCursor, state);
        Marshal(node, (TargetedSpecialPowerUnitAbilityButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, UnitAbilityButtonTemplateData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0xA2B25027u:
                MarshalPolymorphicType<StanceUnitAbilityButtonTemplateData, UnitAbilityButtonTemplateData>(node, objT, state);
                break;
            case 0xBADBAA95u:
                MarshalPolymorphicType<SingleStateUnitAbilityButtonTemplateData, UnitAbilityButtonTemplateData>(node, objT, state);
                break;
            case 0x88EDFB48u:
                MarshalPolymorphicType<TargetedSpecialPowerUnitAbilityButtonTemplateData, UnitAbilityButtonTemplateData>(node, objT, state);
                break;
            case 0x0DB9FD2Eu:
                MarshalPolymorphicType<SpecialPowerUnitAbilityButtonTemplateData, UnitAbilityButtonTemplateData>(node, objT, state);
                break;
            case 0x99E02045u:
                MarshalPolymorphicType<PlayerUpgradeUnitAbilityButtonTemplateData, UnitAbilityButtonTemplateData>(node, objT, state);
                break;
            case 0x29670E01u:
                MarshalPolymorphicType<ObjectUpgradeUnitAbilityButtonTemplateData, UnitAbilityButtonTemplateData>(node, objT, state);
                break;
            case 0xC678A25Eu:
                MarshalPolymorphicType<MultiplePowersTargetedSpecialPowerUnitAbilityButtonTemplateData, UnitAbilityButtonTemplateData>(node, objT, state);
                break;
            case 0x53476790u:
                MarshalPolymorphicType<EvacuateUnitAbilityButtonTemplateData, UnitAbilityButtonTemplateData>(node, objT, state);
                break;
            case 0x314459F7u:
                MarshalPolymorphicType<BuildWallUnitAbilityButtonTemplateData, UnitAbilityButtonTemplateData>(node, objT, state);
                break;
            default:
                MarshalUnknownPolymorphicType(node, objT, state);
                break;
        }
    }

    public static unsafe void Marshal(Node node, UnitAbilityButtonTemplateStore* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(UnitAbilityButtonTemplateStore.Templates), null), &objT->Templates, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
