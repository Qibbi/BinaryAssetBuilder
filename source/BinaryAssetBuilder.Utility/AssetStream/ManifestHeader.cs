using System.Runtime.InteropServices;

namespace AssetStream
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ManifestHeader
    {
        [MarshalAs(UnmanagedType.U1)] public bool IsBigEndian;
        [MarshalAs(UnmanagedType.U1)] public bool IsLinked;
        public ushort Version;
        public uint StreamChecksum;
        public uint AllTypesHash;
        public uint AssetCount;
        public uint TotalInstanceDataSize;
        public uint MaxInstanceChunkSize;
        public uint MaxRelocationChunkSize;
        public uint MaxImportsChunkSize;
        public uint AssetReferenceBufferSize;
        public uint ReferenceManifestNameBufferSize;
        public uint AssetNameBufferSize;
        public uint SourceFileNameBufferSize;
    }
}
