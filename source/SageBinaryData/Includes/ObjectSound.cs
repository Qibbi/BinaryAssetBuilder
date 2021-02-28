using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioVoiceEntry
    {
        public SoundOrEvaEvent Base;
        public ThingTemplateVoiceType AudioType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioObjectSpecificVoiceEntry
    {
        public SoundOrEvaEvent Base;
        public ThingTemplateObjectSpecificVoiceType AudioType;
        public TypedAssetId<GameObject> TargetObject;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioVoiceReferentialEntry
    {
        public SoundOrEvaEvent Base;
        public StringHash Name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioSoundEntry
    {
        public AssetReference<BaseAudioEventInfo, AudioEventInfo> Sound;
        public ThingTemplateSoundType AudioType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioArrayVoice
    {
        public List<AudioVoiceEntry> AudioEntry;
        public List<AudioObjectSpecificVoiceEntry> ObjectSpecificEntry;
        public List<AudioVoiceReferentialEntry> NamedEntry;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioArraySound
    {
        public List<AudioSoundEntry> AudioEntry;
    }
}
