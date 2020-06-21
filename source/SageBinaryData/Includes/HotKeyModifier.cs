using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum HotKeyModifier
    {
        CTRL,
        ALT,
        SHIFT
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HotKeyModifierFlags
    {
        public const int Count = 3;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }
}
