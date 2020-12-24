using Relo;
using System.Runtime.InteropServices;

namespace SageBinaryData
{

    [StructLayout(LayoutKind.Sequential)]
    public struct MapMetaDataType // should be MapMetaData but .net dislikes enclosing types having the same name
    {
        public BaseAssetType Base;
        public List<MetaDataObject> MapMetaData;
    }
}
