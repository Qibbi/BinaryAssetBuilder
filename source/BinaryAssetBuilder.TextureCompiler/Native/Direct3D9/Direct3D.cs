using BinaryAssetBuilder;

namespace Native.Direct3D9
{
    public partial class Direct3D
    {
        public AdapterCollection Adapters { get; internal set; }
        public Direct3D()
        {
            FromTemp(D3D9.Create9(D3D9.SdkVersion));
            Adapters = new AdapterCollection(this);
        }

        public static void CheckVersion()
        {
            if (!D3DX.CheckVersion())
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "DirectX 9 was not found.");
            }
        }

        public bool CheckDepthStencilMatch(int adapter, DeviceType deviceType, Format adapterFormat, Format renderTargetFormat, Format depthStencilFormat)
        {
            return CheckDepthStencilMatch_(adapter, deviceType, adapterFormat, renderTargetFormat, depthStencilFormat) == 0;
        }

        public bool CheckDepthStencilMatch(int adapter, DeviceType deviceType, Format adapterFormat, Format renderTargetFormat, Format depthStencilFormat, out Result result)
        {
            result = CheckDepthStencilMatch_(adapter, deviceType, adapterFormat, renderTargetFormat, depthStencilFormat);
            return result == 0;
        }

        public bool CheckDeviceFormat(int adapter, DeviceType deviceType, Format adapterFormat, Usage usage, ResourceType resourceType, Format checkFormat)
        {
            return CheckDeviceFormat_(adapter, deviceType, adapterFormat, (int)usage, resourceType, checkFormat) == 0;
        }

        public bool CheckDeviceFormat(int adapter, DeviceType deviceType, Format adapterFormat, Usage usage, ResourceType resourceType, Format checkFormat, out Result result)
        {
            result = CheckDeviceFormat_(adapter, deviceType, adapterFormat, (int)usage, resourceType, checkFormat);
            return result == 0;
        }

        public bool CheckDeviceFormatConversion(int adapter, DeviceType deviceType, Format sourceFormat, Format targetFormat)
        {
            return CheckDeviceFormatConversion_(adapter, deviceType, sourceFormat, targetFormat) == 0;
        }

        public bool CheckDeviceFormatConversion(int adapter, DeviceType deviceType, Format sourceFormat, Format targetFormat, out Result result)
        {
            result = CheckDeviceFormatConversion_(adapter, deviceType, sourceFormat, targetFormat);
            return result == 0;
        }

        public bool CheckDeviceMultiSampleType(int adapter, DeviceType deviceType, Format surfaceFormat, bool windowed, MultisampleType multisampleType)
        {
            return CheckDeviceMultiSampleType_(adapter, deviceType, surfaceFormat, windowed, multisampleType, out _) == 0;
        }

        public bool CheckDeviceMultiSampleType(int adapter, DeviceType deviceType, Format surfaceFormat, bool windowed, MultisampleType multisampleType, out int qualityLevels)
        {
            return CheckDeviceMultiSampleType_(adapter, deviceType, surfaceFormat, windowed, multisampleType, out qualityLevels) == 0;
        }

        public bool CheckDeviceMultiSampleType(int adapter, DeviceType deviceType, Format surfaceFormat, bool windowed, MultisampleType multisampleType, out int qualityLevels, out Result result)
        {
            result = CheckDeviceMultiSampleType_(adapter, deviceType, surfaceFormat, windowed, multisampleType, out qualityLevels);
            return result == 0;
        }

        public bool CheckDeviceType(int adapter, DeviceType deviceType, Format adapterFormat, Format backBufferFormat, bool windowed)
        {
            return CheckDeviceType_(adapter, deviceType, adapterFormat, backBufferFormat, windowed) == 0;
        }

        public bool CheckDeviceType(int adapter, DeviceType deviceType, Format adapterFormat, Format backBufferFormat, bool windowed, out Result result)
        {
            result = CheckDeviceType_(adapter, deviceType, adapterFormat, backBufferFormat, windowed);
            return result == 0;
        }

        public AdapterDetails GetAdapterIdentifier(int adapter)
        {
            return GetAdapterIdentifier(adapter, 0);
        }
    }
}
