using System.Runtime.InteropServices;

namespace Relo
{
    // There's also SizedList, which is probably a template with min and/or max count in the template
    // There's also SortedList, which is unknown so far

    [StructLayout(LayoutKind.Sequential)]
    public struct PolymorphicList<T> where T : unmanaged
    {
        public uint Count;
        public unsafe T** Items;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct List<T> where T : unmanaged
    {
        public uint Count;
        public unsafe T* Items;
    }
}
