using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIFixedElementHotKeySlotMapEntry
    {
        public UIFixedElementId ElementId;
        public AssetReference<HotKeySlot> HotKeySlot;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUIFixedElementHotKeySlotMap
    {
        public BaseAssetType Base;
        public List<InGameUIFixedElementHotKeySlotMapEntry> Entry;
    }
}
