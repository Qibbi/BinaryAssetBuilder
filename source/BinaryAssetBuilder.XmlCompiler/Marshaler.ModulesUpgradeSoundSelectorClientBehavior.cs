using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, UpgradeSoundSelectorOverrideBlock* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(UpgradeSoundSelectorOverrideBlock.RequiredModelConditions), ""), &objT->RequiredModelConditions, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeSoundSelectorOverrideBlock.ConflictingModelConditions), ""), &objT->ConflictingModelConditions, state);
        Marshal(node.GetAttributeValue(nameof(UpgradeSoundSelectorOverrideBlock.VoicePriorityOverride), null), &objT->VoicePriorityOverride, state);
        Marshal(node.GetChildNode(nameof(UpgradeSoundSelectorOverrideBlock.AudioArrayVoice), null), &objT->AudioArrayVoice, state);
        Marshal(node.GetChildNode(nameof(UpgradeSoundSelectorOverrideBlock.AudioArraySound), null), &objT->AudioArraySound, state);
        Marshal(node.GetChildNodes(nameof(UpgradeSoundSelectorOverrideBlock.RequiredUpgrade)), &objT->RequiredUpgrade, state);
        Marshal(node.GetChildNodes(nameof(UpgradeSoundSelectorOverrideBlock.ConflictingUpgrade)), &objT->ConflictingUpgrade, state);
    }

    public static unsafe void Marshal(Node node, UpgradeSoundSelectorClientBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(UpgradeSoundSelectorClientBehaviorModuleData.Override)), &objT->Override, state);
        Marshal(node, (ClientBehaviorModuleData*)objT, state);
    }
}
