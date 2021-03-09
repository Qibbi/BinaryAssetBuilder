using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UIComponentSpecialPowers* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UIComponentSpecialPowers.PowerTimerImage), null), &objT->PowerTimerImage, state);
        Marshal(node.GetAttributeValue(nameof(UIComponentSpecialPowers.PowerTimerFlashImageName), null), &objT->PowerTimerFlashImageName, state);
        Marshal(node, (UIBaseComponent*)objT, state);
    }
}