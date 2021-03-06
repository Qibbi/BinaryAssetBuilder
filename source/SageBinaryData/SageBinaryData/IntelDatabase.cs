using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IntelDBEntry
    {
        public AnsiString CategoryId;
        public AnsiString EntryId;
        public AnsiString TextureId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IntelDB
    {
        public BaseAssetType Base;
        public List<IntelDBEntry> IntelDBEntry;
    }
}
