using BinaryAssetBuilder.Core;
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
                        if (image->Data[0].A == byte.MaxValue)
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

        public void Initialize(object configObject, TargetPlatform targetPlatform)
        {
            throw new System.NotImplementedException();
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
    }
}
