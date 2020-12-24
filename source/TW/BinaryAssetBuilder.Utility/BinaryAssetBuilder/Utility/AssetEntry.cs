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

        protected override unsafe void Swap()
        {
            Data->TypeId = EA.Endian.BigEndian(Data->TypeId);
            Data->InstanceId = EA.Endian.BigEndian(Data->InstanceId);
            Data->TypeHash = EA.Endian.BigEndian(Data->TypeHash);
            Data->InstanceHash = EA.Endian.BigEndian(Data->InstanceHash);
            Data->AssetReferenceOffset = EA.Endian.BigEndian(Data->AssetReferenceOffset);
            Data->AssetReferenceCount = EA.Endian.BigEndian(Data->AssetReferenceCount);
            Data->NameOffset = EA.Endian.BigEndian(Data->NameOffset);
            Data->SourceFileNameOffset = EA.Endian.BigEndian(Data->SourceFileNameOffset);
            Data->InstanceDataSize = EA.Endian.BigEndian(Data->InstanceDataSize);
            Data->RelocationDataSize = EA.Endian.BigEndian(Data->RelocationDataSize);
            Data->ImportsDataSize = EA.Endian.BigEndian(Data->ImportsDataSize);
        }
    }
}
