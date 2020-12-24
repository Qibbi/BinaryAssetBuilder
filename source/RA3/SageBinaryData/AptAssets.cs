using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AptAptData
    {
        public BaseAssetType Base;
        public DataBlob File;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AptConstData
    {
        public BaseAssetType Base;
        public DataBlob File;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AptDatData
    {
        public BaseAssetType Base;
        public DataBlob File;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AptGeometryData
    {
        public BaseAssetType Base;
        public DataBlob File;
        public int AptID;
    }
}
