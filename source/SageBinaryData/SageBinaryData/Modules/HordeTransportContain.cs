using System.Runtime.InteropServices;

namespace SageBinaryData;

[StructLayout(LayoutKind.Sequential)]
public struct HordeTransportContainModuleData
{
    public TransportContainModuleData Base;
    public SageBool FlyOffMapOnEmpty;
}
