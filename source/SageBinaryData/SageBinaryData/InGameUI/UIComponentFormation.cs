using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentFormation
    {
        public UIBaseComponent Base;
        public float MaxDragLength;
    }
}
