using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, FXParticleBaseModule* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
    }

    public static unsafe void Marshal(Node node, RandCoord3D* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(RandCoord3D.x), null), &objT->x, state);
        Marshal(node.GetChildNode(nameof(RandCoord3D.y), null), &objT->y, state);
        Marshal(node.GetChildNode(nameof(RandCoord3D.z), null), &objT->z, state);
    }
}
