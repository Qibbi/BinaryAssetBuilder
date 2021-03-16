using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FireWeaponCollideModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(FireWeaponCollideModuleData.CollideWeapon), null), &objT->CollideWeapon, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponCollideModuleData.FireOnce), "false"), &objT->FireOnce, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponCollideModuleData.Flags), "NONE"), &objT->Flags, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponCollideModuleData.RequiredStatus), null), &objT->RequiredStatus, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponCollideModuleData.ForbiddenStatus), null), &objT->ForbiddenStatus, state);
        Marshal(node.GetAttributeValue(nameof(FireWeaponCollideModuleData.WhereToFire), "TARGET_OBJECT"), &objT->WhereToFire, state);
        Marshal(node, (CollideModuleData*)objT, state);
    }
}
