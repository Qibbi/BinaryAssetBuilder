using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ShieldBodyModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ShieldBodyModuleData.ShieldEnabledFX), null), &objT->ShieldEnabledFX, state);
        Marshal(node.GetAttributeValue(nameof(ShieldBodyModuleData.ShieldDepleteFX), null), &objT->ShieldDepleteFX, state);
        Marshal(node.GetAttributeValue(nameof(ShieldBodyModuleData.ShieldRechargeEndFX), null), &objT->ShieldRechargeEndFX, state);
        Marshal(node.GetAttributeValue(nameof(ShieldBodyModuleData.ShieldTakeDamageFX), null), &objT->ShieldTakeDamageFX, state);
        Marshal(node.GetAttributeValue(nameof(ShieldBodyModuleData.ShieldAmount), null), &objT->ShieldAmount, state);
        Marshal(node.GetAttributeValue(nameof(ShieldBodyModuleData.ShieldArmor), null), &objT->ShieldArmor, state);
        Marshal(node.GetAttributeValue(nameof(ShieldBodyModuleData.ShieldRechargeIdleTime), "0s"), &objT->ShieldRechargeIdleTime, state);
        Marshal(node.GetAttributeValue(nameof(ShieldBodyModuleData.ShieldActiveModelCondition), "INVALID"), &objT->ShieldActiveModelCondition, state);
        Marshal(node, (ActiveBodyModuleData*)objT, state);
    }
}
