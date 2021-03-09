using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentMessage
    {
        public UIBaseComponent Base;
    }
}
