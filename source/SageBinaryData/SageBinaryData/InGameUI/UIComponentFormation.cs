using System.Runtime.InteropServices;

namespace SageBinaryData.InGameUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentFormation
    {
        public UIBaseComponent Base;
        public float MaxDragLength;
    }
}
