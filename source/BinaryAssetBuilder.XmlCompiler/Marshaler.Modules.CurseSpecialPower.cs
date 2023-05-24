using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CurseSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CurseSpecialPowerModuleData.TriggerFX), null), &objT->TriggerFX, state);
        Marshal(node.GetAttributeValue(nameof(CurseSpecialPowerModuleData.CurseFX), null), &objT->CurseFX, state);
        Marshal(node.GetAttributeValue(nameof(CurseSpecialPowerModuleData.CurseAllPlayerPowers), "false"), &objT->CurseAllPlayerPowers, state);
        Marshal(node.GetAttributeValue(nameof(CurseSpecialPowerModuleData.CurseFactor), "1.0"), &objT->CurseFactor, state);
        Marshal(node.GetChildNode(nameof(CurseSpecialPowerModuleData.AffectObjectFilter), null), &objT->AffectObjectFilter, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
