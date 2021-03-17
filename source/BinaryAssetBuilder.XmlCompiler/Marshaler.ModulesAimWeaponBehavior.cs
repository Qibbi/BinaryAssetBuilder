using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AimWeaponBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AimWeaponBehaviorModuleData.AimLowThreshold), "0"), &objT->AimLowThreshold, state);
        Marshal(node.GetAttributeValue(nameof(AimWeaponBehaviorModuleData.AimHighThreshold), "0"), &objT->AimHighThreshold, state);
        Marshal(node.GetAttributeValue(nameof(AimWeaponBehaviorModuleData.AimNearDistance), "0"), &objT->AimNearDistance, state);
        Marshal(node.GetAttributeValue(nameof(AimWeaponBehaviorModuleData.AimFarDistance), "0"), &objT->AimFarDistance, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
