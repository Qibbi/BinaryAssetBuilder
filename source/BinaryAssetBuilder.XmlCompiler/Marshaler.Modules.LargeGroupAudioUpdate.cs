using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LargeGroupAudioUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioUpdateModuleData.FramesBetweenUpdatesMin), "3"), &objT->FramesBetweenUpdatesMin, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioUpdateModuleData.FramesBetweenUpdatesVariation), "2"), &objT->FramesBetweenUpdatesVariation, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioUpdateModuleData.UnitWeight), "1"), &objT->UnitWeight, state);
        Marshal(node.GetChildNodes(nameof(LargeGroupAudioUpdateModuleData.Key)), &objT->Key, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
