using System.Runtime.InteropServices;

namespace Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RGBAMipMappedImage
    {
        public NVVector<NVImage<RGBA_t>> MipArray;

        public uint NumMipMaps => MipArray.Size;
        public unsafe uint Width
        {
            get
            {
                if (MipArray.Size == 0)
                {
                    return 0;
                }
                return MipArray[0]->Width;
            }
        }
        public unsafe uint Height
        {
            get
            {
                if (MipArray.Size == 0)
                {
                    return 0;
                }
                return MipArray[0]->Height;
            }
        }
        public unsafe NVImage<RGBA_t>* this[uint index] => MipArray[index];

        public RGBAMipMappedImage(uint width, uint height, uint nMipMaps)
        {
            MipArray = new NVVector<NVImage<RGBA_t>>();
            Resize(width, height, nMipMaps);
        }

        public unsafe void Resize(uint width, uint height, uint nMipMaps)
        {
            if (nMipMaps == 0)
            {
                nMipMaps = NV.CalcMaxMipmap(width, height);
            }
            MipArray.Resize(nMipMaps);
            for (uint mipLevel = 0u; mipLevel < nMipMaps; ++mipLevel)
            {
                NVImage<RGBA_t>* pMip = MipArray[mipLevel];
                pMip->Resize(width, height);
                width = NV.NextMip(width);
                height = NV.NextMip(height);
            }
        }

        public void Realloc(uint size)
        {
            MipArray.Realloc(size);
        }

        public void Clear()
        {
            MipArray.Clear();
        }
    }
}
