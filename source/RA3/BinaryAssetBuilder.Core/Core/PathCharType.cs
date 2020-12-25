using System;

namespace BinaryAssetBuilder.Core
{
    [Flags]
    public enum PathCharType
    {
        Invalid = 0,
        ValidLongFileNameChar = 1 << 0,
        ValidShortFileNameChar = 1 << 1,
        Wildcard = 1 << 2,
        Separator = 1 << 3
    }
}
