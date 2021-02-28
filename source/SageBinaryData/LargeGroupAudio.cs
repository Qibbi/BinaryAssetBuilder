using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DuckInfo
    {
        public AssetReference<BaseAssetType> AudioMap; // should be AssetReference<LargeGroupAudioMap> but .net thinks it might be a circular reference
        public TypedAssetId<BaseAssetType> SoundRef; // should be TypedAssetId<SoundKeyPair> but .net thinks it might be a circular reference
        public Percentage VolumeMultiplier;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SoundKeyPair
    {
        public TypedAssetId<BaseAssetType> Name; // should be TypedAssetId<SoundKeyPair> but .net thinks it might be a circular reference
        public unsafe AssetReference<BaseAudioEventInfo, AudioEventInfo> Sound;
        public List<StringHash> Key;
        public List<DuckInfo> Duck;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LargeGroupAudioMap
    {
        public BaseInheritableAsset Base;
        public unsafe ModelConditionBitFlags* RequiredModelConditionFlags;
        public unsafe ModelConditionBitFlags* ExcludedModelConditionFlags;
        public unsafe ObjectStatusBitFlags* RequiredObjectStatusBits;
        public unsafe ObjectStatusBitFlags* ExcludedObjectStatusBits;
        public uint Size;
        public Time HandOffModeTime;
        public Velocity MaximumAudioSpeed;
        public List<SoundKeyPair> Sound;
        public ushort StartThreshold;
        public ushort StopThreshold;
        public SageBool IgnoreStealthedUnits;
    }
}
