using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DamageFieldUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DamageFieldUpdateModuleData.Radius), "0"), &objT->Radius, state);
        Marshal(node.GetAttributeValue(nameof(DamageFieldUpdateModuleData.RequiredUpgrade), null), &objT->RequiredUpgrade, state);
        Marshal(node.GetChildNode(nameof(DamageFieldUpdateModuleData.ObjectFilter), null), &objT->ObjectFilter, state);
        Marshal(node, (FireWeaponUpdateModuleData*)objT, state);
    }
}
