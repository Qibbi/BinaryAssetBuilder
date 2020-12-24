using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    public enum BootupDisplayItemType
    {
        STATIC_SCREEN,
        LOAD_SCREEN,
        MOVIE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BootupDisplayItem
    {
        public BootupDisplayItemType Type;
        public int Duration;
        public int Priority;
        public List<AssetReference<Texture>> RandomTexture;
        public unsafe AnsiString* Movie;
        public SageBool ShowOnReboot;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BootupDisplaySequence
    {
        public BaseAssetType Base;
        public AssetReference<Texture> LoadingTextTexture;
        public List<BootupDisplayItem> DisplayItem;
    }
}
