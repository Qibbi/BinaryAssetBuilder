using Relo;
using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StringAndHash
    {
        public uint Hash;
        public AnsiString Text;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StringHashTable
    {
        public BaseAssetType Base;
        public List<StringAndHash> StringAndHash;
    }
}
