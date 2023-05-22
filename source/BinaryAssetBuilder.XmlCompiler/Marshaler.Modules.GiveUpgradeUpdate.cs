using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, GiveUpgradeUpdateModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(GiveUpgradeUpdateModuleData.GiveUpgradeEffect), null), &objT->GiveUpgradeEffect, state);
        Marshal(node.GetAttributeValue(nameof(GiveUpgradeUpdateModuleData.SpawnOutFX), null), &objT->SpawnOutFX, state);
        Marshal(node.GetAttributeValue(nameof(GiveUpgradeUpdateModuleData.FadeOutSpeed), "0.025"), &objT->FadeOutSpeed, state);
        Marshal(node.GetAttributeValue(nameof(GiveUpgradeUpdateModuleData.DeliverUpgrade), "false"), &objT->DeliverUpgrade, state);
        Marshal(node, (SpecialAbilityUpdateModuleData*)objT, state);
    }
}
