using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, OilSpillUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(OilSpillUpdateModuleData.BreadCrumb), null), &objT->BreadCrumb, state);
        Marshal(node.GetAttributeValue(nameof(OilSpillUpdateModuleData.IgnitionWeaponName), null), &objT->IgnitionWeaponName, state);
        Marshal(node.GetAttributeValue(nameof(OilSpillUpdateModuleData.IgnitionWeaponSpacing), null), &objT->IgnitionWeaponSpacing, state);
        Marshal(node.GetAttributeValue(nameof(OilSpillUpdateModuleData.OilSpillFX), null), &objT->OilSpillFX, state);
        Marshal(node, (FireWeaponUpdateModuleData*)objT, state);
    }
}
