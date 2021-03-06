using Relo;
using SageBinaryData;
using SageBinaryData.InGameUI;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentMinimap* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentMinimap.RadarWidth), "128"), &objT->RadarWidth, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMinimap.RadarHeight), "128"), &objT->RadarHeight, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMinimap.AptImageNameTerrain), ""), &objT->AptImageNameTerrain, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMinimap.AptImageNameObjects), ""), &objT->AptImageNameObjects, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMinimap.AptImageNameShroud), ""), &objT->AptImageNameShroud, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMinimap.AptImageNameOrientation), ""), &objT->AptImageNameOrientation, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMinimap.OrientationArrowSize), null), &objT->OrientationArrowSize, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMinimap.OrientationArrowImage), null), &objT->OrientationArrowImage, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentMinimap.StatusTextInfiltration), null), &objT->StatusTextInfiltration, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}