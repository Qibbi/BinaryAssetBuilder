using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIVoiceChatCommandSlots
    {
        public BaseAssetType Base;
        public AssetReference<HotKeySlot> ToggleVoiceChatMode;
        public AssetReference<HotKeySlot> VoiceChat;
    }
}
