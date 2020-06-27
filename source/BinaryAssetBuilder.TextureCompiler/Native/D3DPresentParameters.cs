using System;
using System.Runtime.InteropServices;

namespace Native
{
    [StructLayout(LayoutKind.Sequential, Size = 124)]
    public struct D3DPresentParameters
    {
        public uint BackBufferWidth;
        public uint BackBufferHeight;
        public D3DFormat BackBufferFormat;
        public uint BackBufferCount;

        public D3DMultiSampleType MultiSampleType;
        public int MultiSampleQuality;

        public D3DSwapEffect SwapEffect;
        public IntPtr HDeviceWindow;
        public CBool Windowed;
        public CBool EnableAutoDepthStencil;
        public D3DFormat AutoDepthStencilFormat;
        public int Flags;

        public uint FullScreenRefreshRateInHz;
        public uint PresentationInterval;
    }
}
