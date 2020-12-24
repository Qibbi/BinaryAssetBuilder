using System.Runtime.InteropServices;

namespace AssetStream
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AssetId
    {
        public uint TypeId;
        public uint InstanceId;
    }
}
