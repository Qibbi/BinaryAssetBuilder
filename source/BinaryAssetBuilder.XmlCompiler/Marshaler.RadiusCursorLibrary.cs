using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RadiusCursor* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RadiusCursor.Id), null), &objT->Id, state);
        Marshal(node.GetChildNode(nameof(RadiusCursor.DecalTemplate), null), &objT->DecalTemplate, state);
    }

    public static unsafe void Marshal(Node node, RadiusCursorLibrary* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(RadiusCursorLibrary.RadiusCursor)), &objT->RadiusCursor, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
