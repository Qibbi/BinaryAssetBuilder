using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, RandomSoundSelectorClientBehaviorModuleData* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(RandomSoundSelectorClientBehaviorModuleData.Chance), "50"), &objT->Chance, state);
        Marshal(node.GetAttributeValue(nameof(RandomSoundSelectorClientBehaviorModuleData.VoicePriorityOverride), null), &objT->VoicePriorityOverride, state);
        Marshal(node.GetAttributeValue(nameof(RandomSoundSelectorClientBehaviorModuleData.RerollOnEveryFrame), "false"), &objT->RerollOnEveryFrame, state);
        Marshal(node.GetChildNode(nameof(RandomSoundSelectorClientBehaviorModuleData.AudioArrayVoice), null), &objT->AudioArrayVoice, state);
        Marshal(node.GetChildNode(nameof(RandomSoundSelectorClientBehaviorModuleData.AudioArraySound), null), &objT->AudioArraySound, state);
        Marshal(node, (ClientBehaviorModuleData*)objT, state);
    }
}
