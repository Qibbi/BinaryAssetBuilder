using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, PlayerPowerButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue("id", null), &objT->Id, state);
        Marshal(node.GetChildNode(nameof(PlayerPowerButtonTemplateData.State), null), &objT->State, state);
    }

    public static unsafe void Marshal(Node node, TargetedPlayerPowerButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TargetedPlayerPowerButtonTemplateData.ValidTargetCursor), null), &objT->ValidTargetCursor, state);
        Marshal(node.GetAttributeValue(nameof(TargetedPlayerPowerButtonTemplateData.InvalidTargetCursor), null), &objT->InvalidTargetCursor, state);
        Marshal(node.GetAttributeValue(nameof(TargetedPlayerPowerButtonTemplateData.RadiusCursor), null), &objT->RadiusCursor, state);
        Marshal(node, (PlayerPowerButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, MultipleTargetsTargetedPlayerPowerButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MultipleTargetsTargetedPlayerPowerButtonTemplateData.TargetMarkerTemplate), null), &objT->TargetMarkerTemplate, state);
        Marshal(node.GetAttributeValue(nameof(MultipleTargetsTargetedPlayerPowerButtonTemplateData.TargetCount), "1"), &objT->TargetCount, state);
        Marshal(node.GetAttributeValue(nameof(MultipleTargetsTargetedPlayerPowerButtonTemplateData.MinTargetDistance), "0.0"), &objT->MinTargetDistance, state);
        Marshal(node, (TargetedPlayerPowerButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, MultiplePowersTargetedPlayerPowerButtonTemplateData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MultiplePowersTargetedPlayerPowerButtonTemplateData.AdditionalSpecialPowerTemplate)), &objT->AdditionalSpecialPowerTemplate, state);
        Marshal(node.GetChildNodes(nameof(MultiplePowersTargetedPlayerPowerButtonTemplateData.AdditionalRadiusCursor)), &objT->AdditionalRadiusCursor, state);
        Marshal(node, (TargetedPlayerPowerButtonTemplateData*)objT, state);
    }

    public static unsafe void Marshal(Node node, PlayerPowerButtonTemplateData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        uint typeId = 0;
        Marshal(node.GetAttributeValue("TypeId", "0"), &typeId, Tracker.NullTracker);
        switch (typeId)
        {
            case 0x9C560552u:
                MarshalPolymorphicType<MultiplePowersTargetedPlayerPowerButtonTemplateData, PlayerPowerButtonTemplateData>(node, objT, state);
                break;
            case 0xA498FF1Fu:
                MarshalPolymorphicType<MultipleTargetsTargetedPlayerPowerButtonTemplateData, PlayerPowerButtonTemplateData>(node, objT, state);
                break;
            case 0xAC45EA0Cu:
                MarshalPolymorphicType<TargetedPlayerPowerButtonTemplateData, PlayerPowerButtonTemplateData>(node, objT, state);
                break;
            default:
                MarshalUnknownPolymorphicType(node, objT, state);
                break;
        }
    }

    public static unsafe void Marshal(Node node, PlayerPowerButtonTemplateStore* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(PlayerPowerButtonTemplateStore.Templates), null), &objT->Templates, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
