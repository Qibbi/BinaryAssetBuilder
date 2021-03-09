using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentTickerGroup* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentTickerGroup.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentTickerGroup.HTTPAddress), null), &objT->HTTPAddress, state);
    }

    public static unsafe void Marshal(Node node, UIComponentTicker* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentTicker.CustomRenderName), null), &objT->CustomRenderName, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentTicker.NumberOfTickerDisplays), null), &objT->NumberOfTickerDisplays, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentTicker.ScrollSpeedPixelPerSec), null), &objT->ScrollSpeedPixelPerSec, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentTicker.NumberOfPixelsBetweenHeadline), null), &objT->NumberOfPixelsBetweenHeadline, state);
        Marshal(node.GetChildNode(nameof(UIComponentTicker.TickerColor), null), &objT->TickerColor, state);
        Marshal(node.GetChildNodes(nameof(UIComponentTicker.TickerGroup)), &objT->TickerGroup, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}