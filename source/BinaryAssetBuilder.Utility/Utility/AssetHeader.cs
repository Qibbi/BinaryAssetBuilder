namespace BinaryAssetBuilder.Utility
{
    // TODO:
    public class AssetHeader
    {
        public uint TypeId { get; set; }
        public uint InstanceId { get; set; }
        public uint TypeHash { get; set; }
        public uint InstanceHash { get; set; }
        public int InstanceDataSize { get; set; }
        public int RelocationDataSize { get; set; }
        public int ImportsDataSize { get; set; }
    }
}
