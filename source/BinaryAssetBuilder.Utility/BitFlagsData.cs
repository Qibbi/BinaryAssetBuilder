
// Has to be copied as C# doesn't have something like value parameters for Generics

// public struct BitFlags<uint Count, T> where T : unmanaged
// {
//     public const int BitsInSpan = 32;
//     public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;
// 
//     public unsafe fixed uint Value[NumSpans];
// }

/*
public struct TBitFlags
{
    public const int Count = 0x00000000;
    public const int BitsInSpan = 32;
    public const int NumSpans = (Count + (BitsInSpan - 1)) / BitsInSpan;

    public unsafe fixed uint Value[NumSpans];
}
*/
