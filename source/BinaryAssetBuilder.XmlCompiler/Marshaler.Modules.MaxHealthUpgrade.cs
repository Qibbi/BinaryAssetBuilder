using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MaxHealthUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MaxHealthUpgradeModuleData.AddMaxHealth), "0.0"), &objT->AddMaxHealth, state);
        Marshal(node.GetAttributeValue(nameof(MaxHealthUpgradeModuleData.ChangeType), null), &objT->ChangeType, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
