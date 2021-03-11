using Relo;
using SageBinaryData;
using AnsiString = Relo.String<sbyte>;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, SoundOrEvaEvent* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SoundOrEvaEvent.Sound), null), &objT->Sound, state);
        Marshal(node.GetAttributeValue(nameof(SoundOrEvaEvent.EvaEvent), null), &objT->EvaEvent, state);
    }

    public static unsafe void Marshal(Node node, SoundOrEvaEvent** objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        using Tracker.Context context = state.Push((void**)objT, (uint)sizeof(AnsiString), 1u);
        Marshal(node, *objT, state);
    }

    public static unsafe void Marshal(Node node, AudioVolumeSliderMultiplier* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AudioVolumeSliderMultiplier.Slider), null), &objT->Slider, state);
        Marshal(node.GetAttributeValue(nameof(AudioVolumeSliderMultiplier.Multiplier), null), &objT->Multiplier, state);
    }

    public static unsafe void Marshal(Node node, BaseAudioEventInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }

    public static unsafe void Marshal(Node node, BaseSingleSound* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.Volume), "100"), &objT->Volume, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.VolumeShift), "0"), &objT->VolumeShift, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.PerFileVolumeShift), "0"), &objT->PerFileVolumeShift, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.MinVolume), "0"), &objT->MinVolume, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.PlayPercent), "100"), &objT->PlayPercent, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.Limit), "0"), &objT->Limit, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.Priority), "NORMAL"), &objT->Priority, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.Type), ""), &objT->Type, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.Control), ""), &objT->Control, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.MinRange), "160"), &objT->MinRange, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.MaxRange), "640"), &objT->MaxRange, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.LowPassCutoff), "0"), &objT->LowPassCutoff, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.ZoomedInOffscreenVolumePercent), "50"), &objT->ZoomedInOffscreenVolumePercent, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.ZoomedInOffscreenMinVolumePercent), "100"), &objT->ZoomedInOffscreenMinVolumePercent, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.ZoomedInOffscreenOcclusionPercent), "20"), &objT->ZoomedInOffscreenOcclusionPercent, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.ReverbEffectLevel), "0"), &objT->ReverbEffectLevel, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.DryLevel), "0"), &objT->DryLevel, state);
        Marshal(node.GetAttributeValue(nameof(BaseSingleSound.SubmixSlider), null), &objT->SubmixSlider, state);
        Marshal(node.GetChildNode(nameof(BaseSingleSound.PitchShift), null), &objT->PitchShift, state);
        Marshal(node.GetChildNode(nameof(BaseSingleSound.PerFilePitchShift), null), &objT->PerFilePitchShift, state);
        Marshal(node.GetChildNode(nameof(BaseSingleSound.Delay), null), &objT->Delay, state);
        Marshal(node.GetChildNodes(nameof(BaseSingleSound.VolumeSliderMultiplier)), &objT->VolumeSliderMultiplier, state);
        Marshal(node, (BaseAudioEventInfo*)objT, state);
    }

    public static unsafe void Marshal(Node node, AudioFileRefWithWeight* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AudioFileRefWithWeight.Weight), "1000"), &objT->Weight, state);
        Marshal(node, (AssetReference<AudioFile>*)objT, state);
    }

    public static unsafe void Marshal(Node node, MultisoundSubsoundRef* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MultisoundSubsoundRef.Weight), "1000"), &objT->Weight, state);
        Marshal(node, (AssetReference<BaseAudioEventInfo, AudioEventInfo>*)objT, state);
    }

    public static unsafe void Marshal(Node node, AudioEvent* objT, Tracker state)
    {
        Marshal(node.GetChildNodes(nameof(AudioEvent.Attack)), &objT->Attack, state);
        Marshal(node.GetChildNodes(nameof(AudioEvent.Sound)), &objT->Sound, state);
        Marshal(node.GetChildNodes(nameof(AudioEvent.Decay)), &objT->Decay, state);
        Marshal(node, (BaseSingleSound*)objT, state);
    }

    public static unsafe void Marshal(Node node, MusicTrack* objT, Tracker state)
    {
        Marshal(node.GetChildNode(nameof(MusicTrack.Filename), null), &objT->Filename, state);
        Marshal(node, (BaseSingleSound*)objT, state);
    }

    public static unsafe void Marshal(Node node, DialogEvent* objT, Tracker state)
    {
        Marshal(node.GetChildNode(nameof(DialogEvent.Filename), null), &objT->Filename, state);
        Marshal(node, (BaseSingleSound*)objT, state);
    }

    public static unsafe void Marshal(Node node, AmbientStream* objT, Tracker state)
    {
        Marshal(node.GetChildNode(nameof(AmbientStream.Filename), null), &objT->Filename, state);
        Marshal(node, (BaseSingleSound*)objT, state);
    }

    public static unsafe void Marshal(Node node, Multisound* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(Multisound.Control), ""), &objT->Control, state);
        Marshal(node.GetChildNodes(nameof(Multisound.Subsound)), &objT->Subsound, state);
        Marshal(node, (BaseAudioEventInfo*)objT, state);
    }
}