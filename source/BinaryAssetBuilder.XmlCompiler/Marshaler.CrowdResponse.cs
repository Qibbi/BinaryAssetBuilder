using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, Threshold* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Threshold.NumUnits), "0"), &objT->NumUnits, state);
        Marshal(node.GetChildNode(nameof(Threshold.AudioArrayVoice), null), &objT->AudioArrayVoice, state);
    }

    public static unsafe void Marshal(Node node, CrowdResponse* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CrowdResponse.Weight), "100"), &objT->Weight, state);
        Marshal(node.GetChildNodes(nameof(CrowdResponse.Threshold)), &objT->Threshold, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
