using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, OCNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    public static unsafe void Marshal(Node node, CreateObjectNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.PutInContainer), null), &objT->PutInContainer, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.ParticleSystem), null), &objT->ParticleSystem, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.CreateFX), null), &objT->CreateFX, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.Count), "1"), &objT->Count, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.Options), null), &objT->Options, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.Disposition), null), &objT->Disposition, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.VelocityScale), "1.0"), &objT->VelocityScale, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MinForceMagnitude), null), &objT->MinForceMagnitude, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MaxForceMagnitude), null), &objT->MaxForceMagnitude, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MinLifetime), null), &objT->MinLifetime, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MaxLifetime), null), &objT->MaxLifetime, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MinDistanceAFormation), null), &objT->MinDistanceAFormation, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MinDistanceBFormation), null), &objT->MinDistanceBFormation, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MaxDistanceFormation), null), &objT->MaxDistanceFormation, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.FadeTime), null), &objT->FadeTime, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.StartingModelConditions), "INVALID"), &objT->StartingModelConditions, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.TempModelCondition), "INVALID"), &objT->TempModelCondition, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.TempModelConditionTime), "0s"), &objT->TempModelConditionTime, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.DispositionIntensity), null), &objT->DispositionIntensity, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.DestinationPlayer), null), &objT->DestinationPlayer, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.WaypointSpawn), null), &objT->WaypointSpawn, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.DispositionAngle), null), &objT->DispositionAngle, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MinForcePitch), null), &objT->MinForcePitch, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MaxForcePitch), null), &objT->MaxForcePitch, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MinForceYaw), "0d"), &objT->MinForceYaw, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MaxForceYaw), "359d"), &objT->MaxForceYaw, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.OrientationOffset), null), &objT->OrientationOffset, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.FadeSound), null), &objT->FadeSound, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MinHordeDensity), "100"), &objT->MinHordeDensity, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MaxHordeDensity), "100"), &objT->MaxHordeDensity, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MinHealth), "1.0"), &objT->MinHealth, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.MaxHealth), "1.0"), &objT->MaxHealth, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.InvulnerableTime), null), &objT->InvulnerableTime, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.StartingBusyTime), null), &objT->StartingBusyTime, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.JustBuiltFrames), null), &objT->JustBuiltFrames, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.VeterancyLevel), null), &objT->VeterancyLevel, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.UseUpgradedLocomotor), "false"), &objT->UseUpgradedLocomotor, state);
        Marshal(node.GetAttributeValue(nameof(CreateObjectNugget.DisabledWhileBusy), "false"), &objT->DisabledWhileBusy, state);
        Marshal(node.GetChildNode(nameof(CreateObjectNugget.Offset), null), &objT->Offset, state);
        Marshal(node.GetChildNodes(nameof(CreateObjectNugget.RequiredUpgrade)), &objT->RequiredUpgrade, state);
        Marshal(node.GetChildNodes(nameof(CreateObjectNugget.ForbiddenUpgrade)), &objT->ForbiddenUpgrade, state);
        Marshal(node.GetChildNodes(nameof(CreateObjectNugget.CreateObject)), &objT->CreateObject, state);
        Marshal(node, (OCNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, FireWeaponNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FireWeaponNugget.Weapon), null), &objT->Weapon, state);
        Marshal(node, (OCNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, AttackNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AttackNugget.NumberOfShots), "1"), &objT->NumberOfShots, state);
        Marshal(node.GetAttributeValue(nameof(AttackNugget.WeaponSlot), "PRIMARY_WEAPON"), &objT->WeaponSlot, state);
        Marshal(node.GetAttributeValue(nameof(AttackNugget.DeliveryDecalRadius), null), &objT->DeliveryDecalRadius, state);
        Marshal(node.GetChildNode(nameof(AttackNugget.DeliveryDecal), null), &objT->DeliveryDecal, state);
        Marshal(node, (OCNugget*)objT, state);
    }

    public static unsafe void Marshal(Node node, ObjectCreationList* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(ObjectCreationList.CreateObject)), &objT->CreateObject, state);
        Marshal(node.GetChildNodes(nameof(ObjectCreationList.Attack)), &objT->Attack, state);
        Marshal(node.GetChildNodes(nameof(ObjectCreationList.FireWeapon)), &objT->FireWeapon, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
