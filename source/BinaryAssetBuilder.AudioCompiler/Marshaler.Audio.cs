using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Value value, SageBool** objT, Tracker state)
    {
        if (value is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)&objT, (uint)sizeof(SageBool), 1u);
        Marshal(value, *objT, state);
    }

    public static unsafe void Marshal(Node node, AudioFile* objT, Tracker state)
    {
        Marshal(node.GetAttributeValue(nameof(AudioFile.File), null), &objT->File, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.PCSampleRate), null), &objT->PCSampleRate, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.PCCompression), null), &objT->PCCompression, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.PCQuality), "75"), &objT->PCQuality, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.IsStreamedOnPC), null), &objT->IsStreamedOnPC, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.XenonSampleRate), null), &objT->XenonSampleRate, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.XenonCompression), null), &objT->XenonCompression, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.XenonQuality), "75"), &objT->XenonQuality, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.IsStreamedOnXenon), null), &objT->IsStreamedOnXenon, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.SubtitleStringName), null), &objT->SubtitleStringName, state);
        Marshal(node.GetAttributeValue(nameof(AudioFile.GUIPreset), null), &objT->GUIPreset, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, AudioFileMP3Passthrough* objT, Tracker state)
    {
        Marshal(node.GetAttributeValue(nameof(AudioFileMP3Passthrough.File), null), &objT->File, state);
        Marshal(node.GetAttributeValue(nameof(AudioFileMP3Passthrough.SubtitleStringName), null), &objT->SubtitleStringName, state);
        Marshal(node.GetAttributeValue(nameof(AudioFileMP3Passthrough.IsStreamed), "true"), &objT->IsStreamed, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}