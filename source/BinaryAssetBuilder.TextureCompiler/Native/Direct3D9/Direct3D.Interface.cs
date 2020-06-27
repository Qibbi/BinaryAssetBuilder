using System;
using System.Runtime.InteropServices;

namespace Native.Direct3D9
{
    [Guid("81BDCBCA-64D4-426d-AE8D-AD0147F4275C")]
    public partial class Direct3D : ComObject
    {
        public int AdapterCount => GetAdapterCount_();

        public Direct3D(IntPtr nativePtr) : base(nativePtr)
        {
        }

        public static explicit operator Direct3D(IntPtr nativePtr)
        {
            return nativePtr == IntPtr.Zero ? null : new Direct3D(nativePtr);
        }

        internal unsafe int GetAdapterCount_()
        {
            return LocalInterop.Calliint(_nativePointer, ((void**)*(void**)_nativePointer)[4]);
        }

        internal unsafe AdapterDetails GetAdapterIdentifier(int adapter, int flags)
        {
            AdapterDetails adapterDetails;
            AdapterDetails.Native native = new AdapterDetails.Native();
            Result result = LocalInterop.Calliint(_nativePointer, adapter, flags, &native, ((void**)*(void**)_nativePointer)[5]);
            adapterDetails = new AdapterDetails();
            adapterDetails.MarshalFrom(ref native);
            result.CheckError();
            return adapterDetails;
        }

        internal unsafe Result CheckDeviceType_(int adapter, DeviceType deviceType, Format adapterFormat, Format backBufferFormat, CBool isWindowed)
        {
            return LocalInterop.Calliint(_nativePointer, adapter, (int)deviceType, (int)adapterFormat, (int)backBufferFormat, (int)isWindowed, ((void**)*(void**)_nativePointer)[9]);
        }

        internal unsafe Result CheckDeviceFormat_(int adapter, DeviceType deviceType, Format adapterFormat, int usage, ResourceType resourceType, Format checkFormat)
        {
            return LocalInterop.Calliint(_nativePointer, adapter, (int)deviceType, (int)adapterFormat, usage, (int)resourceType, (int)checkFormat, ((void**)*(void**)_nativePointer)[10]);
        }

        internal unsafe Result CheckDeviceMultiSampleType_(int adapter, DeviceType deviceType, Format surfaceFormat, CBool isWindowed, MultisampleType multisampleType, out int qualityLevels)
        {
            fixed (void* pQualityLevels = &qualityLevels)
            {
                return LocalInterop.Calliint(_nativePointer, adapter, (int)deviceType, (int)surfaceFormat, (int)isWindowed, (int)multisampleType, pQualityLevels, ((void**)*(void**)_nativePointer)[11]);
            }
        }

        internal unsafe Result CheckDepthStencilMatch_(int adapter, DeviceType deviceType, Format adapterFormat, Format renderTargetFormat, Format depthStencilFormat)
        {
            return LocalInterop.Calliint(_nativePointer, adapter, (int)deviceType, (int)adapterFormat, (int)renderTargetFormat, (int)depthStencilFormat, ((void**)*(void**)_nativePointer)[12]);
        }

        internal unsafe Result CheckDeviceFormatConversion_(int adapter, DeviceType deviceType, Format sourceFormat, Format targetFormat)
        {
            return LocalInterop.Calliint(_nativePointer, adapter, (int)deviceType, (int)sourceFormat, (int)targetFormat, ((void**)*(void**)_nativePointer)[13]);
        }

        internal unsafe void CreateDevice_(int adapter, DeviceType deviceType, IntPtr hFocusWindow, CreateFlags behaviorFlags, PresentParameters[] presentParameters, Device resultDevice)
        {
            IntPtr resultPtr;
            Result result;
            fixed (void* pPresentParameters = &presentParameters[0])
            {
                result = LocalInterop.Calliint(_nativePointer, adapter, (int)deviceType, (void*)hFocusWindow, (int)behaviorFlags, pPresentParameters, &resultPtr, ((void**)*(void**)_nativePointer)[16]);
            }
            resultDevice.NativePointer = resultPtr;
            result.CheckError();
        }

        public unsafe void RegisterSoftwareDevice(IntPtr initializeCallback)
        {
            Result result = LocalInterop.Calliint(_nativePointer, (void*)initializeCallback, ((void**)*(void**)_nativePointer)[3]);
            result.CheckError();
        }

        public unsafe int GetAdapterModeCount(int adapter, Format format)
        {
            return LocalInterop.Calliint(_nativePointer, adapter, (int)format, ((void**)*(void**)_nativePointer)[6]);
        }

        public unsafe DisplayMode EnumAdapterModes(int adapter, Format format, int mode)
        {
            DisplayMode displayMode = new DisplayMode();
            Result result = LocalInterop.Calliint(_nativePointer, adapter, (int)format, mode, &displayMode, ((void**)*(void**)_nativePointer)[7]);
            result.CheckError();
            return displayMode;
        }

        public unsafe DisplayMode GetAdapterDisplayMode(int adapter)
        {
            DisplayMode displayMode = new DisplayMode();
            Result result = LocalInterop.Calliint(_nativePointer, adapter, &displayMode, ((void**)*(void**)_nativePointer)[8]);
            result.CheckError();
            return displayMode;
        }

        public unsafe Capabilities GetDeviceCaps(int adapter, DeviceType deviceType)
        {
            Capabilities capabilities = new Capabilities();
            Result result = LocalInterop.Calliint(_nativePointer, adapter, (int)deviceType, &capabilities, ((void**)*(void**)_nativePointer)[14]);
            result.CheckError();
            return capabilities;
        }

        public unsafe IntPtr GetAdapterMonitor(int adapter)
        {
            return LocalInterop.Calliptr(_nativePointer, adapter, ((void**)*(void**)_nativePointer)[15]);
        }
    }
}
