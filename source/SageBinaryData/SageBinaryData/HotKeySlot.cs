using System.Runtime.InteropServices;
using AnsiString = Relo.String<sbyte>;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HotKeySlot
    {
        public BaseInheritableAsset Base;
        public int Group;
        public int Index;
        public AnsiString Name;
        public int VersionAdded;
    }
}
