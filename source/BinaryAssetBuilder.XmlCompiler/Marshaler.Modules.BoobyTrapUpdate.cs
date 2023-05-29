using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BoobyTrapUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BoobyTrapUpdateModuleData.FireWeaponConditionsOnParent), null), &objT->FireWeaponConditionsOnParent, state);
        Marshal(node.GetAttributeValue(nameof(BoobyTrapUpdateModuleData.PreventEnteringSetStatusOnParent), null), &objT->PreventEnteringSetStatusOnParent, state);
        Marshal(node.GetAttributeValue(nameof(BoobyTrapUpdateModuleData.AllowTriggerOnAllies), "false"), &objT->AllowTriggerOnAllies, state);
        Marshal(node.GetAttributeValue(nameof(BoobyTrapUpdateModuleData.SpecialWeapon), null), &objT->SpecialWeapon, state);
        Marshal(node.GetChildNode(nameof(BoobyTrapUpdateModuleData.PreventEnteringFilter), null), &objT->PreventEnteringFilter, state);
        Marshal(node, (AttachUpdateModuleData*)objT, state);
    }
}
