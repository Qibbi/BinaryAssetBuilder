using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ConnectionLineManager* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(ConnectionLineManager.FXShader), null), &objT->FXShader, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}