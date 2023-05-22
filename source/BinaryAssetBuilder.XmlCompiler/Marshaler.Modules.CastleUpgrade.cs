using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, CastleUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(CastleUpgradeModuleData.Upgrade), null), &objT->Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(CastleUpgradeModuleData.WallUpgradeRadius), "0"), &objT->WallUpgradeRadius, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
