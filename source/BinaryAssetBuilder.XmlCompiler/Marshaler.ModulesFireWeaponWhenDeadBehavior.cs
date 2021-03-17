using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, WeaponFireProbabilityType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(WeaponFireProbabilityType.DeathType), null), &objT->DeathType, state);
        Marshal(node.GetAttributeValue(nameof(WeaponFireProbabilityType.ChancePercentage), null), &objT->ChancePercentage, state);
    }

    public static unsafe void Marshal(Node node, FireWeaponWhenDeadBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDeadBehaviorModuleData.InitiallyActive), "false"), &objT->InitiallyActive, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDeadBehaviorModuleData.ActiveDuringConstruction), "false"), &objT->ActiveDuringConstruction, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDeadBehaviorModuleData.ContinueToBezierDestination), "false"), &objT->ContinueToBezierDestination, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDeadBehaviorModuleData.DelayTime), "0s"), &objT->DelayTime, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDeadBehaviorModuleData.DeathWeapon), null), &objT->DeathWeapon, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponWhenDeadBehaviorModuleData.FocusFireKindOfFlag), null), &objT->FocusFireKindOfFlag, state);
        Marshal(node.GetChildNode(nameof(FireWeaponWhenDeadBehaviorModuleData.WeaponOffset), null), &objT->WeaponOffset, state);
        Marshal(node.GetChildNode(nameof(FireWeaponWhenDeadBehaviorModuleData.DieMuxData), null), &objT->DieMuxData, state);
        Marshal(node.GetChildNodes(nameof(FireWeaponWhenDeadBehaviorModuleData.WeaponFireProbability)), &objT->WeaponFireProbability, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
