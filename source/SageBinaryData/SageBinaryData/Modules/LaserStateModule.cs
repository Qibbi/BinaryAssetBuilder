using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct LaserStateModuleData
{
    public UpdateModuleData Base;
    public int LaserId;
}
