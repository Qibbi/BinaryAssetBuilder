namespace BinaryAssetBuilder.Utility
{
    public class AssetHeader : AStructWrapper<AssetStream.AssetHeader>
    {
        public unsafe uint TypeId { get => Data->TypeId; set => Data->TypeId = value; }
        public unsafe uint InstanceId { get => Data->InstanceId; set => Data->InstanceId = value; }
        public unsafe uint TypeHash { get => Data->TypeHash; set => Data->TypeHash = value; }
        public unsafe uint InstanceHash { get => Data->InstanceHash; set => Data->InstanceHash = value; }
        public unsafe int InstanceDataSize { get => Data->InstanceDataSize; set => Data->InstanceDataSize = value; }
        public unsafe int RelocationDataSize { get => Data->RelocationDataSize; set => Data->RelocationDataSize = value; }
        public unsafe int ImportsDataSize { get => Data->ImportsDataSize; set => Data->ImportsDataSize = value; }

        protected override unsafe void Swap()
        {
            Data->TypeId = Endian.BigEndian(Data->TypeId);
            Data->InstanceId = Endian.BigEndian(Data->InstanceId);
            Data->TypeHash = Endian.BigEndian(Data->TypeHash);
            Data->InstanceHash = Endian.BigEndian(Data->InstanceHash);
            Data->InstanceDataSize = Endian.BigEndian(Data->InstanceDataSize);
            Data->RelocationDataSize = Endian.BigEndian(Data->RelocationDataSize);
            Data->ImportsDataSize = Endian.BigEndian(Data->ImportsDataSize);
        }

        public unsafe bool IsValidFileLength(long fileLength)
        {
            return Data->InstanceDataSize + 32 + Data->RelocationDataSize + Data->ImportsDataSize == fileLength;
        }
    }
}
