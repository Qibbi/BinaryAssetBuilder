using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, Mouse* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(Mouse.TooltipFontName), null), &objT->TooltipFontName, state);
        Marshal(node.GetChildNode(nameof(Mouse.TooltipFontSize), null), &objT->TooltipFontSize, state);
        Marshal(node.GetChildNode(nameof(Mouse.TooltipFontIsBold), null), &objT->TooltipFontIsBold, state);
        Marshal(node.GetChildNode(nameof(Mouse.TooltipDelayTime), null), &objT->TooltipDelayTime, state);
        Marshal(node.GetChildNode(nameof(Mouse.TooltipTextColor), null), &objT->TooltipTextColor, state);
        Marshal(node.GetChildNode(nameof(Mouse.UseTooltipAltTextColor), null), &objT->UseTooltipAltTextColor, state);
        Marshal(node.GetChildNode(nameof(Mouse.AdjustTooltipAltColor), null), &objT->AdjustTooltipAltColor, state);
        Marshal(node.GetChildNode(nameof(Mouse.OrthoCamera), null), &objT->OrthoCamera, state);
        Marshal(node.GetChildNode(nameof(Mouse.OrthoZoom), null), &objT->OrthoZoom, state);
        Marshal(node.GetChildNode(nameof(Mouse.DragTolerance), null), &objT->DragTolerance, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}