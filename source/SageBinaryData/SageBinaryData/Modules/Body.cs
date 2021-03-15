using System.Runtime.InteropServices;

namespace SageBinaryData
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BodyModuleData
    {
        public BehaviorModuleData Base;
    }
}
