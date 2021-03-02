using System;

namespace BinaryAssetBuilder.Core.Diagnostics
{
    [Flags]
    public enum TraceKind : ushort
    {
        None = 0,
        Exception = 1 << 0,
        Assert = 1 << 1,
        Error = 1 << 2,
        Warning = 1 << 3,
        Message = 1 << 4,
        Info = 1 << 5,
        Note = 1 << 8,
        Method = 1 << 9,
        Scope = 1 << 10,
        Constructor = 1 << 11,
        Property = 1 << 12,
        Data = 1 << 13,
        All = 0xFFFF
    }
}
