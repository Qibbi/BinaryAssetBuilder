using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, PlayerPowerManagerBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(PlayerPowerManagerBehaviorModuleData.SpecialPowerTemplate), null), &objT->SpecialPowerTemplate, state);
        Marshal(node, (UpdateModuleData*)objT, state);
    }
}
