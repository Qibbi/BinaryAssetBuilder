using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct CollideModuleData
{
    public BehaviorModuleData Base;
}
