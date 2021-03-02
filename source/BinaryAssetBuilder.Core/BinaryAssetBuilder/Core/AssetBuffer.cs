namespace BinaryAssetBuilder.Core
{
    public class AssetBuffer
    {
        public byte[] InstanceData { get; set; }
        public byte[] RelocationData { get; set; }
        public byte[] ImportsData { get; set; }
    }
}
