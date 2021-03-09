using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ButtonState
    {
        public AssetReference<PackedTextureImage> Image;
        public AnsiString Title;
        public AnsiString Description;
        public AnsiString TypeDescription;
    }
}
