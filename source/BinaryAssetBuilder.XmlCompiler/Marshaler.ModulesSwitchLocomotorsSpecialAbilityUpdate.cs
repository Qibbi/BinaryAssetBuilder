using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SwitchLocomotorsSpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SwitchLocomotorsSpecialAbilityUpdateModuleData.UseUpgradedLocomotor), null), &objT->UseUpgradedLocomotor, state);
        Marshal(node.GetAttributeValue(nameof(SwitchLocomotorsSpecialAbilityUpdateModuleData.TriggersLanding), "false"), &objT->TriggersLanding, state);
        Marshal(node.GetAttributeValue(nameof(SwitchLocomotorsSpecialAbilityUpdateModuleData.TriggersFlight), "false"), &objT->TriggersFlight, state);
        Marshal(node.GetAttributeValue(nameof(SwitchLocomotorsSpecialAbilityUpdateModuleData.BusyForDuration), "0s"), &objT->BusyForDuration, state);
        Marshal(node.GetAttributeValue(nameof(SwitchLocomotorsSpecialAbilityUpdateModuleData.LandingRange), "0"), &objT->LandingRange, state);
        Marshal(node.GetAttributeValue(nameof(SwitchLocomotorsSpecialAbilityUpdateModuleData.HordeMembersSpecialPowerTemplate), null), &objT->HordeMembersSpecialPowerTemplate, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
