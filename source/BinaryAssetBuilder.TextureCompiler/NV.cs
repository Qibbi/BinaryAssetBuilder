using System;
using System.Runtime.CompilerServices;

public static class NV
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint CalcMaxMipmap(uint w, uint h)
    {
        uint n = 0u;
        uint count = 0u;
        if (w < 0)
        {
            throw new Exception();
        }
        if (h < 0)
        {
            throw new Exception();
        }
        if (w < h)
        {
            count = h;
        }
        else
        {
            count = w;
        }
        while (count != 0)
        {
            ++n;
            count >>= 1;
        }
        return n;
    }
}
