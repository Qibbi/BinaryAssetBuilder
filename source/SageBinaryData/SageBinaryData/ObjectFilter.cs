using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ObjectFilterAsset
    {
        public BaseAssetType Base;
        public ObjectFilter Filter;
    }
}
