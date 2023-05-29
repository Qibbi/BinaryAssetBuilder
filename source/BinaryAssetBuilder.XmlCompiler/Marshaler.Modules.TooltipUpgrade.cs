#if TIBERIUMWARS
using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, TooltipUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(TooltipUpgradeModuleData.NewDisplayName), null), &objT->NewDisplayName, state);
        Marshal(node.GetAttributeValue(nameof(TooltipUpgradeModuleData.NewDescription), null), &objT->NewDescription, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
#endif
