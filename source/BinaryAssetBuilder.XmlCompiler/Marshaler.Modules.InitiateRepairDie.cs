using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InitiateRepairDieModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InitiateRepairDieModuleData.DelayTime), "0s"), &objT->DelayTime, state);
        Marshal(node.GetAttributeValue(nameof(InitiateRepairDieModuleData.MasterDeadDieFX), null), &objT->MasterDeadDieFX, state);
        Marshal(node.GetAttributeValue(nameof(InitiateRepairDieModuleData.Options), null), &objT->Options, state);
        Marshal(node.GetAttributeValue(nameof(InitiateRepairDieModuleData.InstantRepairModelCondition), nameof(ModelConditionFlagType.INVALID)), &objT->InstantRepairModelCondition, state);
        Marshal(node.GetAttributeValue(nameof(InitiateRepairDieModuleData.InstantRepairAnimDuration), null), &objT->InstantRepairAnimDuration, state);
        Marshal(node.GetChildNode(nameof(InitiateRepairDieModuleData.Die), null), &objT->Die, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
