using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VersionType
    {
        public int Major;
        public int Minor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TheVersion
    {
        public BaseAssetType Base;
        public VersionType Version;
    }
}
