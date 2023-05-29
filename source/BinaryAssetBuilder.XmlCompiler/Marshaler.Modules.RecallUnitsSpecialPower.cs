using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RecallUnitsSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RecallUnitsSpecialPowerModuleData.PlayReturnVoiceFromRecalledUnit), "true"), &objT->PlayReturnVoiceFromRecalledUnit, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
