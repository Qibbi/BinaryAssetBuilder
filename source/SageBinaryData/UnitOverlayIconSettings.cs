using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VeterancyRankOverlayIcon
    {
        public int Rank;
        public AssetReference<PackedTextureImage> Image;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FactionVeterancyOverlayIcons
    {
        public FactionType Faction;
        public List<VeterancyRankOverlayIcon> RankIcon;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct UnitOverlayIconSettings
    {
        public BaseInheritableAsset Base;
        public AssetReference<PackedTextureImage> AmmoPipImage;
        public AssetReference<PackedTextureImage> AmmoPipFrameImage;
        public AssetReference<PackedTextureImage> ContainPipImage;
        public AssetReference<PackedTextureImage> ContainPipFrameImage;
        public AssetReference<PackedTextureImage> UnitTypeIconBackgroundImage;
        public AssetReference<ImageSequence> PowerIconImageSequence;
        public AssetReference<ImageSequence> RepairIconImageSequence;
        public Percentage AmmoPipScale;
        public Percentage ContainPipScale;
        public Percentage UnitTypeIconScale;
        public Percentage StatusIconScale;
        public Percentage VeterancyIconScale;
        public List<FactionVeterancyOverlayIcons> FactionVeterancy;
    }
}
