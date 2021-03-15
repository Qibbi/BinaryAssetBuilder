using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, AudioVoiceEntry* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AudioVoiceEntry.AudioType), null), &objT->AudioType, state);
        Marshal(node, (SoundOrEvaEvent*)objT, state);
    }

    public static unsafe void Marshal(Node node, AudioObjectSpecificVoiceEntry* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AudioObjectSpecificVoiceEntry.AudioType), null), &objT->AudioType, state);
        Marshal(node.GetAttributeValue(nameof(AudioObjectSpecificVoiceEntry.TargetObject), null), &objT->TargetObject, state);
        Marshal(node, (SoundOrEvaEvent*)objT, state);
    }

    public static unsafe void Marshal(Node node, AudioVoiceReferentialEntry* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AudioVoiceReferentialEntry.Name), null), &objT->Name, state);
        Marshal(node, (SoundOrEvaEvent*)objT, state);
    }

    public static unsafe void Marshal(Node node, AudioSoundEntry* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AudioSoundEntry.Sound), null), &objT->Sound, state);
        Marshal(node.GetAttributeValue(nameof(AudioSoundEntry.AudioType), null), &objT->AudioType, state);
    }

    public static unsafe void Marshal(Node node, AudioArrayVoice* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(AudioArrayVoice.AudioEntry)), &objT->AudioEntry, state);
        Marshal(node.GetChildNodes(nameof(AudioArrayVoice.ObjectSpecificEntry)), &objT->ObjectSpecificEntry, state);
        Marshal(node.GetChildNodes(nameof(AudioArrayVoice.NamedEntry)), &objT->NamedEntry, state);
    }

    private static unsafe void Marshal(Node node, AudioArrayVoice** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AudioArrayVoice), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, AudioArraySound* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetChildNodes(nameof(AudioArraySound.AudioEntry)), &objT->AudioEntry, state);
    }

    private static unsafe void Marshal(Node node, AudioArraySound** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AudioArraySound), 1u);
        Marshal(node, *objT, state);
    }
}
