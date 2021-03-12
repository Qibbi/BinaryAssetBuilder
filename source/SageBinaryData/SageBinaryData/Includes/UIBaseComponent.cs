using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIBaseComponent : IPolymorphic
    {
        public uint TypeId;
        public int Priority;
    }
}
