using System;
using System.Runtime.InteropServices;

namespace Native.Direct3D9
{
    public enum SwapEffect
    {
        Discard = 1,
        Flip,
        Copy,
        Overlay,
        FlipEx
    }

    [Flags]
    public enum PresentFlags
    {
        None,
        LoackableBackBuffer = 0x0001,
        DiscardDepthStencil = 0x0002,
        DeviceClip = 0x0004,
        Video = 0x0010,
        NoAutoRotate = 0x0020,
        UnprunedMode = 0x0040,
        OverlayLimtedRgb = 0x0080,
        OverlayYCbCrBt709 = 0x0100,
        OverlayYCbCrXvYCC = 0x0200,
        RestrictedContent = 0x0400,
        RestrictedSharedResourceDriver = 0x0800
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct PresentParameters
    {
        public int BackBufferWidth;
        public int BackBufferHeight;
        public Format BackBufferFormat;
        public int BackBufferCount;
        public MultisampleType MultiSampleType;
        public int MultiSampleQuality;
        public SwapEffect SwapEffect;
        public IntPtr DeviceWindowHandle;
        public CBool Windowed;
        public CBool EnableAutoDepthStencil;
        public Format AutoDepthStencilFormat;
        public PresentFlags PresentFlags;
        public int FullScreenRefreshRateInHz;
        public PresentInterval PresentationInterval;
    }
}
