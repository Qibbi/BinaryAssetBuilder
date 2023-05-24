using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HordeDispatchSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
#if KANESWRATH
        Marshal(node.GetAttributeValue(nameof(HordeDispatchSpecialPowerModuleData.MaxMembersToDispatchTo), "99"), &objT->MaxMembersToDispatchTo, state);
#endif
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
