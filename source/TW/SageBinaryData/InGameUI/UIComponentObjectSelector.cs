using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData.InGameUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentObjectSelector
    {
        public UIBaseComponent Base;
        public AnsiString PortraitName;
        public AnsiString StatusTextNothingSelected;
        public AnsiString StatusTextSelectedAcrossMap;
        public AnsiString StatusTextSelectedAcrossScreen;
        public TypedAssetId<PackedTextureImage> AllArmyImageGDI;
        public TypedAssetId<PackedTextureImage> AllArmyImageNOD;
        public TypedAssetId<PackedTextureImage> AllArmyImageAlien;
        public RadiusDecalTemplate AlienHighlightDecal;
        public RadiusDecalTemplate GDIHighlightDecal;
        public RadiusDecalTemplate NODHighlightDecal;
        public List<ObjectFilter> ShortcutObjects;
        public SageBool ShowAllHealthBars;
    }
}
