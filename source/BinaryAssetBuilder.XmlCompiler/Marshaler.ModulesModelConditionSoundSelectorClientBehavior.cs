using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, ModelConditionSoundSelectorOverrideBlock* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(ModelConditionSoundSelectorOverrideBlock.RequiredFlags), ""), &objT->RequiredFlags, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionSoundSelectorOverrideBlock.ExcludedFlags), ""), &objT->ExcludedFlags, state);
        Marshal(node.GetAttributeValue(nameof(ModelConditionSoundSelectorOverrideBlock.VoicePriorityOverride), null), &objT->VoicePriorityOverride, state);
        Marshal(node.GetChildNode(nameof(ModelConditionSoundSelectorOverrideBlock.AudioArrayVoice), null), &objT->AudioArrayVoice, state);
        Marshal(node.GetChildNode(nameof(ModelConditionSoundSelectorOverrideBlock.AudioArraySound), null), &objT->AudioArraySound, state);
    }

    public static unsafe void Marshal(Node node, ModelConditionSoundSelectorClientBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(ModelConditionSoundSelectorClientBehaviorModuleData.Override)), &objT->Override, state);
        Marshal(node, (ClientBehaviorModuleData*)objT, state);
    }
}
