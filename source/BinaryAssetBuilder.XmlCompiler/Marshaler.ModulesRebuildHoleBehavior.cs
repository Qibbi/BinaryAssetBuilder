using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RebuildHoleBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RebuildHoleBehaviorModuleData.WorkerRespawnDelay), "0s"), &objT->WorkerRespawnDelay, state);
        Marshal(node.GetAttributeValue(nameof(RebuildHoleBehaviorModuleData.HoleHealthRegenPercentPerSecond), null), &objT->HoleHealthRegenPercentPerSecond, state);
        Marshal(node.GetAttributeValue(nameof(RebuildHoleBehaviorModuleData.WorkerTemplate), null), &objT->WorkerTemplate, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
