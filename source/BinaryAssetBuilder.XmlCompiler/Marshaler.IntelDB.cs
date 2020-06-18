using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, IntelDBEntry* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(IntelDBEntry.CategoryId), null), &objT->CategoryId, state);
        Marshal(node.GetAttributeValue(nameof(IntelDBEntry.EntryId), null), &objT->EntryId, state);
        Marshal(node.GetAttributeValue(nameof(IntelDBEntry.TextureId), null), &objT->TextureId, state);
    }

    public static unsafe void Marshal(Node node, IntelDB* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(IntelDB.IntelDBEntry)), &objT->IntelDBEntry, state);
    }
}