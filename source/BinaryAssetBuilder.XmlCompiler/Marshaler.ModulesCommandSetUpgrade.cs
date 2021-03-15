using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CommandSetUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CommandSetUpgradeModuleData.CommandSet), null), &objT->CommandSet, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
