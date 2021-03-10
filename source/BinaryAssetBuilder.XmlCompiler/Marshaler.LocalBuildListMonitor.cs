using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LocalBuildListMonitor* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LocalBuildListMonitor.TimeBetweenUpdates), "0.25s"), &objT->TimeBetweenUpdates, state);
        Marshal(node.GetAttributeValue(nameof(LocalBuildListMonitor.UpdatesToSkipAfterStart), "4"), &objT->UpdatesToSkipAfterStart, state);
        Marshal(node.GetAttributeValue(nameof(LocalBuildListMonitor.UpdatesToSkipAfterSaveFileLoad), "2"), &objT->UpdatesToSkipAfterSaveFileLoad, state);
        Marshal(node.GetAttributeValue(nameof(LocalBuildListMonitor.UpdatesToSkipAfterTargetPlayerChanges), "2"), &objT->UpdatesToSkipAfterTargetPlayerChanges, state);
        Marshal(node.GetChildNode(nameof(LocalBuildListMonitor.ProducerObjectFilter), null), &objT->ProducerObjectFilter, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
