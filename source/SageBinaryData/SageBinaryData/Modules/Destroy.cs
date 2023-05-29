using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DestroyModuleData
{
    public BehaviorModuleData Base;
}
