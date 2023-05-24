using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, WeaponSlot_WeaponData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_WeaponData.Ordering), null), &objT->Ordering, state);
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_WeaponData.Template), null), &objT->Template, state);
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_WeaponData.Upgrade), null), &objT->Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_WeaponData.ObjectStatus), ""), &objT->ObjectStatus, state);
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_WeaponData.IsPlayerUpgradePermanent), "false"), &objT->IsPlayerUpgradePermanent, state);
    }

    public static unsafe void Marshal(Node node, WeaponSlot_Hardpoint* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_Hardpoint.ID), null), &objT->ID, state);
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_Hardpoint.AllowInterleavedFiring), "false"), &objT->AllowInterleavedFiring, state);
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_Hardpoint.InterleavedStyle), nameof(WeaponSlotInterleavedStyleType.INTERLEAVE_RANDOM)), &objT->InterleavedStyle, state);
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_Hardpoint.WeaponChoiceCriteria), nameof(WeaponChoiceCriteria.PREFER_MOST_DAMAGE)), &objT->WeaponChoiceCriteria, state);
        Marshal(node.GetChildNodes(nameof(WeaponSlot_Hardpoint.Weapon)), &objT->Weapon, state);
    }

    public static unsafe void Marshal(Node node, WeaponSlot_Turret* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(WeaponSlot_Turret.TurretSettings), null), &objT->TurretSettings, state);
        Marshal(node, (WeaponSlot_Hardpoint*)objT, state);
    }

    public static unsafe void Marshal(Node node, WeaponSlot_HierarchicalTurret* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WeaponSlot_HierarchicalTurret.ParentID), "0"), &objT->ParentID, state);
        Marshal(node, (WeaponSlot_Turret*)objT, state);
    }

    public static unsafe void Marshal(Node node, WeaponSetUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(WeaponSetUpdateModuleData.WeaponSlotHardpoint)), &objT->WeaponSlotHardpoint, state);
        Marshal(node.GetChildNodes(nameof(WeaponSetUpdateModuleData.WeaponSlotTurret)), &objT->WeaponSlotTurret, state);
        Marshal(node.GetChildNodes(nameof(WeaponSetUpdateModuleData.WeaponSlotHierarchicalTurret)), &objT->WeaponSlotHierarchicalTurret, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
