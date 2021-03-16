using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MoneyCrateCollideModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MoneyCrateCollideModuleData.MoneyProvided), "0"), &objT->MoneyProvided, state);
        Marshal(node, (CrateCollideModuleData*)objT, state);
    }
}
