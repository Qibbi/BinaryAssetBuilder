using System.IO;

namespace BinaryAssetBuilder.Utility
{
    public class ManifestHeader : AStructWrapper<AssetStream.ManifestHeader>
    {
#if VERSION5
        public static ushort LatestVersion => 5;
#elif VERSION6
        public static ushort LatestVersion => 6;
#endif

        public unsafe bool IsBigEndian => Data->IsBigEndian;
        public unsafe bool IsLinked { get => Data->IsLinked; set => Data->IsLinked = value; }
        public unsafe ushort Version { get => Data->Version; set => Data->Version = value; }
        public unsafe uint StreamChecksum { get => Data->StreamChecksum; set => Data->StreamChecksum = value; }
        public unsafe uint AllTypesHash { get => Data->AllTypesHash; set => Data->AllTypesHash = value; }
        public unsafe uint AssetCount { get => Data->AssetCount; set => Data->AssetCount = value; }
        public unsafe uint TotalInstanceDataSize { get => Data->TotalInstanceDataSize; set => Data->TotalInstanceDataSize = value; }
        public unsafe uint MaxInstanceChunkSize { get => Data->MaxInstanceChunkSize; set => Data->MaxInstanceChunkSize = value; }
        public unsafe uint MaxRelocationChunkSize { get => Data->MaxRelocationChunkSize; set => Data->MaxRelocationChunkSize = value; }
        public unsafe uint MaxImportsChunkSize { get => Data->MaxImportsChunkSize; set => Data->MaxImportsChunkSize = value; }
        public unsafe uint AssetReferenceBufferSize { get => Data->AssetReferenceBufferSize; set => Data->AssetReferenceBufferSize = value; }
        public unsafe uint ReferenceManifestNameBufferSize { get => Data->ReferenceManifestNameBufferSize; set => Data->ReferenceManifestNameBufferSize = value; }
        public unsafe uint AssetNameBufferSize { get => Data->AssetNameBufferSize; set => Data->AssetNameBufferSize = value; }
        public unsafe uint SourceFileNameBufferSize { get => Data->SourceFileNameBufferSize; set => Data->SourceFileNameBufferSize = value; }

        public unsafe ManifestHeader() : base()
        {
            try
            {
                Data->Version = 5;
            }
            catch
            {
                Dispose();
            }
        }

        protected override unsafe void Swap()
        {
            Data->Version = Endian.BigEndian(Data->Version);
            Data->StreamChecksum = Endian.BigEndian(Data->StreamChecksum);
            Data->AllTypesHash = Endian.BigEndian(Data->AllTypesHash);
            Data->AssetCount = Endian.BigEndian(Data->AssetCount);
            Data->TotalInstanceDataSize = Endian.BigEndian(Data->TotalInstanceDataSize);
            Data->MaxInstanceChunkSize = Endian.BigEndian(Data->MaxInstanceChunkSize);
            Data->MaxRelocationChunkSize = Endian.BigEndian(Data->MaxRelocationChunkSize);
            Data->MaxImportsChunkSize = Endian.BigEndian(Data->MaxImportsChunkSize);
            Data->AssetReferenceBufferSize = Endian.BigEndian(Data->AssetReferenceBufferSize);
            Data->ReferenceManifestNameBufferSize = Endian.BigEndian(Data->ReferenceManifestNameBufferSize);
            Data->AssetNameBufferSize = Endian.BigEndian(Data->AssetNameBufferSize);
            Data->SourceFileNameBufferSize = Endian.BigEndian(Data->SourceFileNameBufferSize);
        }

        public override unsafe void SaveToStream(Stream output, bool isBigEndian)
        {
            Data->IsBigEndian = isBigEndian;
            base.SaveToStream(output, isBigEndian);
        }
    }
}
