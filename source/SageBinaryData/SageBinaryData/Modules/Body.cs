using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct BodyModuleData : IPolymorphic
{
    public BehaviorModuleData Base;
}
