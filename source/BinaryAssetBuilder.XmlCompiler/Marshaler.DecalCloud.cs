using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, InGameUIDecalCloudSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(InGameUIDecalCloudSettings.BuildTexture), null), &objT->BuildTexture, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIDecalCloudSettings.DefenseTexture), null), &objT->DefenseTexture, state);
        Marshal(node.GetAttributeValue(nameof(InGameUIDecalCloudSettings.SpecialPowerRestrictionTexture), null), &objT->SpecialPowerRestrictionTexture, state);
    }
}