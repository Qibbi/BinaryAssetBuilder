using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, VersionType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(VersionType.Major), null), &objT->Major, state);
        Marshal(node.GetAttributeValue(nameof(VersionType.Minor), null), &objT->Minor, state);
    }

    public static unsafe void Marshal(Node node, TheVersion* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(TheVersion.Version), null), &objT->Version, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
