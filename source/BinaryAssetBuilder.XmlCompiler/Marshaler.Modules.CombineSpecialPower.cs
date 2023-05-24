using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CombineSpecialPowerModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNode(nameof(CombineSpecialPowerModuleData.CombineWithObjectFilter), null), &objT->CombineWithObjectFilter, state);
        Marshal(node, (SpecialPowerModuleData*)objT, state);
    }
}
