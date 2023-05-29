using System.Runtime.InteropServices;

namespace SageBinaryData;

public enum ShroudClearOptionsType
{
    REQUIRES_FUNCTIONING_RADAR,
    REQUIRES_MULTIPLAYER,
    REVEAL_FOR_ALLIES
}

[StructLayout(LayoutKind.Sequential)]
public struct ShroudClearOptionsBitFlags
{
    public const int Count = 3;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}

[StructLayout(LayoutKind.Sequential)]
public struct ShroudClearBehaviorModuleData
{
    public UpdateModuleData Base;
    public ShroudClearOptionsBitFlags ShroudClearOptions;
}
