using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InitialPayload* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InitialPayload.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(InitialPayload.Count), null), &objT->Count, state);
    }

    public static unsafe void Marshal(Node node, UpgradeCreation* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UpgradeCreation.Upgrade), null), &objT->Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeCreation.Template), null), &objT->Template, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeCreation.Num), null), &objT->Num, state);
    }

#if KANESWRATH
    public static unsafe void Marshal(Node node, TransportContainUpgradeOverrideData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TransportContainUpgradeOverrideData.UpgradeTriggeredBy), null), &objT->UpgradeTriggeredBy, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainUpgradeOverrideData.AdditionalSlots), "0"), &objT->AdditionalSlots, state);
    }

    public static unsafe void Marshal(Node node, TransportContainUpgradeOverrideData** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(TransportContainUpgradeOverrideData), 1u);
        Marshal(node, *objT, state);
    }
#endif

    public static unsafe void Marshal(Node node, TransportContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.Slots), "0"), &objT->Slots, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ScatterNearbyOnExit), "true"), &objT->ScatterNearbyOnExit, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.OrientLikeContainerOnExit), "false"), &objT->OrientLikeContainerOnExit, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.DestroyRidersWhoAreNotFreeToExit), "false"), &objT->DestroyRidersWhoAreNotFreeToExit, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ExitBone), null), &objT->ExitBone, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ExitPitchRate), "0"), &objT->ExitPitchRate, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.HealthRegenPercentPerSec), "0"), &objT->HealthRegenPercentPerSec, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ExitDelay), "0"), &objT->ExitDelay, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.TypeOneForWeaponSet), null), &objT->TypeOneForWeaponSet, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.TypeTwoForWeaponSet), null), &objT->TypeTwoForWeaponSet, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.TypeOneForWeaponState), null), &objT->TypeOneForWeaponState, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.TypeTwoForWeaponState), null), &objT->TypeTwoForWeaponState, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.TypeThreeForWeaponState), null), &objT->TypeThreeForWeaponState, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ForceOrientationContainer), "true"), &objT->ForceOrientationContainer, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.CanGrabStructure), "false"), &objT->CanGrabStructure, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.GrabWeapon), null), &objT->GrabWeapon, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.FireGrabWeaponOnVictim), "true"), &objT->FireGrabWeaponOnVictim, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ConditionForEntry), null), &objT->ConditionForEntry, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ShouldThrowOutPassengers), "false"), &objT->ShouldThrowOutPassengers, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ThrowOutPassengersDelay), "0"), &objT->ThrowOutPassengersDelay, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ThrowOutPassengersLandingWarhead), null), &objT->ThrowOutPassengersLandingWarhead, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.FadePassengerOnEnter), "false"), &objT->FadePassengerOnEnter, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.FadePassengerOnExit), "false"), &objT->FadePassengerOnExit, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.EnterFadeTime), "0"), &objT->EnterFadeTime, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ExitFadeTime), "0"), &objT->ExitFadeTime, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.FadeReverse), "false"), &objT->FadeReverse, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ReleaseSnappyness), "0.7"), &objT->ReleaseSnappyness, state);
        Marshal(node.GetAttributeValue(nameof(TransportContainModuleData.ExtendedExitContainerChecks), "false"), &objT->ExtendedExitContainerChecks, state);
        Marshal(node.GetChildNodes(nameof(TransportContainModuleData.InitialPayload)), &objT->InitialPayload, state);
        Marshal(node.GetChildNode(nameof(TransportContainModuleData.ThrowOutPassengersVelocity), null), &objT->ThrowOutPassengersVelocity, state);
        Marshal(node.GetChildNodes(nameof(TransportContainModuleData.UpgradeCreationTrigger)), &objT->UpgradeCreationTrigger, state);
        Marshal(node.GetChildNode(nameof(TransportContainModuleData.FadeFilter), null), &objT->FadeFilter, state);
        Marshal(node.GetChildNode(nameof(TransportContainModuleData.TransportContainUpgradeOverride), null), &objT->TransportContainUpgradeOverride, state);
        Marshal(node, (OpenContainModuleData*)objT, state);
    }
}
