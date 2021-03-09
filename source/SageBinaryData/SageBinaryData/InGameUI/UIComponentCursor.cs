using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UIComponentCursor
    {
        public UIBaseComponent Base;
        public StringHash AptEventCursorChanged;
        public InGameUIDecalCloudSettings DecalCloud;
    }
}
