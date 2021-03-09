using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentSpecialPowers
    {
        public UIBaseComponent Base;
        public TypedAssetId<PackedTextureImage> PowerTimerImage;
        public AnsiString PowerTimerFlashImageName;
    }
}
