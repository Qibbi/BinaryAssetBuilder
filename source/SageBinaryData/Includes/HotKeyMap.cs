using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HotKeyDef
    {
        public AssetReference<HotKeySlot> Slot;
        public AssetReference<MappableKey> Key;
        public HotKeyModifierFlags Modifiers;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HotKeyMap
    {
        public List<HotKeyDef> HotKey;
    }
}
