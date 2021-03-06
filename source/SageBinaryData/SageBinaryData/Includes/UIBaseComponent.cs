using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIBaseComponent : IPolymophic
    {
        public uint TypeId;
        public int Priority;
    }
}
