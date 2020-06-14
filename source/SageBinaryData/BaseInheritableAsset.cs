using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BaseInheritableAsset
    {
        public BaseAssetType Base;
    }
}
