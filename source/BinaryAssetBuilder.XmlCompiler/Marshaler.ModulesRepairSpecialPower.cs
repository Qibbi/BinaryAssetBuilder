using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RepairSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
