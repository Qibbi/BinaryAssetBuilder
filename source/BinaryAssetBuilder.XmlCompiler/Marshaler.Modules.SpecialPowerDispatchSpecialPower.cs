using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DispatchSpecialPowerType* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DispatchSpecialPowerType.SpecialPowerTemplate), null), &objT->SpecialPowerTemplate, state);
    }

    public static unsafe void Marshal(Node node, SpecialPowerDispatchSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SpecialPowerDispatchSpecialPowerModuleData.RequireAllPowersToFunction), "false"), &objT->RequireAllPowersToFunction, state);
        Marshal(node.GetChildNodes(nameof(SpecialPowerDispatchSpecialPowerModuleData.SpecialPower)), &objT->SpecialPower, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
