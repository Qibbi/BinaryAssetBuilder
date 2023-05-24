using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, PassengerDataType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PassengerDataType.BonePrefix), null), &objT->BonePrefix, state);
        Marshal(node.GetAttributeValue(nameof(PassengerDataType.Flags), null), &objT->Flags, state);
        Marshal(node.GetChildNode(nameof(PassengerDataType.Filter), null), &objT->Filter, state);
    }

    public static unsafe void Marshal(Node node, MemberTemplateStatusData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MemberTemplateStatusData.ThingTemplate), null), &objT->ThingTemplate, state);
        Marshal(node.GetAttributeValue(nameof(MemberTemplateStatusData.ObjectStatus), null), &objT->ObjectStatus, state);
    }

    public static unsafe void Marshal(Node node, OpenContainUpgradeOverrideData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(OpenContainUpgradeOverrideData.UpgradeTriggeredBy), null), &objT->UpgradeTriggeredBy, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainUpgradeOverrideData.ObjectStatusOfContained), null), &objT->ObjectStatusOfContained, state);
    }

    private static unsafe void Marshal(Node node, OpenContainUpgradeOverrideData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(OpenContainUpgradeOverrideData), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, OpenContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.ContainMax), "0"), &objT->ContainMax, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.EnterSound), null), &objT->EnterSound, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.ExitSound), null), &objT->ExitSound, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.DamagePercentToUnits), "0"), &objT->DamagePercentToUnits, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.PassengersTestCollisionHeight), "-1000"), &objT->PassengersTestCollisionHeight, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.PassengersInTurret), "false"), &objT->PassengersInTurret, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.NumberOfExitPaths), "1"), &objT->NumberOfExitPaths, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.DoorOpenTime), "1"), &objT->DoorOpenTime, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.AllowOwnPlayerInsideOverride), "false"), &objT->AllowOwnPlayerInsideOverride, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.AllowAlliesInside), "true"), &objT->AllowAlliesInside, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.AllowEnemiesInside), "true"), &objT->AllowEnemiesInside, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.AllowNeutralInside), "true"), &objT->AllowNeutralInside, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.ShowPips), "true"), &objT->ShowPips, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.CollidePickup), "true"), &objT->CollidePickup, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.EjectPassengersOnDeath), "true"), &objT->EjectPassengersOnDeath, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.KillPassengersOnDeath), "false"), &objT->KillPassengersOnDeath, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.HasObjectStatusOfContainedEntry), "true"), &objT->HasObjectStatusOfContainedEntry, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.Enabled), "true"), &objT->Enabled, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.ObjectStatusOfContained), null), &objT->ObjectStatusOfContained, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.ModifierRequiredTime), "100"), &objT->ModifierRequiredTime, state);
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.KillIfEmptyTime), "0s"), &objT->KillIfEmptyTime, state);
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(OpenContainModuleData.ModelConditionsWhenNotEmpty), ""), &objT->ModelConditionsWhenNotEmpty, state);
#endif
        Marshal(node.GetChildNode(nameof(OpenContainModuleData.PassengerFilter), null), &objT->PassengerFilter, state);
        Marshal(node.GetChildNode(nameof(OpenContainModuleData.ManualPickUpFilter), null), &objT->ManualPickUpFilter, state);
        Marshal(node.GetChildNode(nameof(OpenContainModuleData.DieMuxData), null), &objT->DieMuxData, state);
        Marshal(node.GetChildNodes(nameof(OpenContainModuleData.PassengerData)), &objT->PassengerData, state);
        Marshal(node.GetChildNodes(nameof(OpenContainModuleData.ModifierToGiveOnExit)), &objT->ModifierToGiveOnExit, state);
        Marshal(node.GetChildNodes(nameof(OpenContainModuleData.MemberTemplateStatusInfo)), &objT->MemberTemplateStatusInfo, state);
#if KANESWRATH
        Marshal(node.GetChildNodes(nameof(OpenContainModuleData.UpgradeContainerOnContain)), &objT->UpgradeContainerOnContain, state);
        Marshal(node.GetChildNode(nameof(OpenContainModuleData.OpenContainUpgradeOverride), null), &objT->OpenContainUpgradeOverride, state);
#endif
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
