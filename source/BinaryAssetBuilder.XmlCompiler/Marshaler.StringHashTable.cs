using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StringAndHash* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StringAndHash.Hash), null), &objT->Hash, state);
        Marshal(node.GetAttributeValue(nameof(StringAndHash.Text), null), &objT->Text, state);
    }

    public static unsafe void Marshal(Node node, StringHashTable* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(StringHashTable.StringAndHash)), &objT->StringAndHash, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}
