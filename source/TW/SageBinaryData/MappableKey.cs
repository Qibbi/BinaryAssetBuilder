using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MappableKey
    {
        public BaseInheritableAsset Base;
        public AnsiString KeyDef;
    }
}
