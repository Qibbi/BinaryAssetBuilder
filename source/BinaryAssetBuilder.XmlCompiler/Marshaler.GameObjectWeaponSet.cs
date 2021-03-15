using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, WeaponTemplateSetSlot* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSetSlot.WeaponSlot), null), &objT->WeaponSlot, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSetSlot.WeaponTemplate), null), &objT->WeaponTemplate, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSetSlot.PreferredAgainst), null), &objT->PreferredAgainst, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSetSlot.OnlyAgainst), null), &objT->OnlyAgainst, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSetSlot.AutoChooseMask), null), &objT->AutoChooseMask, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSetSlot.OnlyInCondition), null), &objT->OnlyInCondition, state);
    }

    public static unsafe void Marshal(Node node, WeaponTemplateSet* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSet.Conditions), null), &objT->Conditions, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSet.OnlyAgainst), null), &objT->OnlyAgainst, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSet.OnlyInCondition), null), &objT->OnlyInCondition, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSet.ShareWeaponReloadTime), "false"), &objT->ShareWeaponReloadTime, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSet.WeaponLockSharedAcrossSets), "false"), &objT->WeaponLockSharedAcrossSets, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSet.ReadyStatusSharedWithinSet), "false"), &objT->ReadyStatusSharedWithinSet, state);
        Marshal(node.GetAttributeValue(nameof(WeaponTemplateSet.DefaultWeaponChoiceCritera), null), &objT->DefaultWeaponChoiceCritera, state);
        Marshal(node.GetChildNodes(nameof(WeaponTemplateSet.Slot)), &objT->Slot, state);
    }
}
