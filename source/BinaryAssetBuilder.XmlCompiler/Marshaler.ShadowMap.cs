using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ShadowMap* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ShadowMap.MapSize), "1024"), &objT->MapSize, state);
        Marshal(node.GetAttributeValue(nameof(ShadowMap.MaxViewDistance), "1000.0"), &objT->MaxViewDistance, state);
        Marshal(node.GetAttributeValue(nameof(ShadowMap.MinShadowedTerrainHeight), "0.0"), &objT->MinShadowedTerrainHeight, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}