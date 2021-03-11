using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RadiusCursor
    {
        public TypedAssetId<BaseAssetType> Id; // should be TypedAssetId<RadiusCursor> but .net thinks it might be a circular reference
        public RadiusDecalTemplate DecalTemplate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RadiusCursorLibrary
    {
        public BaseAssetType Base;
        public List<RadiusCursor> RadiusCursor;
    }
}
