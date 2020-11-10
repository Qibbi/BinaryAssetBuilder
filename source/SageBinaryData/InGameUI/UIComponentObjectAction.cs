using System.Runtime.InteropServices;

namespace SageBinaryData.InGameUI
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentObjectAction
    {
        public UIBaseComponent Base;
        public Color3f AttackMoveColor;
        public Color3f MoveColor;
    }
}
