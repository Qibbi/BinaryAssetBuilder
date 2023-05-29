using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ShareExperienceBehaviorModuleData
{
    public UpdateModuleData Base;
    public float Radius;
    public float DropOff;
    public Percentage Percentage;
    public unsafe ObjectFilter* ObjectFilter;
}
