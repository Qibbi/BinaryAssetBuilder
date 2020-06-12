using System.Runtime.InteropServices;

namespace AssetStream
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AssetEntry
    {
        public uint TypeId;
        public uint InstanceId;
        public uint TypeHash;
        public uint InstanceHash;
        public uint AssetReferenceOffset;
        public int AssetReferenceCount;
        public uint AssetNameOffset;
        public uint SourceFileNameOffset;
        public int InstanceDataSize;
        public int RelocationDataSize;
        public int ImportsDataSize;
    }
}
