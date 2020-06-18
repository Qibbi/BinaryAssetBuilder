using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ImageSequence* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(ImageSequence.Image)), &objT->Image, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}