#if TIBERIUMWARS
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RespawnRuleType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RespawnRuleType.AutoSpawn), null), &objT->AutoSpawn, state);
        Marshal(node.GetAttributeValue(nameof(RespawnRuleType.Time), null), &objT->Time, state);
        Marshal(node.GetAttributeValue(nameof(RespawnRuleType.Health), null), &objT->Health, state);
        Marshal(node.GetAttributeValue(nameof(RespawnRuleType.Cost), null), &objT->Cost, state);
        Marshal(node.GetAttributeValue(nameof(RespawnRuleType.Level), "1"), &objT->Level, state);
    }

    public static unsafe void Marshal(Node node, RespawnUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.DeathMC), null), &objT->DeathMC, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.DeathFX), null), &objT->DeathFX, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.DeathAnimationTime), null), &objT->DeathAnimationTime, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.SpawnMC), null), &objT->SpawnMC, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.SpawnFX), null), &objT->SpawnFX, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.SpawnAnimationTime), null), &objT->SpawnAnimationTime, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.RespawnMC), null), &objT->RespawnMC, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.RespawnFX), null), &objT->RespawnFX, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.RespawnAnimationTime), null), &objT->RespawnAnimationTime, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.ButtonImage), null), &objT->ButtonImage, state);
        Marshal(node.GetAttributeValue(nameof(RespawnUpdateModuleData.RespawnAsTemplate), null), &objT->RespawnAsTemplate, state);
        Marshal(node.GetChildNodes(nameof(RespawnUpdateModuleData.Rule)), &objT->Rule, state);
        Marshal(node.GetChildNode(nameof(RespawnUpdateModuleData.AutoRespawnAtObjectFilter), null), &objT->AutoRespawnAtObjectFilter, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
#endif
