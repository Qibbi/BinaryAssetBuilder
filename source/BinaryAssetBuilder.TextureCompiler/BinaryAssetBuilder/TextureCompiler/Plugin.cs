using BinaryAssetBuilder.Core;
using BinaryAssetBuilder.Native;
using Native;
using Relo;
using System;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.TextureCompiler
{
    public class Plugin : IAssetBuilderPlugin, IDisposable
    {
        private const uint _texturePluginVersion_Xenon = 4600u;
        private const uint _texturePluginVersion_PC = 4200u;
        private const uint _textureAtlasPluginVersion_Xenon = 1800u;
        private const uint _textureAtlasPluginVersion_PC = 1800u;

        private static readonly Tracer _tracer = Tracer.GetTracer(nameof(TextureCompiler), "Provides Texture Processing");

        private uint _hashCode;
        private TargetPlatform _platform;
        private Direct3D _d3d;
        private D3DDevice _d3dDevice;
        private IntPtr _hBuffer;

        private unsafe SimpleBuffer* _pBuffer => (SimpleBuffer*)_hBuffer;

        private unsafe bool IsValidTexture(InstanceDeclaration declaration, NVImage<RGBA_t>* image)
        {
            if (image->Height <= 0)
            {
                _tracer.TraceWarning("The loaded image contains no pixel data. {0} will be pink.", declaration.Handle.InstanceName);
                return false;
            }
            if (!Misc.IsPowerOfTwo(image->Width) || !Misc.IsPowerOfTwo(image->Height))
            {
                _tracer.TraceWarning("Non power of two sized textures not supported. {0} will be pink.", declaration.Handle.InstanceName);
                return false;
            }
            return true;
        }

        private unsafe string GuessProperFormat(InstanceDeclaration declaration, bool hasAlpha, NVImage<RGBA_t>* image, string inFormat)
        {
            if (inFormat == "D3DFMT_DXT1")
            {
                if (hasAlpha)
                {
                    if (Misc.HasConstantAlphaChannel(image))
                    {
                        if (image->Pixels[0].A == byte.MaxValue)
                        {
                            return inFormat;
                        }
                        _tracer.TraceInfo("Converting to DXT3 because \"{0}\" has a constant color alpha channel. DXT3 should be specified in the XML, or the alpha channel should be removed.",
                                          declaration.Handle.InstanceName);
                        return "D3DFMT_DXT3";
                    }
                    if (Misc.Has1BitAlphaChannel(image))
                    {
                        _tracer.TraceInfo("Converting to DXT3 because \"{0}\" has a 1 bit alpha channel. DXT3 should be specified in the XML, or the alpha channel should be removed.",
                                          declaration.Handle.InstanceName);
                        return "D3DFMT_DXT3";
                    }
                    _tracer.TraceInfo("Converting to DXT5 because \"{0}\" does not have a 1 bit alpha channel. DXT5 should be specified in the XML, or the alpha channel should be removed.",
                                      declaration.Handle.InstanceName);
                    return "D3DFMT_DXT5";
                }
            }
            return inFormat;
        }

        private unsafe IntPtr GetNVCompressionOptions(string format, bool generateMipMaps)
        {
            IntPtr result = Marshal.AllocHGlobal(sizeof(NVCompressionOptions));
            NVCompressionOptions* compressionOptions = (NVCompressionOptions*)result;
            compressionOptions->Initialize();
            compressionOptions->TextureFormat = format switch
            {
                "D3DFMT_A8R8G8B8" => NVTextureFormats.A8R8G8B8,
                "D3DFMT_DXT5" => NVTextureFormats.DXT5,
                "D3DFMT_DXT3" => NVTextureFormats.DXT3,
                "D3DFMT_DXT1A" => NVTextureFormats.DXT1a,
                "D3DFMT_X8R8G8B8" => NVTextureFormats.AXR8G8B8,
                "D3DFMT_R5G6B5" => NVTextureFormats.A0R5G6B5,
                _ => NVTextureFormats.DXT1,
            };
            if (generateMipMaps)
            {
                compressionOptions->MipMapGeneration = NVMipMapGeneration.GenerateMipMaps;
                compressionOptions->NumMipMapsToWrite = 0;
            }
            else
            {
                compressionOptions->MipMapGeneration = NVMipMapGeneration.NoMipMaps;
            }
            return result;
        }

        public unsafe void Initialize(object configObject, TargetPlatform targetPlatform)
        {
            _hashCode = HashProvider.GetTypeHash(GetType());
            _platform = targetPlatform;
            if (_platform != TargetPlatform.Win32)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Texture compiler is PC only.");
            }
            _d3d = new Direct3D();
            D3DPresentParameters pp = new D3DPresentParameters();
            MsVcRt.MemSet((IntPtr)(&pp), 0, new SizeT(sizeof(D3DPresentParameters)));
            pp.BackBufferWidth = 640;
            pp.BackBufferHeight = 480;
            pp.BackBufferFormat = D3DFormat.D3DFMT_A8R8G8B8; // 0x18280186 is XBOX 360 equivalent
            pp.BackBufferCount = 1;
            pp.MultiSampleType = D3DMultiSampleType.D3DMULTISAMPLE_NONE;
            pp.MultiSampleQuality = 0;
            pp.SwapEffect = D3DSwapEffect.D3DSWAPEFFECT_DISCARD;
            pp.EnableAutoDepthStencil = true;
            pp.AutoDepthStencilFormat = D3DFormat.D3DFMT_D32; // 0x2D200196 is XBOX 360, but unknown, just chose D32
            pp.PresentationInterval = 1;
            _d3d.CreateDevice(0u, D3DDeviceType.D3DDEVTYPE_HAL, IntPtr.Zero, 0, (IntPtr)(&pp), out _d3dDevice);
            _hBuffer = Marshal.AllocHGlobal(sizeof(SimpleBuffer));
        }

        public unsafe void FinalizeTracker(Tracker tracker, AssetBuffer buffer)
        {
            Relo.Chunk chunk = new Relo.Chunk();
            tracker.MakeRelocatable(chunk);
            buffer.InstanceData = chunk.InstanceBuffer;
            buffer.RelocationData = chunk.RelocationBuffer;
            buffer.ImportsData = chunk.ImportsBuffer;
        }

        public unsafe void CompressAndEmbed(Tracker tracker, TextureFileData* textureData, NVImage<RGBA_t>* image, NVCompressionOptions* options)
        {
            _pBuffer->Reset();
            options->UserData = (void*)_hBuffer;
            NVErrorCode result = 
            // TODO: NVErrorCode nvErrorCode = NVDDS.NVDXTCompress(image, options, )
        }

        public AssetBuffer ProcessInstance(InstanceDeclaration declaration)
        {
            throw new System.NotImplementedException();
        }
        public uint GetAllTypesHash()
        {
            throw new System.NotImplementedException();
        }

        public ExtendedTypeInformation GetExtendedTypeInformation(uint typeId)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        ~Plugin()
        {
            _d3dDevice.Dispose();
            _d3d.Dispose();
        }
    }
}
