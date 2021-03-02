namespace BinaryAssetBuilder.Utility
{
    public class AssetEntry : AStructWrapper<AssetStream.AssetEntry>
    {
        public unsafe uint TypeId { get => Data->TypeId; set => Data->TypeId = value; }
        public unsafe uint InstanceId { get => Data->InstanceId; set => Data->InstanceId = value; }
        public unsafe uint TypeHash { get => Data->TypeHash; set => Data->TypeHash = value; }
        public unsafe uint InstanceHash { get => Data->InstanceHash; set => Data->InstanceHash = value; }
        public unsafe int AssetReferenceOffset { get => Data->AssetReferenceOffset; set => Data->AssetReferenceOffset = value; }
        public unsafe int AssetReferenceCount { get => Data->AssetReferenceCount; set => Data->AssetReferenceCount = value; }
        public unsafe int NameOffset { get => Data->NameOffset; set => Data->NameOffset = value; }
        public unsafe int SourceFileNameOffset { get => Data->SourceFileNameOffset; set => Data->SourceFileNameOffset = value; }
        public unsafe int InstanceDataSize { get => Data->InstanceDataSize; set => Data->InstanceDataSize = value; }
        public unsafe int RelocationDataSize { get => Data->RelocationDataSize; set => Data->RelocationDataSize = value; }
        public unsafe int ImportsDataSize { get => Data->ImportsDataSize; set => Data->ImportsDataSize = value; }
#if !VERSION5
        public unsafe bool Tokenized { get => Data->Tokenized != 0u; set => Data->Tokenized = value ? 1u : 0u; }
#endif

        protected override unsafe void Swap()
        {
            Data->TypeId = Endian.BigEndian(Data->TypeId);
            Data->InstanceId = Endian.BigEndian(Data->InstanceId);
            Data->TypeHash = Endian.BigEndian(Data->TypeHash);
            Data->InstanceHash = Endian.BigEndian(Data->InstanceHash);
            Data->AssetReferenceOffset = Endian.BigEndian(Data->AssetReferenceOffset);
            Data->AssetReferenceCount = Endian.BigEndian(Data->AssetReferenceCount);
            Data->NameOffset = Endian.BigEndian(Data->NameOffset);
            Data->SourceFileNameOffset = Endian.BigEndian(Data->SourceFileNameOffset);
            Data->InstanceDataSize = Endian.BigEndian(Data->InstanceDataSize);
            Data->RelocationDataSize = Endian.BigEndian(Data->RelocationDataSize);
            Data->ImportsDataSize = Endian.BigEndian(Data->ImportsDataSize);
#if !VERSION5
            Data->Tokenized = Endian.BigEndian(Data->Tokenized);
#endif
        }
    }
}
