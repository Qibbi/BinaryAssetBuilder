using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, HealContainModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(HealContainModuleData.TimeForFullHeal), null), &objT->TimeForFullHeal, state);
        Marshal(node, (HordeGarrisonContainModuleData*)objT, state);
    }
}
