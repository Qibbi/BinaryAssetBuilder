using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct DieModuleData
{
    public BehaviorModuleData Base;
    public DieMuxDataType DieMuxData;
}
