using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DualWeaponBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DualWeaponBehaviorModuleData.SwitchWeaponOnCloseRangeDistance), "0"), &objT->SwitchWeaponOnCloseRangeDistance, state);
        Marshal(node.GetAttributeValue(nameof(DualWeaponBehaviorModuleData.UseCloseRangeWhileMounted), "false"), &objT->UseCloseRangeWhileMounted, state);
        Marshal(node.GetAttributeValue(nameof(DualWeaponBehaviorModuleData.DelayBetweenSwitches), "0"), &objT->DelayBetweenSwitches, state);
        Marshal(node.GetAttributeValue(nameof(DualWeaponBehaviorModuleData.UseHordeWeapon), "false"), &objT->UseHordeWeapon, state);
        Marshal(node.GetAttributeValue(nameof(DualWeaponBehaviorModuleData.UseRealVictim), "false"), &objT->UseRealVictim, state);
        Marshal(node.GetChildNode(nameof(DualWeaponBehaviorModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (BehaviorModuleData*)objT, state);
    }
}
