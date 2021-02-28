using Relo;
using SageBinaryData;
using AnsiString = Relo.String<sbyte>;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, MicrophoneSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.MicrophonePreferredFractionCameraToGround), "86"), &objT->MicrophonePreferredFractionCameraToGround, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.VolumeMicrophonePullTowardsTerrainLookAtPoint), "60"), &objT->VolumeMicrophonePullTowardsTerrainLookAtPoint, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.PanningMicrophonePullTowardsTerrainLookAtPoint), "60"), &objT->PanningMicrophonePullTowardsTerrainLookAtPoint, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.MicrophoneMinDistanceToCamera), "100"), &objT->MicrophoneMinDistanceToCamera, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.MicrophoneMaxDistanceToCamera), "300"), &objT->MicrophoneMaxDistanceToCamera, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.ZoomMinDistance), "130"), &objT->ZoomMinDistance, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.ZoomMaxDistance), "425"), &objT->ZoomMaxDistance, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.ZoomSoundVolumePercentageAmount), "20"), &objT->ZoomSoundVolumePercentageAmount, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.ZoomFadeDistanceForMaxEffect), "200"), &objT->ZoomFadeDistanceForMaxEffect, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.ZoomFadeZeroEffectEdgeLength), "260"), &objT->ZoomFadeZeroEffectEdgeLength, state);
        Marshal(node.GetAttributeValue(nameof(MicrophoneSettings.ZoomFadeFullEffectEdgeLength), "135"), &objT->ZoomFadeFullEffectEdgeLength, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }

    public static unsafe void Marshal(Node node, VolumeCompressionSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(VolumeCompressionSettings.Threshold), "20"), &objT->Threshold, state);
        Marshal(node.GetAttributeValue(nameof(VolumeCompressionSettings.Ratio), "10"), &objT->Ratio, state);
        Marshal(node.GetAttributeValue(nameof(VolumeCompressionSettings.AttackTime), "100ms"), &objT->AttackTime, state);
        Marshal(node.GetAttributeValue(nameof(VolumeCompressionSettings.ReleaseTime), "500ms"), &objT->ReleaseTime, state);
        Marshal(node.GetAttributeValue(nameof(VolumeCompressionSettings.AppliesEquallyToAllChannels), "true"), &objT->AppliesEquallyToAllChannels, state);
    }

    public static unsafe void Marshal(Node node, AudioSettings* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(AudioSettings.StreamBufferSizePerChannel), "65536"), &objT->StreamBufferSizePerChannel, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.MaxRequestsPerStream), "4"), &objT->MaxRequestsPerStream, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.ForceResetTime), "0s"), &objT->ForceResetTime, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.EmergencyResetTime), "0s"), &objT->EmergencyResetTime, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.SuppressOcclusion), "false"), &objT->SuppressOcclusion, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.MinOcclusion), "0"), &objT->MinOcclusion, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.DelayPriorToPlayingToReadSoundFile), "1s"), &objT->DelayPriorToPlayingToReadSoundFile, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.ReadAheadTime), "3s"), &objT->ReadAheadTime, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.QueueAheadTime), ".5s"), &objT->QueueAheadTime, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.LongTime), "60s"), &objT->LongTime, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.AudioFootprintInBytes), "4194304"), &objT->AudioFootprintInBytes, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.DefaultSoundVolume), "100"), &objT->DefaultSoundVolume, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.DefaultVoiceVolume), "100"), &objT->DefaultVoiceVolume, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.DefaultMusicVolume), "100"), &objT->DefaultMusicVolume, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.DefaultMovieVolume), "100"), &objT->DefaultMovieVolume, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.DefaultAmbientVolume), "100"), &objT->DefaultAmbientVolume, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.AutomaticSubtitleDuration), "8s"), &objT->AutomaticSubtitleDuration, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.AutomaticSubtitleLines), "8"), &objT->AutomaticSubtitleLines, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.PanRadiusScaleValue), "1.0"), &objT->PanRadiusScaleValue, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.PanSize), "1.0"), &objT->PanSize, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.MinSampleVolume), "0.01"), &objT->MinSampleVolume, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.PositionDeltaForReverbCheck), "10.0"), &objT->PositionDeltaForReverbCheck, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.TimeToFadeAudio), "1s"), &objT->TimeToFadeAudio, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.AmbientStreamHysteresisVolume), "5"), &objT->AmbientStreamHysteresisVolume, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.VolumeMultiplierFor2DSounds), "100%"), &objT->VolumeMultiplierFor2DSounds, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.VoiceMoveToCampMaxCampnessAtStartPoint), "0"), &objT->VoiceMoveToCampMaxCampnessAtStartPoint, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.VoiceMoveToCampMinCampnessAtEndPoint), "5"), &objT->VoiceMoveToCampMinCampnessAtEndPoint, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.MinDelayBetweenEnterStateVoice), "5s"), &objT->MinDelayBetweenEnterStateVoice, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.TimeSinceLastAttackForVoiceRetreatToCastle), "3s"), &objT->TimeSinceLastAttackForVoiceRetreatToCastle, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.DistanceToLookForEnemiesForVoiceRetreatToCastle), "500"), &objT->DistanceToLookForEnemiesForVoiceRetreatToCastle, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.PostPostGameMusicWait), "10s"), &objT->PostPostGameMusicWait, state);
        Marshal(node.GetAttributeValue(nameof(AudioSettings.PlayEnemySightedEventsOnlyFromNearbyUnits), "false"), &objT->PlayEnemySightedEventsOnlyFromNearbyUnits, state);
        Marshal(node.GetChildNode(nameof(AudioSettings.AutomaticSubtitleWindowColor), null), &objT->AutomaticSubtitleWindowColor, state);
        Marshal(node.GetChildNode(nameof(AudioSettings.AutomaticSubtitleTextColor), null), &objT->AutomaticSubtitleTextColor, state);
        Marshal(node.GetChildNodes(nameof(AudioSettings.VolumeSliderMultiplierForMovie)), &objT->VolumeSliderMultiplierForMovie, state);
        Marshal(node.GetChildNode(nameof(AudioSettings.TacticalMicSettings), null), &objT->TacticalMicSettings, state);
        Marshal(node.GetChildNode(nameof(AudioSettings.LivingWorldMicSettings), null), &objT->LivingWorldMicSettings, state);
        Marshal(node.GetChildNode(nameof(AudioSettings.ShellMicSettings), null), &objT->ShellMicSettings, state);
        Marshal(node.GetChildNode(nameof(AudioSettings.VolumeCompressorSettings), null), &objT->VolumeCompressorSettings, state);
        Marshal(node, (BaseAssetType*)objT, state);
    }
}