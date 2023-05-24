using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TiberiumThiefSpecialAbilityUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TiberiumThiefSpecialAbilityUpdateModuleData.TiberiumStolenPerUpdate), "1"), &objT->TiberiumStolenPerUpdate, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumThiefSpecialAbilityUpdateModuleData.DelayBetweenThefts), "0s"), &objT->DelayBetweenThefts, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumThiefSpecialAbilityUpdateModuleData.TiberiumCapacity), "1"), &objT->TiberiumCapacity, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumThiefSpecialAbilityUpdateModuleData.ObjectStatusWhenNotEmpty), ""), &objT->ObjectStatusWhenNotEmpty, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumThiefSpecialAbilityUpdateModuleData.ModelConditionWhenNotEmpty), null), &objT->ModelConditionWhenNotEmpty, state);
        Marshal(node.GetAttributeValue(nameof(TiberiumThiefSpecialAbilityUpdateModuleData.PlayWeaponPreFireFX), "false"), &objT->PlayWeaponPreFireFX, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
