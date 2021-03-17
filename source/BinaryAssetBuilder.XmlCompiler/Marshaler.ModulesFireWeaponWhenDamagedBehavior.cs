using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FireWeaponWhenDamagedBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.InitiallyActive), "false"), &objT->InitiallyActive, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.DamageTypes), null), &objT->DamageTypes, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.DamageAmount), "0"), &objT->DamageAmount, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.ReactionWeaponPristine), null), &objT->ReactionWeaponPristine, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.ReactionWeaponDamaged), null), &objT->ReactionWeaponDamaged, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.ReactionWeaponReallyDamaged), null), &objT->ReactionWeaponReallyDamaged, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.ReactionWeaponRubble), null), &objT->ReactionWeaponRubble, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.ContinuousWeaponPristine), null), &objT->ContinuousWeaponPristine, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.ContinuousWeaponDamaged), null), &objT->ContinuousWeaponDamaged, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.ContinuousWeaponReallyDamaged), null), &objT->ContinuousWeaponReallyDamaged, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDamagedBehaviorModuleData.ContinuousWeaponRubble), null), &objT->ContinuousWeaponRubble, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
