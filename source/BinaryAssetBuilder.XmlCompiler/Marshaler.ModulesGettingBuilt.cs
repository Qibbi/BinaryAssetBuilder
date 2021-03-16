using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SelfAudio* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SelfAudio.SelfBuildingLoop), null), &objT->SelfBuildingLoop, state);
        Marshal(node.GetAttributeValue(nameof(SelfAudio.SelfRepairFromDamageLoop), null), &objT->SelfRepairFromDamageLoop, state);
        Marshal(node.GetAttributeValue(nameof(SelfAudio.SelfRepairFromRubbleLoop), null), &objT->SelfRepairFromRubbleLoop, state);
    }

    public static unsafe void Marshal(Node node, PercentOfBuildCostToRebuildInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PercentOfBuildCostToRebuildInfo.Pristine), "50"), &objT->Pristine, state);
        Marshal(node.GetAttributeValue(nameof(PercentOfBuildCostToRebuildInfo.Damaged), "50"), &objT->Damaged, state);
        Marshal(node.GetAttributeValue(nameof(PercentOfBuildCostToRebuildInfo.ReallyDamaged), "50"), &objT->ReallyDamaged, state);
        Marshal(node.GetAttributeValue(nameof(PercentOfBuildCostToRebuildInfo.Rubble), "50"), &objT->Rubble, state);
    }

    public static unsafe void Marshal(Node node, GettingBuiltBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GettingBuiltBehaviorModuleData.WorkerTemplate), null), &objT->WorkerTemplate, state);
        Marshal(node.GetAttributeValue(nameof(GettingBuiltBehaviorModuleData.EvilWorkerTemplate), null), &objT->EvilWorkerTemplate, state);
        Marshal(node.GetAttributeValue(nameof(GettingBuiltBehaviorModuleData.TestFaction), "false"), &objT->TestFaction, state);
        Marshal(node.GetAttributeValue(nameof(GettingBuiltBehaviorModuleData.SpawnTimer), "30"), &objT->SpawnTimer, state);
        Marshal(node.GetAttributeValue(nameof(GettingBuiltBehaviorModuleData.RebuildWhenDead), "false"), &objT->RebuildWhenDead, state);
        Marshal(node.GetAttributeValue(nameof(GettingBuiltBehaviorModuleData.HealWeapon), null), &objT->HealWeapon, state);
        Marshal(node.GetAttributeValue(nameof(GettingBuiltBehaviorModuleData.RebuildTimeSeconds), "120"), &objT->RebuildTimeSeconds, state);
        Marshal(node.GetAttributeValue(nameof(GettingBuiltBehaviorModuleData.DisallowRebuildRange), "0"), &objT->DisallowRebuildRange, state);
        Marshal(node.GetAttributeValue(nameof(GettingBuiltBehaviorModuleData.UseSpawnTimerWithoutWorker), "false"), &objT->UseSpawnTimerWithoutWorker, state);
        Marshal(node.GetChildNode(nameof(GettingBuiltBehaviorModuleData.PercentOfBuildCostToRebuildInfo), null), &objT->PercentOfBuildCostToRebuildInfo, state);
        Marshal(node.GetChildNode(nameof(GettingBuiltBehaviorModuleData.SelfAudio), null), &objT->SelfAudio, state);
        Marshal(node.GetChildNode(nameof(GettingBuiltBehaviorModuleData.DisallowRebuildFilter), null), &objT->DisallowRebuildFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
