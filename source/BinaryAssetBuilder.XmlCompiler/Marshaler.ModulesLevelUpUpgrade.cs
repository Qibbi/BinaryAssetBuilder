using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, LevelUpUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LevelUpUpgradeModuleData.LevelsToGain), "0"), &objT->LevelsToGain, state);
        Marshal(node.GetAttributeValue(nameof(LevelUpUpgradeModuleData.LevelCap), "0"), &objT->LevelCap, state);
        Marshal(node.GetAttributeValue(nameof(LevelUpUpgradeModuleData.DoFlash), "true"), &objT->DoFlash, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
