using System.Runtime.InteropServices;

namespace SageBinaryData
{
    public enum AIDifficulty
    {
        EASY,
        MEDIUM,
        HARD,
        BRUTAL
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AIDifficultyBitFlags
    {
        public const int Count = 0x00000004;
        public const int BitsInSpan = 32;
        public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

        public unsafe fixed uint Value[NumSpans];
    }
}
