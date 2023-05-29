using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RepairUpdateModuleDataPercentOfBuildCostToRebuildInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleDataPercentOfBuildCostToRebuildInfo.Pristine), "50"), &objT->Pristine, state);
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleDataPercentOfBuildCostToRebuildInfo.Damaged), "50"), &objT->Damaged, state);
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleDataPercentOfBuildCostToRebuildInfo.ReallyDamaged), "50"), &objT->ReallyDamaged, state);
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleDataPercentOfBuildCostToRebuildInfo.Rubble), "50"), &objT->Rubble, state);
    }

    public static unsafe void Marshal(Node node, RepairUpdateModuleDataSelfAudio* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleDataSelfAudio.SelfRepairFromDamageLoop), null), &objT->SelfRepairFromDamageLoop, state);
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleDataSelfAudio.SelfRepairFromRubbleLoop), null), &objT->SelfRepairFromRubbleLoop, state);
    }

    public static unsafe void Marshal(Node node, RepairUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleData.Toggleable), "true"), &objT->Toggleable, state);
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleData.RepairableWhenDead), "false"), &objT->RepairableWhenDead, state);
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleData.RepopThreshold), "0.2"), &objT->RepopThreshold, state);
#if TIBERIUMWARS
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleData.HealAmountPerSecond), "150"), &objT->HealAmountPerSecond, state);
#elif KANESWRATH
        Marshal(node.GetAttributeValue(nameof(RepairUpdateModuleData.HealAmountPerSecond), "90"), &objT->HealAmountPerSecond, state);
#endif
        Marshal(node.GetChildNode(nameof(RepairUpdateModuleData.PercentOfBuildCostToRebuildInfo), null), &objT->PercentOfBuildCostToRebuildInfo, state);
        Marshal(node.GetChildNode(nameof(RepairUpdateModuleData.SelfAudio), null), &objT->SelfAudio, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
