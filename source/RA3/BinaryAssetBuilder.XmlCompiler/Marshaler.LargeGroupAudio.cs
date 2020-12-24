using Relo;
using SageBinaryData;

public static partial class Marshaler
{
    public static unsafe void Marshal(Node node, DuckInfo* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(DuckInfo.AudioMap), null), &objT->AudioMap, state);
        Marshal(node.GetAttributeValue(nameof(DuckInfo.SoundRef), null), &objT->SoundRef, state);
        Marshal(node.GetAttributeValue(nameof(DuckInfo.VolumeMultiplier), null), &objT->VolumeMultiplier, state);
    }

    public static unsafe void Marshal(Node node, SoundKeyPair* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(SoundKeyPair.Name), null), &objT->Name, state);
        Marshal(node.GetAttributeValue(nameof(SoundKeyPair.Sound), "0"), &objT->Sound, state);
        Marshal(node.GetChildNodes(nameof(SoundKeyPair.Key)), &objT->Key, state);
        Marshal(node.GetChildNodes(nameof(SoundKeyPair.Duck)), &objT->Duck, state);
    }

    public static unsafe void Marshal(Node node, LargeGroupAudioMap* objT, Tracker state)
    {
        if (node is null)
        {
            return;
        }
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.RequiredModelConditionFlags), null), &objT->RequiredModelConditionFlags, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.ExcludedModelConditionFlags), null), &objT->ExcludedModelConditionFlags, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.RequiredObjectStatusBits), null), &objT->RequiredObjectStatusBits, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.ExcludedObjectStatusBits), null), &objT->ExcludedObjectStatusBits, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.Size), "10000"), &objT->Size, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.StartThreshold), "0"), &objT->StartThreshold, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.StopThreshold), "0"), &objT->StopThreshold, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.HandOffModeTime), "0s"), &objT->HandOffModeTime, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.MaximumAudioSpeed), "0"), &objT->MaximumAudioSpeed, state);
        Marshal(node.GetAttributeValue(nameof(LargeGroupAudioMap.IgnoreStealthedUnits), "true"), &objT->IgnoreStealthedUnits, state);
        Marshal(node.GetChildNodes(nameof(LargeGroupAudioMap.Sound)), &objT->Sound, state);
        Marshal(node, (BaseInheritableAsset*)objT, state);
    }
}
