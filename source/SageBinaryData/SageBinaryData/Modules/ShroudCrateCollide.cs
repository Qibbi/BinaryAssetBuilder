using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct ShroudCrateCollideModuleData
{
    public CrateCollideModuleData Base;
}
