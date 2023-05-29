using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ProductionSpeedBonusUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ProductionSpeedBonusUpgradeModuleData.Frames), "0"), &objT->Frames, state);
        Marshal(node.GetAttributeValue(nameof(ProductionSpeedBonusUpgradeModuleData.Bonus), "0"), &objT->Bonus, state);
        Marshal(node.GetAttributeValue(nameof(ProductionSpeedBonusUpgradeModuleData.Template), "0"), &objT->Template, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
