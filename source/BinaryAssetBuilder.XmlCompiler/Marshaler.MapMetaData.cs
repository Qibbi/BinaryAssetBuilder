using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, StartPositionObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(StartPositionObject.Name), null), &objT->Name, state);
        Marshal(node.GetChildNode(nameof(StartPositionObject.Position), null), &objT->Position, state);
    }

    public static unsafe void Marshal(Node node, MetaDataObject* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.id), null), &objT->id, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.Description), null), &objT->Description, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.DisplayName), null), &objT->DisplayName, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.IsMultiplayer), null), &objT->IsMultiplayer, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.NumPlayers), null), &objT->NumPlayers, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.CRC), null), &objT->CRC, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.FileName), null), &objT->FileName, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.IsOfficial), null), &objT->IsOfficial, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.Width), null), &objT->Width, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.Height), null), &objT->Height, state);
        Marshal(node.GetAttributeValue(nameof(MetaDataObject.BorderSize), null), &objT->BorderSize, state);
        Marshal(node.GetChildNodes(nameof(MetaDataObject.StartPosition)), &objT->StartPosition, state);
    }

    public static unsafe void Marshal(Node node, MapMetaDataType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(MapMetaDataType.MapMetaData)), &objT->MapMetaData, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}