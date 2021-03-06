using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.InGameUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentMinimap
    {
        public UIBaseComponent Base;
        public int RadarWidth;
        public int RadarHeight;
        public AnsiString AptImageNameTerrain;
        public AnsiString AptImageNameObjects;
        public AnsiString AptImageNameShroud;
        public AnsiString AptImageNameOrientation;
        public float OrientationArrowSize;
        public TypedAssetId<PackedTextureImage> OrientationArrowImage;
        public AnsiString StatusTextInfiltration;
    }
}
