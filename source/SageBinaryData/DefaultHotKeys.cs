using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DefaultHotKeys
    {
        public BaseInheritableAsset Base;
        public HotKeyMap Map;
    }
}
