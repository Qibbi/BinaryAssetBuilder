using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, BridgeBuilderModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.EndCap), null), &objT->EndCap, state);
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.EndCap2), null), &objT->EndCap2, state);
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.EndCapLen), null), &objT->EndCapLen, state);
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.CenterPiece), null), &objT->CenterPiece, state);
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.CenterPieceLen), null), &objT->CenterPieceLen, state);
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.CenterPieceB), null), &objT->CenterPieceB, state);
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.CenterPieceBLen), null), &objT->CenterPieceBLen, state);
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.Width), null), &objT->Width, state);
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.GateHouse), null), &objT->GateHouse, state);
        Marshal(node.GetAttributeValue(nameof(BridgeBuilderModuleData.GateHouse2), null), &objT->GateHouse2, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
