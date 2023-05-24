using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, WeaponFireSpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.SpecialWeapon), null), &objT->SpecialWeapon, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.WhichSpecialWeapon), "0"), &objT->WhichSpecialWeapon, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.SkipContinue), "false"), &objT->SkipContinue, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.BusyForDuration), "0s"), &objT->BusyForDuration, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.NeedLivingTargets), "false"), &objT->NeedLivingTargets, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.PlayWeaponPreFireFX), "false"), &objT->PlayWeaponPreFireFX, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.OffsetTargetLocationFromObject), "false"), &objT->OffsetTargetLocationFromObject, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.WeaponSlotID), "1"), &objT->WeaponSlotID, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.WeaponSlotType), nameof(WeaponSlotType.PRIMARY_WEAPON)), &objT->WeaponSlotType, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireSpecialAbilityUpdateModuleData.DestealthClosestObjectMatchingFilter), "false"), &objT->DestealthClosestObjectMatchingFilter, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
