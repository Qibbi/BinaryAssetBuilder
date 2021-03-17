using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SubObjectsUpgradeModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SubObjectsUpgradeModuleData.ShowSubObjects), null), &objT->ShowSubObjects, state);
        Marshal(node.GetAttributeValue(nameof(SubObjectsUpgradeModuleData.HideSubObjects), null), &objT->HideSubObjects, state);
        Marshal(node.GetAttributeValue(nameof(SubObjectsUpgradeModuleData.FadeTimeInSeconds), "0.5"), &objT->FadeTimeInSeconds, state);
        Marshal(node.GetAttributeValue(nameof(SubObjectsUpgradeModuleData.WaitBeforeFadeInSeconds), "0.0"), &objT->WaitBeforeFadeInSeconds, state);
        Marshal(node.GetAttributeValue(nameof(SubObjectsUpgradeModuleData.RecolorHouse), "false"), &objT->RecolorHouse, state);
        Marshal(node.GetAttributeValue(nameof(SubObjectsUpgradeModuleData.ExcludeSubobjects), null), &objT->ExcludeSubobjects, state);
        Marshal(node.GetAttributeValue(nameof(SubObjectsUpgradeModuleData.SkipFadeOnCreate), "false"), &objT->SkipFadeOnCreate, state);
        Marshal(node.GetAttributeValue(nameof(SubObjectsUpgradeModuleData.HideSubObjectsOnRemove), "false"), &objT->HideSubObjectsOnRemove, state);
        Marshal(node.GetAttributeValue(nameof(SubObjectsUpgradeModuleData.UnHideSubObjectsOnRemove), "false"), &objT->UnHideSubObjectsOnRemove, state);
        Marshal(node.GetChildNodes(nameof(SubObjectsUpgradeModuleData.UpgradeTexture)), &objT->UpgradeTexture, state);
        Marshal(node, (UpgradeModuleData*)objT, state);
    }
}
