using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FireWeaponUpdateModuleDataFireWeaponNugget* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FireWeaponUpdateModuleDataFireWeaponNugget.WeaponName), null), &objT->WeaponName, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponUpdateModuleDataFireWeaponNugget.FireDelay), null), &objT->FireDelay, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponUpdateModuleDataFireWeaponNugget.FireInterval), null), &objT->FireInterval, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponUpdateModuleDataFireWeaponNugget.OneShot), null), &objT->OneShot, state);
        Marshal(node.GetChildNode(nameof(FireWeaponUpdateModuleDataFireWeaponNugget.Offset), null), &objT->Offset, state);
    }

    public static unsafe void Marshal(Node node, FireWeaponUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FireWeaponUpdateModuleData.HeroModeTrigger), "false"), &objT->HeroModeTrigger, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponUpdateModuleData.ChargingModeTrigger), "false"), &objT->ChargingModeTrigger, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponUpdateModuleData.AliveOnly), "false"), &objT->AliveOnly, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponUpdateModuleData.ActiveWhenDisabled), null), &objT->ActiveWhenDisabled, state);
        Marshal(node.GetChildNodes(nameof(FireWeaponUpdateModuleData.FireWeaponNugget)), &objT->FireWeaponNugget, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
