using System.Runtime.InteropServices;

namespace AssetStream
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AssetHeader
    {
        public uint TypeId;
        public uint InstanceId;
        public uint TypeHash;
        public uint InstanceHash;
        public int InstanceDataSize;
        public int RelocationDataSize;
        public int ImportsDataSize;
        public uint Unknown28;
    }
}
