using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUICommandButtonFactionSettings
    {
        public FactionType Faction;
        public AssetReference<PackedTextureImage> LockedImage;
        public Color ImageTintColor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct InGameUICommandButtonSettings
    {
        public List<InGameUICommandButtonFactionSettings> FactionSettings;
    }
}
