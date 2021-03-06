using System.Runtime.InteropServices;

namespace SageBinaryData.Shell
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentMessage
    {
        public UIBaseComponent Base;
    }
}
