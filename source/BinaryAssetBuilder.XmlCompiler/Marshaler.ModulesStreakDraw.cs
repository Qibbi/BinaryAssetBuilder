using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, W3DStreakDrawModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(W3DStreakDrawModuleData.Length), "50"), &objT->Length, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreakDrawModuleData.Width), ".5"), &objT->Width, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreakDrawModuleData.Additive), "true"), &objT->Additive, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreakDrawModuleData.NumSegments), "5"), &objT->NumSegments, state);
        Marshal(node.GetAttributeValue(nameof(W3DStreakDrawModuleData.Texture), null), &objT->Texture, state);
        Marshal(node.GetChildNodes(nameof(W3DStreakDrawModuleData.WeatherTexture)), &objT->WeatherTexture, state);
        Marshal(node.GetChildNode(nameof(W3DStreakDrawModuleData.Color), null), &objT->Color, state);
        Marshal(node, (DrawModuleData*)objT, state);
    }
}