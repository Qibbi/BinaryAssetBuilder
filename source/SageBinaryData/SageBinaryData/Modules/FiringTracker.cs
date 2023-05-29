using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct FiringTrackerModuleData
{
    public UpdateModuleData Base;
}
