using System;

namespace Native.Direct3D9
{
    public partial struct PresentParameters
    {
        public PresentParameters(int backBufferWidth, int backBufferHeight) : this(backBufferWidth,
                                                                                   backBufferHeight,
                                                                                   Format.X8R8G8B8,
                                                                                   1,
                                                                                   MultisampleType.None,
                                                                                   0,
                                                                                   SwapEffect.Discard,
                                                                                   IntPtr.Zero,
                                                                                   true,
                                                                                   true,
                                                                                   Format.D24X8,
                                                                                   PresentFlags.None,
                                                                                   0,
                                                                                   PresentInterval.Default | PresentInterval.Immediate)
        {
        }

        public PresentParameters(int backbufferWidth,
                                 int backBufferHeight,
                                 Format backBufferFormat,
                                 int backBufferCount,
                                 MultisampleType multiSampleType,
                                 int multiSampleQuality,
                                 SwapEffect swapEffect,
                                 IntPtr deviceWindowHandle,
                                 bool windowed,
                                 bool enableAutoDepthStencil,
                                 Format autoDepthStencilFormat,
                                 PresentFlags presentFlags,
                                 int fullScreenRefreshRateInHz,
                                 PresentInterval presentationInterval)
        {
            BackBufferWidth = backbufferWidth;
            BackBufferHeight = backBufferHeight;
            BackBufferFormat = backBufferFormat;
            BackBufferCount = backBufferCount;
            MultiSampleType = multiSampleType;
            MultiSampleQuality = multiSampleQuality;
            SwapEffect = swapEffect;
            DeviceWindowHandle = deviceWindowHandle;
            Windowed = windowed;
            EnableAutoDepthStencil = enableAutoDepthStencil;
            AutoDepthStencilFormat = autoDepthStencilFormat;
            PresentFlags = presentFlags;
            FullScreenRefreshRateInHz = fullScreenRefreshRateInHz;
            PresentationInterval = presentationInterval;
        }

        public void InitializeDefaults()
        {
            BackBufferWidth = 800;
            BackBufferHeight = 600;
            BackBufferFormat = Format.X8R8G8B8;
            BackBufferCount = 1;
            MultiSampleType = MultisampleType.None;
            SwapEffect = SwapEffect.Discard;
            DeviceWindowHandle = IntPtr.Zero;
            Windowed = true;
            EnableAutoDepthStencil = true;
            AutoDepthStencilFormat = Format.D24X8;
            PresentFlags = PresentFlags.None;
            PresentationInterval = PresentInterval.Default | PresentInterval.Immediate;
        }
    }
}
