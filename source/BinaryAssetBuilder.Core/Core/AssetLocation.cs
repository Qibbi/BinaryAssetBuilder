using System;

namespace BinaryAssetBuilder.Core
{
    [Flags]
    public enum AssetLocation : ushort
    {
        None = 0,
        Memory = 1 << 0,
        Output = 1 << 1,
        Local = 1 << 2,
        Cache = 1 << 3,
        BasePatchStream = 1 << 4,
        All = 0xFFFF
    }
}