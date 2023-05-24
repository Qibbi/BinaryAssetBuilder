using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SalvageCrateCollideModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SalvageCrateCollideModuleData.PorterChance), "0"), &objT->PorterChance, state);
        Marshal(node.GetAttributeValue(nameof(SalvageCrateCollideModuleData.BannerChance), "0"), &objT->BannerChance, state);
        Marshal(node.GetAttributeValue(nameof(SalvageCrateCollideModuleData.LevelUpChance), "0"), &objT->LevelUpChance, state);
        Marshal(node.GetAttributeValue(nameof(SalvageCrateCollideModuleData.LevelUpRadius), "0"), &objT->LevelUpRadius, state);
        Marshal(node.GetAttributeValue(nameof(SalvageCrateCollideModuleData.ResourceChance), "0"), &objT->ResourceChance, state);
        Marshal(node.GetAttributeValue(nameof(SalvageCrateCollideModuleData.MinimumResource), "0"), &objT->MinimumResource, state);
        Marshal(node.GetAttributeValue(nameof(SalvageCrateCollideModuleData.MaximumResource), "0"), &objT->MaximumResource, state);
        Marshal(node.GetAttributeValue(nameof(SalvageCrateCollideModuleData.Upgrade), null), &objT->Upgrade, state);
        Marshal(node.GetAttributeValue(nameof(SalvageCrateCollideModuleData.AllowAIPickup), "false"), &objT->AllowAIPickup, state);
        Marshal(node, (CrateCollideModuleData*)objT, state);
    }
}
