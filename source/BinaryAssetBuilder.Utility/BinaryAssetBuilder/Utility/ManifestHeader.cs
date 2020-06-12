using System.IO;
using System.Runtime.InteropServices;

namespace BinaryAssetBuilder.Utility
{
    public class ManifestHeader : AStructWrapper<AssetStream.ManifestHeader>
    {
        public static ushort LatestVersion => 5;

        public unsafe bool IsBigEndian
        {
            [return: MarshalAs(UnmanagedType.U1)]
            get => Data->IsBigEndian;
        }
        public unsafe bool IsLinked
        {
            [return: MarshalAs(UnmanagedType.U1)]
            get => Data->IsLinked;
            [param: MarshalAs(UnmanagedType.U1)]
            set => Data->IsLinked = value;
        }
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
                Dispose(true);
            }
        }

        protected override unsafe void Swap()
        {
            Data->Version = EA.Endian.BigEndian(Data->Version);
            Data->StreamChecksum = EA.Endian.BigEndian(Data->StreamChecksum);
            Data->AllTypesHash = EA.Endian.BigEndian(Data->AllTypesHash);
            Data->AssetCount = EA.Endian.BigEndian(Data->AssetCount);
            Data->TotalInstanceDataSize = EA.Endian.BigEndian(Data->TotalInstanceDataSize);
            Data->MaxInstanceChunkSize = EA.Endian.BigEndian(Data->MaxInstanceChunkSize);
            Data->MaxRelocationChunkSize = EA.Endian.BigEndian(Data->MaxRelocationChunkSize);
            Data->MaxImportsChunkSize = EA.Endian.BigEndian(Data->MaxImportsChunkSize);
            Data->AssetReferenceBufferSize = EA.Endian.BigEndian(Data->AssetReferenceBufferSize);
            Data->ReferenceManifestNameBufferSize = EA.Endian.BigEndian(Data->ReferenceManifestNameBufferSize);
            Data->AssetNameBufferSize = EA.Endian.BigEndian(Data->AssetNameBufferSize);
            Data->SourceFileNameBufferSize = EA.Endian.BigEndian(Data->SourceFileNameBufferSize);
        }

        public override unsafe void SaveToStream(Stream output, [MarshalAs(UnmanagedType.U1)] bool isBigEndian)
        {
            Data->IsBigEndian = isBigEndian;
            base.SaveToStream(output, isBigEndian);
        }
    }
}
