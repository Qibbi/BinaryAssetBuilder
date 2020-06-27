using System;

namespace Native.Direct3D9
{
    [Flags]
    public enum PresentInterval
    {
        Default,
        One = 0x0001,
        Two = 0x0002,
        Three = 0x0004,
        Four = 0x0008,
        Immediate = unchecked((int)0x80000000)
    }
}
