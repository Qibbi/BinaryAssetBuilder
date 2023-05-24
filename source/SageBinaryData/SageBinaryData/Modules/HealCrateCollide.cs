using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct HealCrateCollideModuleData
{
    public CrateCollideModuleData Base;
    public float Range;
    public unsafe ObjectFilter* ObjectFilter;
}
