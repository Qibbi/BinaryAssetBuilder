using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CaptureAndGiveCommandSetSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CaptureAndGiveCommandSetSpecialPowerModuleData.CommandSet), null), &objT->CommandSet, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
