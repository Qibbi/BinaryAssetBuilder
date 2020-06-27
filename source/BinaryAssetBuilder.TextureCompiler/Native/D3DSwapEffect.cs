namespace Native
{
    public enum D3DSwapEffect
    {
        D3DSWAPEFFECT_DISCARD = 1,
        D3DSWAPEFFECT_FLIP = 2,
        D3DSWAPEFFECT_COPY = 3,

        /* D3D9Ex only -- */
        // #if !defined(D3D_DISABLE_9EX)
        D3DSWAPEFFECT_OVERLAY = 4,
        D3DSWAPEFFECT_FLIPEX = 5,
        // #endif // !D3D_DISABLE_9EX
        /* -- D3D9Ex only */

        D3DSWAPEFFECT_FORCE_DWORD = 0x7fffffff
    }
}
