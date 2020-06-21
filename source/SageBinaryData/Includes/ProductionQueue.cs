using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum ProductionQueueType
    {
        INVALID = -1,
        MAIN_STRUCTURE,
        OTHER_STRUCTURE,
        INFANTRY,
        VEHICLE,
        AIRCRAFT,
        UPGRADE,
        SPECIALPOWERS,
        BOOKMARKS
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProductionQueueTypeBitFlags
    {
        public const int Count = 7;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }
}
