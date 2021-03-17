using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BeamSpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BeamSpecialAbilityUpdateModuleData.DamagePerSecond), null), &objT->DamagePerSecond, state);
        Marshal(node.GetAttributeValue(nameof(BeamSpecialAbilityUpdateModuleData.JoinWithOtherBeams), "false"), &objT->JoinWithOtherBeams, state);
        Marshal(node.GetAttributeValue(nameof(BeamSpecialAbilityUpdateModuleData.DissapateWhenTargetDead), "true"), &objT->DissapateWhenTargetDead, state);
        Marshal(node.GetAttributeValue(nameof(BeamSpecialAbilityUpdateModuleData.LineType), "false"), &objT->LineType, state);
        Marshal(node.GetAttributeValue(nameof(BeamSpecialAbilityUpdateModuleData.TargetAttributeModifierAdd), null), &objT->TargetAttributeModifierAdd, state);
        Marshal(node.GetAttributeValue(nameof(BeamSpecialAbilityUpdateModuleData.SweepFX), null), &objT->SweepFX, state);
        Marshal(node.GetAttributeValue(nameof(BeamSpecialAbilityUpdateModuleData.ReflectorExtendDistance), "0"), &objT->ReflectorExtendDistance, state);
        Marshal(node.GetAttributeValue(nameof(BeamSpecialAbilityUpdateModuleData.TargetSamePlayerOnly), "false"), &objT->TargetSamePlayerOnly, state);
        Marshal(node.GetAttributeValue(nameof(BeamSpecialAbilityUpdateModuleData.PreferredTargetBone), null), &objT->PreferredTargetBone, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
