using System;
using System.ComponentModel;

namespace BinaryAssetBuilder.Core.Diagnostics
{
    [Flags]
    public enum TraceEventType
    {
        Critical = 1 << 0,
        Error = 1 << 1,
        Warning = 1 << 2,
        Information = 1 << 3,
        Verbose = 1 << 4,
        [EditorBrowsable(EditorBrowsableState.Advanced)] Start = 1 << 8,
        [EditorBrowsable(EditorBrowsableState.Advanced)] Stop = 1 << 9,
        [EditorBrowsable(EditorBrowsableState.Advanced)] Suspend = 1 << 10,
        [EditorBrowsable(EditorBrowsableState.Advanced)] Resume = 1 << 11,
        [EditorBrowsable(EditorBrowsableState.Advanced)] Transfer = 1 << 12
    }
}
