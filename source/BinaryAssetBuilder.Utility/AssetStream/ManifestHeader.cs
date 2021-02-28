using System.Runtime.InteropServices;

namespace AssetStream
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ManifestHeader
    {
        public SageBool IsBigEndian;
        public SageBool IsLinked;
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
